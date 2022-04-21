using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlueberryFruit : Fruit
{
    public static int numDates = 0;
    public static int daysLeftUntilDateable = 0;

    private List<KitchenLocation> dateLocations = new List<KitchenLocation> { KitchenLocation.Blender, KitchenLocation.OverheadLamp };

    public override void InitiateDate()
    {
        numDates++;
        daysLeftUntilDateable = 2;
        SceneManager.LoadScene("Blueberry Date " + numDates);
    }

    public override int SetLocation()
    {
        return (int)dateLocations[numDates];
    }
}
