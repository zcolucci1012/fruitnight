using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttacks : MonoBehaviour
{

    void ComboAttack(Fighter f1, Fighter f2)
    {
        if (f1 is Banana && f2 is Strawberry ||
            f2 is Banana && f1 is Strawberry)
        {

        }
    }
}
