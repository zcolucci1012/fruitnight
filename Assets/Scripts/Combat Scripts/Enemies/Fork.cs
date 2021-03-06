using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fork : Fighter
{

    public override string Compliment()
    {
        // DO SOMETHING
        this.Damage(-1);
        return "'Fork, I know we've had our differences, but I think you're neat.'\nFork's inpenetrable demeanor seems to break a little, and the smallest hint of a smile sneaks through.";
    }

    public override string Insult()
    {
        this.dmgMod += 1;
        return "'What a crybaby, came back with their parent!'\nFork furrows their forky brow, and doubles down on their attacks.";
    }

    private void Awake()
    {
        // Stab
        this.attack1execute = targets =>
        {
            return Hit(targets[0], 4, "Silverware").msg;
        };

        // Support
        this.attack2execute = targets =>
        {
            if (targets[0].currentHp == targets[0].maxHp || targets[0].unconscious)
            {
                Debug.Log("tried to heal but didn't :D");
                return "ERROR";
            }
            string msg = "The fork heals its partner.\n";
            int healing = -targets[0].Damage(-3);
            if (healing == 0)
            {
                msg += "It can't heal!";
            }
            else
            {
                msg += "It healed its partner for " + healing + " HP";
            }
            return msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
