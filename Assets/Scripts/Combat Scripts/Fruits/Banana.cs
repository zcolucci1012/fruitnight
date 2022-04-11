using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Banana : Fighter
{
    private void Awake()
    {
        this.attack1execute = targets =>
        {
            return Hit(targets[0], 4).msg;
        };

        this.attack2execute = targets =>
        {
            string msg = "";
            foreach (Fighter f in targets)
            {
                msg += Hit(f, 2).msg + "\n";
            }
            return msg;
        };

        this.attack3execute = targets =>
        {
            int healing = -targets[0].Damage(-2);
            return "Banana heals " + targets[0].name + " for " + healing + " HP";
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
        this.attack3 = new Attack(this.attack3name, this.attack3desc, this.attack3type, this.attack3execute);
    }
}
