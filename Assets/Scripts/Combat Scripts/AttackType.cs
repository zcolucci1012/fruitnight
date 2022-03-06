using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Enumeration describing attack type: currently can be single target, all enemy targets, or ally target

public enum AttackType {
    SingleTarget,
    MultiTarget,
    AllyTarget,
    MultiAllyTarget
}
