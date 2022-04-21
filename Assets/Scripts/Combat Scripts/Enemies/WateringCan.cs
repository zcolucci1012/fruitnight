using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : Fighter
{
     private void Awake()
    {
        // Sprinkler
        this.attack1execute = targets =>
        {
            Debug.Log("Sprinkler");
            string msg = "Watty sprinkles a stream of water on its opponents.\n";
            foreach (Fighter f in targets)
            {
                AttackResult result = this.Hit(f, 2);
                msg += result.msg + "\n";                
            }
            return msg;
        };

        // Healing water
        this.attack2execute = targets =>
        {
            Debug.Log("heal");
            if (this.currentHp == this.maxHp)
            {
                return "ERROR";
            }
            string msg = "Watty heals itself with healing water.\n";
            int healing = this.Damage(-3);
            if (healing == 0)
            {
                msg += "It can't heal!";
            }
            else
            {
                msg += "It healed itself " + healing + " HP";
            }
            return msg;
        };

        // Flood
        this.attack3execute = targets =>
        {
            Debug.Log("Flood");
            string msg = "Watty floods his opponents.\n";
            foreach (Fighter f in targets) {
                f.Defense(2, 2);
                msg += "Watty lowered " + f.name + "'s defense by 2 pts for 2 turns.\n";
            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
