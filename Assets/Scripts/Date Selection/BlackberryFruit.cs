using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackberryFruit : Fruit
{
    private static int numDates = 0;
    public static int daysLeftUntilDateable = 0;

    private List<KitchenLocation> dateLocations = new List<KitchenLocation> { KitchenLocation.Stove, KitchenLocation.OvenMitten };

    public override void InitiateDate()
    {
        numDates++;
        daysLeftUntilDateable = 2;
        SceneManager.LoadScene("Blackberry Date " + numDates);
    }

    public override int SetLocation()
    {
        return (int)dateLocations[numDates];
    }
}
