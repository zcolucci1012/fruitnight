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
        SceneManager.LoadScene("Blueberry Date " + (numDates + 1));
    }

    public override int SetLocation()
    {
        return (int)dateLocations[numDates];
    }

    public static void EndDate()
    {
        numDates++;
        daysLeftUntilDateable = 2;
    }
}
