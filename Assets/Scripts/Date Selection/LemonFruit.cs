using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LemonFruit : Fruit
{
    public static int numDates = 0;
    public static int daysLeftUntilDateable = 0;

    private List<KitchenLocation> dateLocations = new List<KitchenLocation> { KitchenLocation.Drawer, KitchenLocation.RightTable };

    public override void InitiateDate()
    {
        SceneManager.LoadScene("Lemon Date " + numDates);
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