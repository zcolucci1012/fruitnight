using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlenderDefender : Fighter
{
    private void Awake()
    {
        // Blend attack (damage)
        this.attack1execute = targets =>
        {
            return Hit(targets[0], 4).msg;
        };

        this.attack2execute = targets =>
        {
            if (this.currentHp == this.maxHp)
            {
                return "ERROR";
            }
            string msg = "The enemy uses healing on itself.\n";
            int healing = -this.Damage(-2);
            if (healing == 0) {
                msg += "It can't heal!";
            } else {
                msg += "It healed itself for " + healing + " HP";
            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
