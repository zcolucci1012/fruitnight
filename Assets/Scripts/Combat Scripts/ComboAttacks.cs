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

    private Attack blueberryBanana = new Attack("Feeling Blue",
    "Banana and Blueberry transfer the burden of knowledge to one opponent.\nThey feel so burdened, they can’t do anything for two rounds of combat.",
    AttackType.SingleTarget,
    targets => 
    {
        string msg = "Blueberry and Banana use feeling blue!\n";
        int roll = UnityEngine.Random.Range(1, 20);
        foreach (Fighter f in targets)
        {
             if (f.defense <= roll) {
                    f.turnsFrozen += 2;
                    msg += "It hits " + f.name + " and freezes them in combat.";
             } else {
                msg += "It misses " + f.name;
             }
        }

        return msg;
    });

    private Attack lemonBanana = new Attack("Lemon Twist",
    "Banana riles Lemon up with talk about silverware, and lemon goes on a rampage. Deals 6 points of damage to one target, and lowers their defense by 1 pt for 2 turns.",
    AttackType.SingleTarget,
    targets => 
    {
        string msg = "Lemon and Banana use lemon twist!\n";
        int roll = UnityEngine.Random.Range(1, 20);
        foreach (Fighter f in targets)
        {
             if (f.defense <= roll) {
                    f.Damage(6);
                    f.Defense(1, 2);
                    msg += "It hits " + f.name + " and does 6 points of damage and lowers their defense by 1 point.";
             } else {
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
        } else if (f1 is Banana && f2 is BlueberryFighter ||
            f2 is Banana && f1 is BlueberryFighter) {
                return blueberryBanana;
        }else if (f1 is Banana && f2 is LemonFighter ||
            f2 is Banana && f1 is LemonFighter) {
                return lemonBanana;
        }
        return null;
    }
}
