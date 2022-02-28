using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : Fighter
{
    public override string Attack1(Fighter[] targets)
    {
        targets[0].hp -= 4;
        return "The training dummy attacked " + targets[0].name + " for 4 damage!";
    }

    public override string Attack2(Fighter[] targets)
    {
        targets[0].hp -= 4;
        return "The training dummy attacked " + targets[0].name + " for 4 damage!";
    }
}
