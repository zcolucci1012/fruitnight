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
            if (result.hit)
            {
                targets[0].turnsCantHeal = 2;
            }
            return result.msg + " and removes their ability to heal";
        };

        //Poisonfruit
        this.attack2execute = targets =>
        {
            AttackResult result = Hit(targets[0], 1);
            if (result.hit)
            {
                targets[0].poisonAttacks.Add(new PoisonAttack(3, 1));
            }
            return result + " poisoning them for 3 turns";
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
