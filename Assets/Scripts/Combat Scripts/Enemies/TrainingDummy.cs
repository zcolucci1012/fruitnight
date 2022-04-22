using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainingDummy : Fighter
{
    private void Awake()
    {
        this.attack1execute = targets =>
        {
            return Hit(targets[0], 4, "Silverware").msg;
        };

        this.attack2execute = targets =>
        {
            return Hit(targets[0], 4, "Silverware").msg;
        };

        this.attack1 = new Attack(this.attack1name, this.attack1desc, this.attack1type, this.attack1execute);
        this.attack2 = new Attack(this.attack2name, this.attack2desc, this.attack2type, this.attack2execute);
    }
}
