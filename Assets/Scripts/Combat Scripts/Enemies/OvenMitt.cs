using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenMitt : Fighter
{
    private void Awake()
    {
        // Mend
        this.attack1execute = targets =>
        {
            string msg = "The oven mitt begins its passive mending, healing 1 HP per turn for 4 turns";
            this.poisonAttacks.Add(new PoisonAttack(4, -1));
            return msg;
        };

        // Slap
        this.attack2execute = targets =>
        {
            string msg = "The oven mitt slaps both of its enemies.\n";
            foreach (Fighter f in targets)
            {
                AttackResult result = this.Hit(f, 4);
                msg += result.msg + "\n";
            }
            return msg;
        };

        // Grab
        this.attack3execute = targets =>
        {
            string msg = "The oven mitt grabs you and shakes the life out of you.\n";
            AttackResult result = Hit(targets[0], 3);
            msg += result.msg;
            if (result.hit)
            {
                int healing = Damage(-result.dmg);
                msg += ", and stole " + targets[0].name + "\'s health to heal itself for " + (-healing) + " hp";
            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
