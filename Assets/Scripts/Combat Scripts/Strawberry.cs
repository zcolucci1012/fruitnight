using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Fighter
{

    public override string Attack1(Fighter[] targets)
    {
        targets[0].hp -= 4;
        return "Strawberry attacks " + targets[0].name + " with " + attack1name;
    }

    public override string Attack2(Fighter[] targets)
    {
        return "Strawberry attacks " + targets[0].name + " with " + attack2name;
    }
}
