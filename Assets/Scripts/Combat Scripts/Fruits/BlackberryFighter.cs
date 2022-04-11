using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackberryFighter : Fighter
{

    private void Awake()
    {
        // Darkseed Shot
        this.attack1execute = targets =>
        {
            AttackResult result = Hit(targets[0], 2);
            string msg = result.msg;
            if (result.hit)
            {
                targets[0].turnsCantHeal = 2;
                msg += " and removes their ability to heal for 2 turns";
            }
            return msg;
        };

        //Poisonfruit
        this.attack2execute = targets =>
        {
            AttackResult result = Hit(targets[0], 1);
            string msg = result.msg;
            if (result.hit) 
            {
                targets[0].poisonAttacks.Add(new PoisonAttack(3, 1));
                msg += " poisoning them for 3 turns";
            }
            return msg;
        };

        // Vampiric prickle
        this.attack3execute = targets =>
        {
            AttackResult result = Hit(targets[0], 2);
            string msg = result.msg;
            if (result.hit) 
            {
                int healing = Damage(-2);
                msg += ", and stole " + targets[0] + " health to heal itself for " + healing + " hp";
            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
