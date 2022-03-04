using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Banana : Fighter
{
    private void Awake()
    {
        this.attack1execute = targets =>
        {
            string msg = "Banana attacks " + targets[0].name + " with " + attack1name + "\n";
            if (targets[0].defense <= UnityEngine.Random.Range(1, 20))
            {
                int dmg = (int)(4 * dmgMult) + dmgMod;
                targets[0].Damage(dmg);
                msg += "It dealt " + dmg + " damage";
            }
            else
            {
                msg += "It missed!";
            }

            return msg;
        };

        this.attack2execute = targets =>
        {
            string msg = "Banana attacks with " + attack2name + "\n";
            int roll = UnityEngine.Random.Range(1, 20);
            foreach (Fighter f in targets)
            {
                if (f.defense <= roll)
                {
                    int dmg = (int)(2 * dmgMult) + dmgMod;
                    f.Damage(dmg);
                    msg += "It hits " + f.name + " for " + dmg + " damage\n";
                }
                else
                {
                    msg += "It misses " + f.name;
                }
            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
