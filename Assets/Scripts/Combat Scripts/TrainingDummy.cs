using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : Fighter
{
    private void Awake()
    {
        this.attack1execute = targets =>
        {
            string msg = "The training dummy attacks " + targets[0].name + " with " + this.attack1name + "\n";
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
            string msg = "The training dummy attacks " + targets[0].name + " with " + this.attack1name + "\n";
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

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
