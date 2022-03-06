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
            targets[0].Damage(2);
            targets[0].Defense(-2, 2);
            return "Lemon deals 4 points of damage to " + targets[0].name + "\n";
        };

        // Lemon Twist
        this.attack2execute = targets =>
        {
            targets[0].Damage(6);
            int selfDamage = UnityEngine.Random.Range(2, 4);
            this.Damage(selfDamage);
            return "Lemon deals 6 points of damage to " + targets[0].name + " but hurts itself for " + selfDamage + " points\n";
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
