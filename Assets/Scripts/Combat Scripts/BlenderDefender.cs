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
            string msg = "The Blender Defender attacks " + targets[0].name + " with " + this.attack1name + "\n" + this.attack1desc;
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
            string msg = "The training dummy uses healing on itself.\n";
            this.Damage(-2);
            msg += "It healed itself for 2 HP";
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
