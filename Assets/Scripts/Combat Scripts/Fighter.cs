using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public int hp = 0;
    public bool unconscious = false;

    public string attack1name = "none";
    public string attack2name = "none";

    public string attack1desc = "none";
    public string attack2desc = "none";

    public AttackType attack1type = AttackType.SingleTarget;
    public AttackType attack2type = AttackType.SingleTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            unconscious = true;
        }
    }

    //return value is result of attack to print
    public abstract string Attack1(Fighter[] targets);

    public abstract string Attack2(Fighter[] targets);
}
