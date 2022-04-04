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
    private Attack dummyCompliment;
    private Attack dummyInsult;

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
                    msg = "'" + generalComplimentMsg + "'\n" + "\nIt's not very effective on " + f.name + ".\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
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
                    msg = "'" + generalInsultMsg + "'\n" + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
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
                    msg = "'" + generalComplimentMsg + "'\n" + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
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
                    msg = "'" + generalInsultMsg + "'\n" + "\nIt's not very effective on " + f.name +"\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
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
                    msg = "'" + generalComplimentMsg + "'\n" + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
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
                    msg = "'" + generalInsultMsg + "'\n" + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
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
                    msg = "'" + generalComplimentMsg + "'\n" + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
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
                    msg = "'" + generalInsultMsg + "'\n" + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
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
                    msg = "'" + generalComplimentMsg + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
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
                    msg = "'" + generalInsultMsg + "'\n" + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something else to say to them, but nothing comes to mind. You'll need to learn more about them.";
                }
            }

            return msg;
        });

        dummyCompliment = new Attack("Verbal attack dummy",
        "Verbal attack dummy",
        AttackType.SingleTarget,
        targets => {
            string msg = "";
            foreach (Fighter f in targets)
            {
                msg = "'" + generalComplimentMsg + "'\n" + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something to say to them, but nothing comes to mind. You'll need to learn more about them.";
            }
            return msg;
        });

        dummyInsult = new Attack("Verbal attack dummy",
        "Verbal attack dummy",
        AttackType.SingleTarget,
        targets => {
            string msg = "";
            foreach (Fighter f in targets)
            {
                msg = "'" + generalInsultMsg + "'\n" + "\nIt's not very effective on " + f.name + "\nYou rack your brain for something to say to them, but nothing comes to mind. You'll need to learn more about them.";
            }
            return msg;
        });

    }

    

    public Attack VerbalAttack(bool compliment)
    {
        return new Attack(compliment ? "Compliment" : "Insult",
        compliment ? "Compliment an ally or enemy" : "Insult an ally or enemy",
        AttackType.AnyTarget,
        targets => {
            Fighter f = targets[0];
            if (f is Strawberry)
            {
                return compliment ? strawberryCompliment.execute(targets) : strawberryInsult.execute(targets);
            }
            else if (f is BlueberryFighter)
            {
                return compliment ? blueberryCompliment.execute(targets) : blueberryInsult.execute(targets);
            }
            else if (f is LemonFighter)
            {
                return compliment ? lemonCompliment.execute(targets) : lemonInsult.execute(targets);
            }
            else if (f is BlackberryFighter)
            {
                return compliment ? blackberryCompliment.execute(targets) : blackberryInsult.execute(targets);
            } else { // handle for dummies
                return compliment ? dummyCompliment.execute(targets) : dummyInsult.execute(targets);
            }
            /* Uncomment when these fighters are added
            else if (f is TomatoFighter)
            {
                return compliment ? tomatoCompliment : tomatoInsult;
            }*/
        });
    }
}
