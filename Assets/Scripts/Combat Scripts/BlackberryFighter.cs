using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackberryFighter : Fighter
{

    private void Awake()
    {
        // Sugar Blast
        this.attack1execute = targets =>
        {
            targets[0].Damage(2);
            targets[0].Defense(-2, 2);
            return "Blueberry deals 2 points of damage to " + targets[0].name + " and lowers their defense by 2 points";
        };

        this.attack2execute = targets =>
        {
            targets[0].Defense(2, 2);
            this.Defense(3, 2);
            return "Blueberry raises their partner's defense by 2 and raises it's own defense by 3";
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
