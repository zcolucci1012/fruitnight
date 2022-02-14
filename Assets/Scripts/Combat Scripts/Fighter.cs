using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fighter : MonoBehaviour
{
    public string attack1name = "none";
    public string attack2name = "none";

    public string attack1desc = "none";
    public string attack2desc = "none";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void Attack1();

    public abstract void Attack2();
}
