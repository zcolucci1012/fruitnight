using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueberryFighter : Fighter
{

    private void Awake()
    {
        // Sugar Blast
        this.attack1execute = targets =>
        {
            AttackResult result = Hit(targets[0], 2);
            string msg = result.msg;
            if (result.hit)
            {
                targets[0].Defense(-2, 2);
                msg += "\n" + targets[0].name + "\'s defense lowers by 2";
            }
            return msg;
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
