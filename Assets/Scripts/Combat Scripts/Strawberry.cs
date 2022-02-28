using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Fighter
{

    public override string Attack1(Fighter[] targets)
    {
        targets[0].hp += 4;
        return "Strawberry heals " + targets[0].name + " for 4 HP";
    }

    public override string Attack2(Fighter[] targets)
    {
        targets[0].dmgMod *= 1.25f;
        return "Strawberry increases " + targets[0].name + "\'s damage by 25%";
    }
}
