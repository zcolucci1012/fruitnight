using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//contains a list of combo attacks for each character
public class ComboAttacks : MonoBehaviour
{
    private Attack bananaStrawberry = new Attack("lunchbox launch", 
        "strawberry throws banana at the enemies, dealing 3 damage and reducing their damage by 2", 
        AttackType.MultiTarget,
        targets =>
        {
            string msg = "Strawberry and Banana use lunchbox launch!\n";
            int roll = UnityEngine.Random.Range(1, 20);
            foreach (Fighter f in targets)
            {
                if (f.defense <= roll)
                {
                    f.Damage(3);
                    f.dmgMod = -2;
                    msg += "It hits " + f.name + " for 3 damage, reducing damage by 2";
                }
                else
                {
                    msg += "It misses " + f.name;
                }
            }

            return msg;
        });

    //gets a combo attack based on fighters in play
    public Attack ComboAttack(Fighter f1, Fighter f2)
    {
        if (f1 is Banana && f2 is Strawberry ||
            f2 is Banana && f1 is Strawberry)
        {
            return bananaStrawberry;
        }
        return null;
    }
}
