using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonFighter : Fighter
{

    public override string Compliment() {
        if (RelationshipScore.lemonVerbal) {
            // attack and defense drop
            this.dmgMod += -1;
            this.Defense(-3, 2);
            return "'You know Lemon, I think you've done a really great job so far. Lime would be proud of you.'\nLemon is taken aback by your kindness. Their defense drops by 3 pts, and their attacks do 1HP less damage";
        } else {
            return ineffectiveCompliment;
        }
    }

    public override string Insult() {
        if (RelationshipScore.lemonVerbal) {
            // attack boost
            this.dmgMod += 2;
            return "'Lemon, I can't believe you haven't been able to beat those silverware yet! What are you, weak?'\nLemon doesn't say anything back, but you swear lemon is almost turning red with rage. Its attacks are boosted by 2HP";
        } else {
            return ineffectiveInsult;
        }
    }


    private void Awake()
    {
        // Sour Power
        this.attack1execute = targets =>
        {
            return Hit(targets[0], 4, "Sour Pour").msg;
        };

        // Lemon Twist
        this.attack2execute = targets =>
        {
            AttackResult result = Hit(targets[0], 6, this.attack2name);
            string msg = result.msg;
            if (result.hit)
            {
                int selfDamage = UnityEngine.Random.Range(2, 4);
                this.Damage(selfDamage);
                msg += "\nLemon hurts themself for " + selfDamage + " hp";

            }
            return msg;
        };

        // Pep Talk
        this.attack3execute = targets =>
        {
            string msg = "";
            foreach (Fighter target in targets) {
                target.Defense(2, 3);
                if (target is LemonFighter) {
                    msg += "Lemon raises their own defense by 2 pts for 3 turns.";
                } else {
                    msg += "Lemon raises " + target.name + "'s defense by 2 pts for 3 turns. \n";
                }
            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
