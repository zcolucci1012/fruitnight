using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Fruit : MonoBehaviour
{
    public Sprite sprite;

    public abstract void InitiateDate();

    public abstract int SetLocation();
}