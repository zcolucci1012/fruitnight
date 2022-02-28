using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Fighter
{
    public override string Attack1(Fighter[] targets)
    {
        string msg = "Banana attacks " + targets[0].name + " with " + attack1name + "\n";
        if (targets[0].defense <= Random.Range(1, 20))
        {
            targets[0].hp -= (int)(4 * dmgMod);
            msg += "It dealt four damage";
        }
        else
        {
            msg += "It missed!";
        }

        return msg;
    }

    public override string Attack2(Fighter[] targets)
    {
        string msg = "Banana attacks with " + attack2name + "\n";
        int roll = Random.Range(1, 20);
        foreach (Fighter f in targets){
            if (f.defense <= roll)
            {
                f.hp -= (int)(2 * dmgMod);
                msg += "It hits " + f.name + " for 2 damage\n";
            }
            else
            {
                msg += "It misses " + f.name;
            }
        }
        return msg;
    }
}
