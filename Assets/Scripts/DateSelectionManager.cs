using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DateSelectionManager : MonoBehaviour
{
    public GameObject KitchenBackground;
    public GameObject TableBackground;
    public GameObject BlenderBackground;
    public GameObject SinkBackground;

    public StrawberryFruit strawberry;
    public BlueberryFruit blueberry;
    public LemonFruit lemon;

    private List<Fruit> fruits = new List<Fruit>(); // Index relates to location on screen
                                // 0: Table
                                // 1: Blender
                                // 2: Sink

    // Start is called before the first frame update
    void Start()
    {
        //strawberry = GetComponent<StrawberryFruit>();
        //blueberry = GetComponent<BlueberryFruit>();
        //lemon = GetComponent<LemonFruit>();
        fruits.Add(strawberry);
        fruits.Add(blueberry);
        fruits.Add(lemon);

        KitchenBackground.transform.Find("TableSprite").GetComponent<Image>().sprite = fruits[0].sprite;
        KitchenBackground.transform.Find("BlenderSprite").GetComponent<Image>().sprite = fruits[1].sprite;
        KitchenBackground.transform.Find("SinkSprite").GetComponent<Image>().sprite = fruits[2].sprite;
    }

    // uses Fisher-Yates Shuffle algorithm
    public void ShuffleFruitLocations()
    {
        System.Random _random = new System.Random();
        Fruit temp;
        int n = fruits.Count;

        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(_random.NextDouble() * (n - i));
            temp = fruits[r];
            fruits[r] = fruits[i];
            fruits[i] = temp;
        }
    }

    public void TransitionToTable()
    {
        fruits[0].InitiateDate();
        //KitchenBackground.SetActive(false);
        //TableBackground.SetActive(true);

        //TableBackground.transform.Find("Sprite").GetComponent<Image>().sprite = fruits[0].sprite;
    }

    public void TransitionToBlender()
    {
        fruits[1].InitiateDate();
        //KitchenBackground.SetActive(false);
        //BlenderBackground.SetActive(true);

        //BlenderBackground.transform.Find("Sprite").GetComponent<Image>().sprite = fruits[1].sprite;
    }

    public void TransitionToSink()
    {
        fruits[2].InitiateDate();
        //KitchenBackground.SetActive(false);
        //SinkBackground.SetActive(true);

        //SinkBackground.transform.Find("Sprite").GetComponent<Image>().sprite = fruits[2].sprite;
    }
}
