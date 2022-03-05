using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueberryFruit : Fruit
{
    private static int numDates = 0;

    public override void InitiateDate()
    {
        numDates++;
        SceneManager.LoadScene("Blueberry Date " + numDates);
    }
}
