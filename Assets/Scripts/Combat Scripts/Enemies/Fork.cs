using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : Fighter
{
    private void Awake()
    {
        // Stab
        this.attack1execute = targets =>
        {
            return Hit(targets[0], 4).msg;
        };

        // Support
        this.attack2execute = targets =>
        {
            if (targets[0].currentHp == targets[0].maxHp)
            {
                return "ERROR";
            }
            string msg = "The fork heals its partner.\n";
            int healing = -targets[0].Damage(-3);
            if (healing == 0)
            {
                msg += "It can't heal!";
            }
            else
            {
                msg += "It healed its partner " + healing + " HP";
            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
