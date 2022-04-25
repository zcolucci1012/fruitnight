using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar : Fighter
{

     public override string Compliment() {
        // DO SOMETHING
        this.Damage(-2);
        return "'I bet your jam tastes great! I'd love to try some!'\nJar also thinks that their jam tastes great. They do not think even they could make banana jam taste good, though. They feel healthier.";
    }

    public override string Insult() {
        this.turnsFrozen += 1;
        return "'I can see right through you, Jar!'\nIt takes a second, but the insult finally dawns on Jar.";
    }

    private void Awake()
    {
        // Trap
        this.attack1execute = targets =>
        {
            targets[0].turnsFrozen+=1;
            FindObjectOfType<DialogueAudio>().PlayAudio("Jar");
            return "The jar traps " + targets[0].name + " for 1 turn";
        };

        // Jam
        this.attack2execute = targets =>
        {
            string msg = "";
            AttackResult result = this.Hit(targets[0], 2, "Jar");
            msg += result.msg;
            if (result.hit)
            {
                targets[0].turnsCantHeal+=1;
                msg += "\nThe jar can't heal for 1 turn";
            }
            return msg;
        };

        // Roll
        this.attack3execute = targets =>
        {
            return this.Hit(targets[0], 3, "Jar Roll").msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
