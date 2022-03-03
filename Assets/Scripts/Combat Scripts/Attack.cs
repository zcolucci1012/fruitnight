using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Attack
{
    public string attackName;
    public string description;
    public AttackType type;
    public Func<Fighter[], string> execute;

    public Attack(string attackName, string description, AttackType type, Func<Fighter[], string> execute)
    {
        this.attackName = attackName;
        this.description = description;
        this.type = type;
        this.execute = execute;
    }
}
