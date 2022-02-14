using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banana : Fighter
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override string Attack1(Fighter[] targets)
    {
        return "Banana attacks " + targets[0].name + " with " + attack1name;
    }

    public override string Attack2(Fighter[] targets)
    {
        return "Banana attacks " + targets[0].name + " with " + attack2name;
    }


}
