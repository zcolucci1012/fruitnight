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
                targets[0].turnsCantHeal = result.dmg;
                msg += " and removes their ability to heal for " + result.dmg + " turns";
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
                targets[0].poisonAttacks.Add(new PoisonAttack(result.dmg + 2, 1));
                msg += " poisoning them for " + (result.dmg + 2) + " turns";
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
