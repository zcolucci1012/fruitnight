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
    public int coolDown;
    public int currentCoolDown;

    public Attack(string attackName, string description, AttackType type, Func<Fighter[], string> execute)
    {
        this.attackName = attackName;
        this.description = description;
        this.type = type;
        this.execute = execute;
        this.coolDown = 0;
        this.currentCoolDown = 0;
    }

    public Attack(string attackName, string description, AttackType type, Func<Fighter[], string> execute, int coolDown, int currentCoolDown)
    {
        this.attackName = attackName;
        this.description = description;
        this.type = type;
        this.execute = execute;
        this.coolDown = coolDown;
        this.currentCoolDown = 0;
    }

    // returns if this attack can be used
    public bool canUse() {
        if (coolDown > 0) {
            return false;
        } 
        return true;
    }

    public void handleAttack(Fighter attacker, Fighter ally, Fighter[] opponents) {
        if (currentCoolDown > 0) {
            return;
        }
    }
}
