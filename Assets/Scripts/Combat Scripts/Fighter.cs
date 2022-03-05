using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public abstract class Fighter : MonoBehaviour
{
    public int maxHp = 0;
    public int currentHp;
    public float defense = 10;
    public bool unconscious = false;

    public string attack1name = "none";
    public string attack2name = "none";

    public string attack1desc = "none";
    public string attack2desc = "none";

    public AttackType attack1type = AttackType.SingleTarget;
    public AttackType attack2type = AttackType.SingleTarget;

    //function executes after attack and target are selected
    //targets are who the attack hits
    //return value is result of attack to print
    public Func<Fighter[], string> attack1execute;
    public Func<Fighter[], string> attack2execute;

    public Attack attack1;
    public Attack attack2;
    public Attack[] attacks;

    public float dmgMult = 1;
    public int dmgMod = 0;

    private Vector3 originalEulerAngles;

    public HealthBar healthBar = null;

    // Start is called before the first frame update
    void Start()
    {
        this.currentHp = this.maxHp;
        /*if (this.healthBar != null)
        {
            this.healthBar.maxValue = this.maxHp;
        }*/

        originalEulerAngles = this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.healthBar != null) {
            healthBar.UpdateHealthBar();
        }

        if (unconscious)
        {
            
        }
    }
    
    public void Damage(int hp)
    {
        this.currentHp -= hp;
        if (this.currentHp <= 0)
        {
            unconscious = true;
            this.currentHp = 0;
            this.transform.eulerAngles = this.originalEulerAngles + new Vector3(0, 0, 90);
        }
        else
        {
            unconscious = false;
            this.transform.eulerAngles = this.originalEulerAngles;
        }

        if (this.currentHp > maxHp)
        {
            this.currentHp = maxHp;
        }
    }
}
