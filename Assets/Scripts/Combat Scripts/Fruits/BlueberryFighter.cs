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
            AttackResult result = Hit(targets[0], 2, this.attack1name);
            string msg = result.msg;
            if (result.hit)
            {
                targets[0].Defense(-2, 2);
                msg += "\n" + targets[0].name + "\'s defense lowers by 2 pts";
            }
            return msg;
        };

        this.attack2execute = targets =>
        {
            string msg = "";
            foreach (Fighter target in targets) {
                if (target is BlueberryFighter) {
                    target.Defense(3, 2);
                    msg += "Blueberry raises their own defense by 3 pts for 2 turns. \n";
                } else {
                    target.Defense(2, 2);
                    msg += "Blueberry raises " + target.name + "'s defense by 2 pts for 2 turns. \n";
                } 
            }
            return msg;
        };

        this.attack3execute = targets =>
        {
            targets[0].turnsCantHeal = 3;
            FindObjectOfType<DialogueAudio>().PlayAudio(this.attack3name);
            return "Blueberry studies " + targets[0].name + " and removes their ability to heal for 3 turns";
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
