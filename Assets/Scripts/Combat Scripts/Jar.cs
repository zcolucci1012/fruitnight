using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar : Fighter
{
    private void Awake()
    {
        // Trap
        this.attack1execute = targets =>
        {
            targets[0].turnsFrozen+=2;
            return "The jar traps " + targets[0].name + " for 1 turn";
        };

        // Jam
        this.attack2execute = targets =>
        {
            string msg = "";
            AttackResult result = this.Hit(targets[0], 2);
            msg += result.msg;
            if (result.hit)
            {
                targets[0].turnsCantHeal+=2;
                msg += "\nThey can't heal for 1 turn";
            }
            return msg;
        };

        // Roll
        this.attack3execute = targets =>
        {
            return this.Hit(targets[0], 3).msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}