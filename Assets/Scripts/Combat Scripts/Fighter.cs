using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class Fighter : MonoBehaviour
{
    public int maxHp = 0;
    public int currentHp;
    public float defense = 10;
    public float baseDefense = 10;
    public bool unconscious = false;

    public string attack1name = "none";
    public string attack2name = "none";

    public string attack1desc = "none";
    public string attack2desc = "none";

    public AttackType attack1type = AttackType.SingleTarget;
    public AttackType attack2type = AttackType.SingleTarget;
    //public AttackType attack3type = AttackType.SingleTarget;

    //function executes after attack and target are selected
    //targets are who the attack hits
    //return value is result of attack to print
    public Func<Fighter[], string> attack1execute;
    public Func<Fighter[], string> attack2execute;

    public Attack attack1;
    public Attack attack2;
    //public Attack attack3;
    //public Attack[] attacks;

    // list of current acting defense modifiers, and how long they will last
    public List<(int defValue, int turnsLeft)> defenseModifiers = new List<(int defValue, int turnsLeft)>{};

    // specifies how many more turns the fighter is frozen for and can't move
    public int turnsFrozen = 0;

    public int dmgMod = 0;

    private Vector3 originalEulerAngles;

    public HealthBar healthBar = null;

    // Start is called before the first frame update
    void Start()
    {
        this.currentHp = this.maxHp;
        /*if (this.healthBar != null)
        {
            this.healthBar.maxValue = this.maxHp;
        }*/

        originalEulerAngles = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.healthBar != null) {
            healthBar.UpdateHealthBar();
        }

        if (unconscious)
        {
            
        }
    }
    
    public AttackResult Hit(Fighter target, int dmg)
    {
        int roll = UnityEngine.Random.Range(0, 20);
        // print("defense: " + target.defense + ", roll: " + roll);
        if (target.defense < roll)
        {
            int effectiveDamage = target.Damage(dmg + dmgMod);
            string msg = this.name + " deals " + effectiveDamage + " points of damage to " + target.name;
            if (target.unconscious)
            {
                msg += ", knocking them unconscious";
            }
            return new AttackResult(true, effectiveDamage, msg);
        }
        else
        {
            return new AttackResult(false, 0, this.name + " misses " + target.name);
        }
        
    }

    public int Damage(int hp)
    {
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

        return effectiveDamage;
    }

    // add a defense modifier for the specified amount of turns
    public void Defense(int modifier, int turns) {
        this.defenseModifiers.Add((modifier, turns));
        this.defense = Mathf.Clamp(this.defense + modifier, 0, 20);
    }

    public void endOfRoundUpdate() {
        // loops through and see if any modifiers have worn off.
        for (int ii = 0; ii < defenseModifiers.Count; ii++) {
            defenseModifiers[ii] = (defenseModifiers[ii].defValue, defenseModifiers[ii].turnsLeft - 1);
            if (defenseModifiers[ii].turnsLeft <= 0) {
                // remove effects from it on defense
                // TODO : fix this to account for edge cases where removing the defense modifier will still result in something over 20
                this.defense = Mathf.Clamp(this.defense - defenseModifiers[ii].defValue, 0, 20);

                // remove defense modifier from active list
                defenseModifiers.RemoveAt(ii);
            }
        }

        // reduces turns frozen value 
        if (this.turnsFrozen > 0) {
            this.turnsFrozen--;
        }
    }

    public bool canAttack() {
        return turnsFrozen <= 0;
    }
}
