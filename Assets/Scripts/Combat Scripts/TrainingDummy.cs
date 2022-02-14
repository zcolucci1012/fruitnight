using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : Fighter
{
    public override string Attack1(Fighter[] targets)
    {
        return "Dummy attack 3";
    }

    public override string Attack2(Fighter[] targets)
    {
        return "Dummy attack 2";
    }
}
