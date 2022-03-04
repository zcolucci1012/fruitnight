using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strawberry : Fighter
{
    private void Awake()
    {
        this.attack1execute = targets =>
        {
            targets[0].Damage(-4);
            return "Strawberry heals " + targets[0].name + " for 4 HP";
        };

        this.attack2execute = targets =>
        {
            targets[0].dmgMult *= 1.25f;
            return "Strawberry increases " + targets[0].name + "\'s damage by 25%";
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
