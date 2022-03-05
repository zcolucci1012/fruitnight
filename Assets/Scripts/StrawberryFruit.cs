using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrawberryFruit : Fruit
{
    private static int numDates = 0;

    public override void InitiateDate()
    {
        numDates++;
        SceneManager.LoadScene("Strawberry Date " + numDates);
    }
}
