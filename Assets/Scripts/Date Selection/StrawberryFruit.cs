using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrawberryFruit : Fruit
{
    public static int numDates = 0;
    public static int daysLeftUntilDateable = 0;

    private List<KitchenLocation> dateLocations = new List<KitchenLocation>{ KitchenLocation.Sink, KitchenLocation.UpperCabinet };

    public override void InitiateDate()
    {
        SceneManager.LoadScene("Strawberry Date " + numDates);
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
