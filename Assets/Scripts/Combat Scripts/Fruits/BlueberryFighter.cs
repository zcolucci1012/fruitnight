using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueberryFighter : Fighter
{

    public override string Compliment() {
        if (RelationshipScore.blueberryVerbal) {
            // distracts them for a turn
            
            return "'Hey Blueberry, we never quite found out what Caut Ion meant, did we? I'll find out for you!'\nBlueberry scoffs at the thought of someone else investigating instead of him, taking no effect from your comment.";
        } else {
            return ineffectiveCompliment;
        }
    }

    public override string Insult() {
        if (RelationshipScore.blueberryVerbal) {
            this.Freeze(2);
            return "'Elderberry is watching, Blueberry. Are you sure you're at the top of your game? It'd be best to read up on your opponent for a while.'\nBlueberry panics, reading instead of fighting for the next couple turns.";
        } else {
            return ineffectiveInsult;
        }
    }

    private void Awake()
    {   
        // Sugar Blast
        this.attack1execute = targets =>
        {
            AttackResult result = Hit(targets[0], 3, this.attack1name);
            string msg = result.msg;
            if (result.hit)
            {
                targets[0].Defense(-2, 2);
                msg += "\n" + targets[0].name + "\'s defense lowers by 3 PTS";
            }
            return msg;
        };

        // 
        this.attack2execute = targets =>
        {
            string msg = "";
            foreach (Fighter target in targets) {
                if (target is BlueberryFighter) {
                    target.Defense(3, 3);
                    msg += "Blueberry raises their own defense by 3 PTS for 2 turns. \n";
                } else {
                    target.Defense(2, 2);
                    msg += "Blueberry raises " + target.name + "'s defense by 2 PTS for 2 turns. \n";
                } 
            }
            return msg;
        };

        // removes ability to heal
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
