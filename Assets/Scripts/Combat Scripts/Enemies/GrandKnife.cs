using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandKnife : Fighter
{
    private void Awake()
    {
        // Knife swing
        this.attack1execute = targets =>
        {
            string msg = "The Grand Knife swings his blade\n";
            foreach (Fighter f in targets)
            {
                AttackResult result = this.Hit(f, 3, "Knife");
                msg += result.msg + "\n";                
            }
            return msg;
        };

        // Massive chop
        this.attack2execute = targets =>
        {
            string msg = "The Grand Knife performs a massive chop.\n";
            msg += this.Hit(targets[0], 6, "Knife").msg;
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
