using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerbalAttacks : MonoBehaviour
{
    public string generalComplimentMsg = "You're doing great!";
    public string generalInsultMsg = "You suck!";
    public string strawberryComplimentMsg = "Placeholder Message";
    public string strawberryInsultMsg = "Placeholder Message";
    public string blueberryComplimentMsg = "Placeholder Message";
    public string blueberryInsultMsg = "Placeholder Message";
    public string lemonComplimentMsg = "Placeholder Message";
    public string lemonInsultMsg = "Placeholder Message";
    public string blackberryComplimentMsg = "Placeholder Message";
    public string blackberryInsultMsg = "Placeholder Message";
    public string tomatoComplimentMsg = "Placeholder Message";
    public string tomatoInsultMsg = "Placeholder Message";

    private Attack strawberryCompliment;
    private Attack strawberryInsult;
    private Attack blueberryCompliment;
    private Attack blueberryInsult;
    private Attack lemonCompliment;
    private Attack lemonInsult;
    private Attack blackberryCompliment;
    private Attack blackberryInsult;
    private Attack tomatoCompliment;
    private Attack tomatoInsult;

    public void Awake()
    {
        strawberryCompliment = new Attack("Compliment Strawberry",
        "Compliment Strawberry",
        AttackType.AllyTarget,
        targets =>
        {
            string msg = strawberryComplimentMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.strawberryVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalComplimentMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });

        strawberryInsult = new Attack("Insult Strawberry",
        "Insult Strawberry",
        AttackType.SingleTarget,
        targets =>
        {
            string msg = strawberryInsultMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.strawberryVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalInsultMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });

        blueberryCompliment = new Attack("Compliment Blueberry",
        "Compliment Blueberry",
        AttackType.AllyTarget,
        targets =>
        {
            string msg = blueberryComplimentMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.blueberryVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalComplimentMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });

        blueberryInsult = new Attack("Insult blueberry",
        "Insult blueberry",
        AttackType.SingleTarget,
        targets =>
        {
            string msg = blueberryInsultMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.blueberryVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalInsultMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });

        lemonCompliment = new Attack("Compliment lemon",
        "Compliment lemon",
        AttackType.AllyTarget,
        targets =>
        {
            string msg = lemonComplimentMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.lemonVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalComplimentMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });

        lemonInsult = new Attack("Insult lemon",
        "Insult lemon",
        AttackType.SingleTarget,
        targets =>
        {
            string msg = lemonInsultMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.lemonVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalInsultMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });

        blackberryCompliment = new Attack("Compliment blackberry",
        "Compliment blackberry",
        AttackType.AllyTarget,
        targets =>
        {
            string msg = blackberryComplimentMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.blackberryVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalComplimentMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });

        blackberryInsult = new Attack("Insult blackberry",
        "Insult blackberry",
        AttackType.SingleTarget,
        targets =>
        {
            string msg = blackberryInsultMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.blackberryVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalInsultMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });

        tomatoCompliment = new Attack("Compliment tomato",
        "Compliment tomato",
        AttackType.AllyTarget,
        targets =>
        {
            string msg = tomatoComplimentMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.tomatoVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalComplimentMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });

        tomatoInsult = new Attack("Insult tomato",
        "Insult tomato",
        AttackType.SingleTarget,
        targets =>
        {
            string msg = tomatoInsultMsg + "\n";
            foreach (Fighter f in targets)
            {
                if (RelationshipScore.tomatoVerbal)
                {
                    // Do effects
                    msg += "Add some effect text here";
                }
                else
                {
                    msg = generalInsultMsg + "\nIt was not very effective...";
                }
            }

            return msg;
        });
    }

    public Attack VerbalAttack(Fighter f, bool compliment)
    {
        if (f is Strawberry)
        {
            return compliment ? strawberryCompliment : strawberryInsult;
        }
        else if (f is BlueberryFighter)
        {
            return compliment ? blueberryCompliment : blueberryInsult;
        }
        else if (f is LemonFighter)
        {
            return compliment ? lemonCompliment : lemonInsult;
        }
        /* Uncomment when these fighters are added
         * else if (f is BlackberryFighter)
        {
            return compliment ? blackberryCompliment : blackberryInsult;
        }
        else if (f is TomatoFighter)
        {
            return compliment ? tomatoCompliment : tomatoInsult;
        }*/
        return null;
    }
}
