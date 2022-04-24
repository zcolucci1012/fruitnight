using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : Fighter
{

    private void Awake()
    {
        // Existential Crisis
        this.attack1execute = targets =>
        {
            int roll = UnityEngine.Random.Range(1, 20);
            string msg = "";
            if (roll > 7 || this.turnsStrongHit > 0)
            {
                targets[0].turnsFrozen = 1;
                FindObjectOfType<DialogueAudio>().PlayAudio("Stat Boost");
                msg = "Tomato sends " + targets[0].name + " into an existential crisis, freezing them for a turn.";
            } else {
                this.turnsFrozen = 2;
                FindObjectOfType<DialogueAudio>().PlayAudio("Tomato meh");
                msg = "It backfires, and sends Tomato into an existential crisis instead, freezing them on their next turn.";
            }
            return msg;
        };

        // Shakes Pearean Insult
        this.attack2execute = targets =>
        {
            int roll = UnityEngine.Random.Range(2, 5);
            if (this.turnsStrongHit > 0) {
                roll = 5;
            }
            AttackResult result = this.Hit(targets[0], roll, this.attack2name);
            string msg = result.msg;
            return msg;
        };

        // Writer's block
        this.attack3execute = targets =>
        {
            int roll = UnityEngine.Random.Range(3, 6);
            if (this.turnsStrongHit > 0) {
                roll = 6;
            }
            foreach (Fighter target in targets) {
                target.Defense(roll, 2);
            }
            string msg = "Tomato increases their defense and their partner's defense by " + roll + " points.";
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
