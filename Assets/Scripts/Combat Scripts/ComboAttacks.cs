using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


//contains a list of combo attacks for each character
public class ComboAttacks : MonoBehaviour
{
    private static Fighter fighter1;
    private static Fighter fighter2;

    private Attack bananaStrawberry = new Attack("Lunchbox Launch", 
        "Strawberry throws Banana at the enemies, dealing 3 damage and reducing their damage by 1", 
        AttackType.MultiTarget,
        targets =>
        {
            string msg = "Strawberry and Banana use lunchbox launch!\n";
            foreach (Fighter f in targets)
            {
                AttackResult result = Hit(f, 3);
                if (result.hit)
                {
                    f.dmgMod = -1;
                    msg += result.msg + " and their damage is reduced by 1";
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
                    f.turnsFrozen = 2;
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

    
    private Attack blackberryBanana = new Attack("Bittersweet",
        "All enemies take 2 damage, and Banana and Blackberry heal according to damage dealt",
        AttackType.MultiTarget,
        targets =>
        {
            int healthStolen = 0;
            string msg = "";
            foreach (Fighter f in targets)
            {
                AttackResult result = Hit(f, 2);
                healthStolen += result.dmg;
                msg += result.msg + "\n";
            }
            if (healthStolen > 0)
            {
                if (!(fighter2 is BlackberryFighter))
                {
                    Fighter temp = fighter2;
                    fighter2 = fighter1;
                    fighter1 = temp;
                }
                int f2healing = -fighter2.Damage(-(healthStolen - healthStolen / 2));
                int f1healing = -fighter1.Damage(-(healthStolen / 2));
                msg += "Blackberry and Banana heal for " + f2healing + " HP and " + f1healing + " HP respectively";
            }

            return msg;
        });
    

    //gets a combo attack based on fighters in play
    public Attack ComboAttack(Fighter f1, Fighter f2)
    {
        fighter1 = f1;
        fighter2 = f2;
        if (f1 is Banana && f2 is Strawberry ||
            f2 is Banana && f1 is Strawberry)
        {
            return bananaStrawberry;
        }
        else if (f1 is Banana && f2 is BlueberryFighter ||
          f2 is Banana && f1 is BlueberryFighter)
        {
            return blueberryBanana;
        }
        else if (f1 is Banana && f2 is LemonFighter ||
           f2 is Banana && f1 is LemonFighter)
        {
            return lemonBanana;
        }
        else if (f1 is Banana && f2 is BlackberryFighter ||
          f2 is Banana && f1 is BlackberryFighter)
        {
            return blackberryBanana;
        }
        return null;
    }

    private static AttackResult Hit(Fighter target, int dmg)
    {
        int roll = UnityEngine.Random.Range(1, 20);
        if (target.defense < roll)
        {
            int effectiveDamage = target.Damage(dmg);
            string msg = target.name + " takes " + effectiveDamage + " damage";
            if (target.unconscious)
            {
                msg += ", knocking them unconscious";
            }
            return new AttackResult(true, effectiveDamage, msg);
        }
        else
        {
            return new AttackResult(false, 0, target.name + " avoids the attack");
        }

    }
}
