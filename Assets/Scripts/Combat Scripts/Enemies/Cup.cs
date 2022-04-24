using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Fighter
{
    public override string Compliment() {
        // DO SOMETHING
        this.Damage(-5);
        return "'You're such a great poet!'\nCup almost breaks out into haikus, but contains themself and instead feels healthier.";
    }

    public override string Insult() {
        this.Damage(5);
        return "'You'll never be as good a poet as Tomato and Shakes Pear!'\nCup has one tear stream silently down their cheek, feeling weak.";
    }

    private void Awake()
    {
        // Heal
        this.attack1execute = targets =>
        {
            if (targets[0].currentHp == targets[0].maxHp || targets[0].unconscious)
            {
                Debug.Log("tried to heal but didn't :D");
                return "ERROR";
            }
            string msg = this.name + " heals its partner.\n";
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
                AttackResult result = this.Hit(f, 3, "Cup");
                msg += result.msg + "\n";
            }
            return msg;
        };

        // Cooldown
        this.attack3execute = targets =>
        {
            string msg = this.name + " cools down this turn, and then will gain +2HP of damage on all its attacks.\n";
            this.dmgMod += 2;
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
