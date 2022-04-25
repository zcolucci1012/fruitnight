using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public abstract class Fighter : MonoBehaviour
{
    public int maxHp = 0;
    public int currentHp;
    public float defense = 10;
    public float baseDefense = 10;
    public bool unconscious = false;

    public string attack1name = "none";
    public string attack2name = "none";
    public string attack3name = "none";

    public string attack1desc = "none";
    public string attack2desc = "none";
    public string attack3desc = "none";

    public AttackType attack1type = AttackType.SingleTarget;
    public AttackType attack2type = AttackType.SingleTarget;
    public AttackType attack3type = AttackType.SingleTarget;

    //function executes after attack and target are selected
    //targets are who the attack hits
    //return value is result of attack to print
    public Func<Fighter[], string> attack1execute;
    public Func<Fighter[], string> attack2execute;
    public Func<Fighter[], string> attack3execute;
    public Func<Fighter[], string> complimentExecute;
    public Func<Fighter[], string> insultExecute;

    public bool canCompliment = false;
    public bool canInsult = false;

    protected string ineffectiveCompliment;
    protected string ineffectiveInsult;

    public Attack attack1 = null;
    public Attack attack2 = null;
    public Attack attack3 = null;
    public Attack complimentAttack = null;
    public Attack insultAttack = null;

    // list of current acting defense modifiers, and how long they will last
    public List<(int defValue, int turnsLeft)> defenseModifiers = new List<(int defValue, int turnsLeft)>{};

    // specifies how many more turns the fighter is frozen for and can't move
    public int turnsFrozen = 0;
    public int turnsCantHeal = 0;
    public List<PoisonAttack> poisonAttacks = new List<PoisonAttack>();

    public int dmgMod = 0;
    public int turnsStrongHit = 0;

    private Vector3 originalEulerAngles;

    public HealthBar healthBar = null;
    public GameObject healthBarObject;
    public bool canHeal;

    public int healingMod = 1;

    public bool complimented = false;
    public bool insulted = false;

    // Start is called before the first frame update
    void Start()
    {
        this.currentHp = this.maxHp;
        /*if (this.healthBar != null)
        {
            this.healthBar.maxValue = this.maxHp;
        }*/

        originalEulerAngles = this.transform.eulerAngles;

        ineffectiveCompliment = "'You're doing great!'\nIt's not very effective on " + name + ".\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them later.";
        ineffectiveInsult = "'You suck!'\nIt's not very effective on " + name + ".\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them later.";

    }

    // Update is called once per frame
    void Update()
    {
        if (this.healthBar != null) {
            healthBar.UpdateHealthBar();
        }

        if (healthBarObject != null)
        {
            if (unconscious)
            {
                healthBarObject.SetActive(false);
            }
            else
            {
                healthBarObject.SetActive(true);
            }
        }   
    }

    // freezes this fighter for the specified number of turns
    // NOTE: freezes do NOT stack, so we take the max of the existing freeze and new freeze
    public void Freeze(int turns) {
        turnsFrozen = Mathf.Max(turnsFrozen, turns);
    }

    public AttackResult Hit(Fighter target, int dmg, string name)
    {
        Debug.Log(name);
        int roll = UnityEngine.Random.Range(1, 20);
        if (turnsStrongHit > 0) {
            int effectiveDamage = target.Damage(dmg + dmgMod);
            string msg = "Strong hit!: " + this.name + " deals " + effectiveDamage + " DMG to " + target.name;
            if (target.unconscious)
            {
                msg += ", knocking them unconscious";
            }
            // play audio
            FindObjectOfType<DialogueAudio>().PlayAudio(name);
            return new AttackResult(true, effectiveDamage, msg);
        }
        // print("defense: " + target.defense + ", roll: " + roll);
        if (roll == 20 || roll == 19)
        {
            int effectiveDamage = target.Damage((dmg + dmgMod) * 2);
            string msg = "CRITICAL HIT!: " + this.name + " deals " + effectiveDamage + " DMG to " + target.name;
            if (target.unconscious)
            {
                msg += ", knocking them unconscious";
            }
            // play audio
            FindObjectOfType<DialogueAudio>().PlayAudio(name);
            return new AttackResult(true, effectiveDamage, msg);
        }
        else if (roll == 1)
        {
            string msg = "Critical miss: The attack misses " + target.name;
            // play miss sound
            FindObjectOfType<DialogueAudio>().PlayAudio("Miss");
            return new AttackResult(false, 0, msg);
        }
        else if (target.defense < roll)
        {
            int effectiveDamage = target.Damage(dmg + dmgMod);
            string msg = "Strong hit!: " + this.name + " deals " + effectiveDamage + " DMG to " + target.name;
            if (target.unconscious)
            {
                msg += ", knocking them unconscious";
            }
            // play audio
            FindObjectOfType<DialogueAudio>().PlayAudio(name);
            return new AttackResult(true, effectiveDamage, msg);
        }
        else
        {
            int effectiveDamage = target.Damage((dmg + dmgMod) / 2);
            string msg = "Weak hit: " + this.name + " deals " + effectiveDamage + " DMG to " + target.name;
            if (target.unconscious)
            {
                msg += ", knocking them unconscious";
            }
            else
            {
                // play audio
                FindObjectOfType<DialogueAudio>().PlayAudio(name);
            }
            return new AttackResult(true, effectiveDamage, msg);
        }
    }

    public int Damage(int hp)
    {
        if (turnsCantHeal > 0 && hp < 0)
        {
            return 0;
        }
        this.currentHp -= hp;
        int effectiveDamage = hp;
        if (this.currentHp <= 0)
        {
            unconscious = true;
            effectiveDamage += this.currentHp;
            this.currentHp = 0;
            this.transform.eulerAngles = this.originalEulerAngles + new Vector3(0, 0, 90);
        }
        else
        {
            unconscious = false;
            this.transform.eulerAngles = this.originalEulerAngles;
        }

        if (this.currentHp > maxHp)
        {
            effectiveDamage += (this.currentHp - maxHp);
            this.currentHp = maxHp;
        }
        // if they are healing, play heal sound
        if (hp < 0)
        {
            FindObjectOfType<DialogueAudio>().PlayAudio("Heal");
        }
        return effectiveDamage;
    }

    // add a defense modifier for the specified amount of turns
    public void Defense(int modifier, int turns) {
        FindObjectOfType<DialogueAudio>().PlayAudio("Stat Boost");
        this.defenseModifiers.Add((modifier, turns));
        this.defense = Mathf.Clamp(this.defense + modifier, 0, 20);
    }

    public string endOfTurnUpdate() {
        string msg = "";

        applyDefenseMods();

        // reduces turns frozen value 
        if (this.turnsFrozen > 0) {
            this.turnsFrozen--;
            if (this.turnsFrozen == 0) {
                msg += this.name + " can move again!\n";
            }
        }

        if (this.turnsStrongHit > 0) {
            this.turnsStrongHit--;
            if (this.turnsStrongHit == 0) {
                msg += this.name + "'s attack boost wore off\n";
            }
        }

        msg += applyPoisons();

        if (this.turnsCantHeal > 0)
        {
            this.turnsCantHeal--;
            if (this.turnsCantHeal == 0) {
                msg += this.name + " can heal again!\n";
            }
        }

        poisonAttacks = poisonAttacks.FindAll(x => x.turns > 0);

        return msg;
    }

    protected string applyDefenseMods() {
        string msg = "";
        // loops through and see if any modifiers have worn off.
        for (int ii = 0; ii < defenseModifiers.Count; ii++) {
            defenseModifiers[ii] = (defenseModifiers[ii].defValue, defenseModifiers[ii].turnsLeft - 1);
            if (defenseModifiers[ii].turnsLeft <= 0) {
                // remove effects from it on defense
                // TODO : fix this to account for edge cases where removing the defense modifier will still result in something over 20
                this.defense = Mathf.Clamp(this.defense - defenseModifiers[ii].defValue, 0, 20);

                // remove defense modifier from active list
                defenseModifiers.RemoveAt(ii);
                msg += this.name + "'s defense boost wore off!\n";
            }
        }
        return msg;
    }

    protected string applyPoisons() {
        string msg = "";
        bool poisoned = false;
        bool regenerated = false;
        foreach (PoisonAttack p in poisonAttacks)
        {
            print(p.dmg);
            if (p.dmg > 0 && !unconscious)
            {
                Damage(p.dmg);
                print("poison damage!");
                if (!poisoned) {
                    msg += this.name + " was hurt by it's poison!\n";
                    poisoned = true;
                }
            } else if (p.dmg < 0 && !(turnsCantHeal > 0 || unconscious)) {
                Damage(p.dmg);
                print("antidote regeneration!");
                if (!regenerated)
                {
                    msg += this.name + " had some health regenerated!\n";
                    regenerated = true;
                }
            }
            p.turns--;
        }
        return msg;
    }

    //// NOTE: because of the way this works, we will need to manually account for an extra turn if
    //// the fighter does damage/modifiers to itself
    //public void endOfTurnUpdate() {
    //    // loops through and see if any modifiers have worn off.
    //    for (int ii = 0; ii < defenseModifiers.Count; ii++) {
    //        defenseModifiers[ii] = (defenseModifiers[ii].defValue, defenseModifiers[ii].turnsLeft - 1);
    //        if (defenseModifiers[ii].turnsLeft <= 0) {
    //            // remove effects from it on defense
    //            // TODO : fix this to account for edge cases where removing the defense modifier will still result in something over 20
    //            this.defense = Mathf.Clamp(this.defense - defenseModifiers[ii].defValue, 0, 20);

    //            // remove defense modifier from active list
    //            defenseModifiers.RemoveAt(ii);
    //        }
    //    }

    //    // reduces turns frozen value 
    //    if (this.turnsFrozen > 0) {
    //        this.turnsFrozen--;
    //    }

    //    if (this.turnsStrongHit > 0) {
    //        this.turnsStrongHit--;
    //    }

    //    foreach (PoisonAttack p in poisonAttacks)
    //    {
    //        if (!(p.dmg < 0 && (turnsCantHeal > 0 || unconscious)))
    //        {
    //            Damage(p.dmg);
    //            print("poison damage!");
    //        }
    //        p.turns--;
    //    }

    //    if (this.turnsCantHeal > 0)
    //    {
    //        this.turnsCantHeal--;
    //    }

    //    poisonAttacks = poisonAttacks.FindAll(x => x.turns > 0);
    //}

    public bool canAttack() {
        return turnsFrozen <= 0;
    }

    public virtual Attack[] GetEligibleAttacks()
    {
        List<Attack> eligibleAttacks = new List<Attack>();
        if (this.attack1 != null)
        {
            eligibleAttacks.Add(this.attack1);
        }
        if (this.attack2 != null)
        {
            eligibleAttacks.Add(this.attack2);
        }
        if (this.attack3 != null)
        {
            eligibleAttacks.Add(this.attack3);
        }

        return eligibleAttacks.ToArray();
    }

    public virtual string Compliment() {
        return ineffectiveCompliment;
    }
    public virtual string Insult() {
        return ineffectiveInsult;
    }
}