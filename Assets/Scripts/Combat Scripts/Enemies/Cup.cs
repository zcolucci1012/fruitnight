using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Fighter
{
    public override string Compliment() {
        // DO SOMETHING
        return "'I like your patterns! They're very divine!'\nOven Mitt blushes in appreciation. However, they are committed to their fight, and it has no effect.";
    }

    public override string Insult() {
        return "'I hate your patterns! It's so late 80s'\nOven Mitt quietly sobs.";
    }

    private void Awake()
    {
        // Heal
        this.attack2execute = targets =>
        {
            if (targets[0].currentHp == targets[0].maxHp || targets[0].unconscious)
            {
                Debug.Log("tried to heal but didn't :D");
                return "ERROR";
            }
            string msg = this.name + "heals its partner.\n";
            int healing = -targets[0].Damage(-3);
            if (healing == 0)
            {
                msg += "It can't heal!";
            }
            else
            {
                msg += "It healed its partner for " + healing + " HP";
            }
            return msg;
        };

        // Scoop
        this.attack2execute = targets =>
        {
            string msg = this.name + " swings across the table to scoop up it's enemies.\n";
            foreach (Fighter f in targets)
            {
                AttackResult result = this.Hit(f, 3, this.attack2name);
                msg += result.msg + "\n";
            }
            return msg;
        };

        // Cooldown
        this.attack3execute = targets =>
        {
            string msg = this.name + " cools down the next turn, and then will gain +1HP of damage on all its attacks.\n";
            this.turnsFrozen = 2;
            this.dmgMod += 1;
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
