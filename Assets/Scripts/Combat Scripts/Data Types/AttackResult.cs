using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackResult
{
    public bool hit;
    public int dmg;
    public string msg;

    public AttackResult(bool hit, int dmg, string msg)
    {
        this.hit = hit;
        this.dmg = dmg;
        this.msg = msg;
    }
}
