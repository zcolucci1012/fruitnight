using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttacks : MonoBehaviour
{
    public Attack bananaStrawberry;

    private void Start()
    {
        bananaStrawberry = new Attack("lunchbox launch", "strawberry throws banana at the enemies, dealing 3 damage and reducing their next attack by 2 damage", AttackType.MultiTargets, null);
    }



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
