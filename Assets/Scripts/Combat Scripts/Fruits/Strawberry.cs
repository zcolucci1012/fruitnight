using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Fighter
{

    public override string Compliment() {
        if (RelationshipScore.strawberryVerbal) {
            this.healingMod *= 2;
            return "'Strawberry, I know we're fighting now, but… I can tell how much you care about your partner.'\nStrawberry overflows with joy. Their healing moves double.";
        } else {
            return ineffectiveCompliment;
        }
    }

    public override string Insult() {
        if (RelationshipScore.strawberryVerbal) {
            this.Damage(4);
            return "'You sheep! You're just in this competition for your partner, think for yourself!'\nStrawberry thinks you're rude, but is still very hurt.";
        } else {
            return ineffectiveInsult;
        }
    }

    private void Awake()
    {
        this.attack1execute = targets =>
        {
            int healing = -targets[0].Damage(healingMod * -4);
            return "Strawberry heals " + targets[0].name + " for " + healing + " HP";
        };

        this.attack2execute = targets =>
        {
            targets[0].dmgMod += 2;
            FindObjectOfType<DialogueAudio>().PlayAudio("Stat Boost");
            return "Strawberry increases " + targets[0].name + "\'s damage by 2 PTS";
        };

        this.attack3execute = targets =>
        {
            return Hit(targets[0], 3, "Seems seedy").msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
