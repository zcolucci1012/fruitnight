using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum KitchenLocation
{
    Drawer,
    Blender,
    Sink,
    LeftTable,
    Stove,
    UpperCabinet,
    RightTable,
    OverheadLamp,
    OvenMitten,
    LowerCabinet
}

public class DateSelectionManager : MonoBehaviour
{
    public GameObject drawerLocation;
    public GameObject blenderLocation;
    public GameObject sinkLocation;
    public GameObject leftTableLocation;
    public GameObject upperCabinetLocation;
    public GameObject rightTableLocation;
    public GameObject overheadLampLocation;
    public GameObject lowerCabinetLocation;
    public GameObject ovenMittenLocation;
    public GameObject stoveLocation;

    public StrawberryFruit strawberry;
    public BlueberryFruit blueberry;
    public LemonFruit lemon;
    public BlackberryFruit blackberry;
    public TomatoFruit tomato;

    private Fruit[] fruits = new Fruit[10]; // Index relates to location on screen, see KitchenLocations Enum
    private GameObject[] locations = new GameObject[10]; // Index relates to location on screen, see KitchenLocations Enum

    public static int numDatesLeftInDay = 2;

    // Start is called before the first frame update
    void Start()
    {
        if (numDatesLeftInDay <= 0)
        {
            numDatesLeftInDay = 2;
            StrawberryFruit.daysLeftUntilDateable--;
            BlueberryFruit.daysLeftUntilDateable--;
            LemonFruit.daysLeftUntilDateable--;
            BlackberryFruit.daysLeftUntilDateable--;
            TomatoFruit.daysLeftUntilDateable--;
            SceneManager.LoadScene("TransitionBetweenDays");
        }
        else
        {
            InitializeLocationsArray();
            SetFruitLocations();
        }
    }

    private void InitializeLocationsArray()
    {
        locations[(int)KitchenLocation.Drawer] = drawerLocation;
        locations[(int)KitchenLocation.Blender] = blenderLocation;
        locations[(int)KitchenLocation.Sink] = sinkLocation;
        locations[(int)KitchenLocation.LeftTable] = leftTableLocation;
        locations[(int)KitchenLocation.UpperCabinet] = upperCabinetLocation;
        locations[(int)KitchenLocation.RightTable] = rightTableLocation;
        locations[(int)KitchenLocation.OverheadLamp] = overheadLampLocation;
        locations[(int)KitchenLocation.OvenMitten] = ovenMittenLocation;
        locations[(int)KitchenLocation.Stove] = stoveLocation;
        locations[(int)KitchenLocation.LowerCabinet] = lowerCabinetLocation;

        foreach (GameObject go in locations)
        {
            go.SetActive(false);
        }
    }

    private void SetFruitLocations()
    {
        int index;

        if (StrawberryFruit.daysLeftUntilDateable <= 0)
        {
            index = strawberry.SetLocation();
            fruits[index] = strawberry;
            locations[index].GetComponent<Image>().sprite = strawberry.sprite;
            locations[index].SetActive(true);
        }

        if (BlueberryFruit.daysLeftUntilDateable <= 0)
        {
            index = blueberry.SetLocation();
            fruits[index] = blueberry;
            locations[index].GetComponent<Image>().sprite = blueberry.sprite;
            locations[index].SetActive(true);
        }

        if (LemonFruit.daysLeftUntilDateable <= 0)
        {
            index = lemon.SetLocation();
            fruits[index] = lemon;
            locations[index].GetComponent<Image>().sprite = lemon.sprite;
            locations[index].SetActive(true);
        }

        if (BlackberryFruit.daysLeftUntilDateable <= 0)
        {
            index = blackberry.SetLocation();
            fruits[index] = blackberry;
            locations[index].GetComponent<Image>().sprite = blackberry.sprite;
            locations[index].SetActive(true);
        }

        if (TomatoFruit.daysLeftUntilDateable <= 0)
        {
            index = tomato.SetLocation();
            fruits[index] = tomato;
            locations[index].GetComponent<Image>().sprite = tomato.sprite;
            locations[index].SetActive(true);
        }
    }

    public void TransitionToDrawer()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.Drawer].InitiateDate();
    }

    public void TransitionToBlender()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.Blender].InitiateDate();
    }

    public void TransitionToSink()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.Sink].InitiateDate();
    }

    public void TransitionToLeftTable()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.LeftTable].InitiateDate();
    }

    public void TransitionToUpperCabinet()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.UpperCabinet].InitiateDate();
    }

    public void TransitionToRightTable()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.RightTable].InitiateDate();
    }

    public void TransitionToOverheadLamp()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.OverheadLamp].InitiateDate();
    }

    public void TransitionToLowerCabinet()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.LowerCabinet].InitiateDate();
    }

    public void TransitionToStove()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.Stove].InitiateDate();
    }

    public void TransitionToOvenMitten()
    {
        numDatesLeftInDay--;
        fruits[(int)KitchenLocation.OvenMitten].InitiateDate();
    }
}
