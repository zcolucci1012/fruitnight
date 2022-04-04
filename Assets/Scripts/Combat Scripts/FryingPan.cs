using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingPan : Fighter
{
    private void Awake()
    {
        // Flatten
        this.attack1execute = targets =>
        {
            string msg = "The frying pan trys to flatten you both.\n";
            foreach (Fighter f in targets)
            {
                msg += this.Hit(f, 2).msg + "\n";
            }
            return msg;
        };

        // Tinker
        this.attack2execute = targets =>
        {
            string msg = "The enemy heals its partner.\n";
            int healing = -targets[0].Damage(-2);
            if (healing == 0) {
                msg += "It can't heal!";
            } else {
                msg += "It healed its partner for " + healing + " HP";
            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
