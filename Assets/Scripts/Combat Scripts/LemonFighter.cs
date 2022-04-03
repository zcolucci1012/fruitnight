using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonFighter : Fighter
{
    private void Awake()
    {
        // Sour Power
        this.attack1execute = targets =>
        {
            return Hit(targets[0], 4).msg;
        };

        // Lemon Twist
        this.attack2execute = targets =>
        {
            AttackResult result = Hit(targets[0], 6);
            string msg = result.msg;
            if (result.hit)
            {
                int selfDamage = UnityEngine.Random.Range(2, 4);
                this.Damage(selfDamage);
                msg += "\nLemon hurts themself for " + selfDamage + " damage";

            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
