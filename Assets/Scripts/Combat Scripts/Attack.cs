using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack : MonoBehaviour
{
    public string attackName;
    public string description;
    public AttackType type;

    public Attack(string attackName, string description, AttackType type, Func<string> execute)
    {
        this.attackName = attackName;
        this.description = description;
        this.type = type;
    }
}
