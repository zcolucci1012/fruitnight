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

    // public Sprite Strawberry;
    // public Sprite Blueberry;
    // public Sprite Lemon;

    public List<Sprite> fruits; // Index relates to location on screen
                                // 0: Table
                                // 1: Blender
                                // 2: Sink

    // Start is called before the first frame update
    void Start()
    {
        KitchenBackground.transform.Find("TableSprite").GetComponent<Image>().sprite = fruits[0];
        KitchenBackground.transform.Find("BlenderSprite").GetComponent<Image>().sprite = fruits[1];
        KitchenBackground.transform.Find("SinkSprite").GetComponent<Image>().sprite = fruits[2];
    }

    // uses Fisher-Yates Shuffle algorithm
    public void ShuffleFruitLocations()
    {
        System.Random _random = new System.Random();
        Sprite temp;
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
        KitchenBackground.SetActive(false);
        TableBackground.SetActive(true);

        TableBackground.transform.Find("Sprite").GetComponent<Image>().sprite = fruits[0];
    }

    public void TransitionToBlender()
    {
        KitchenBackground.SetActive(false);
        BlenderBackground.SetActive(true);

        BlenderBackground.transform.Find("Sprite").GetComponent<Image>().sprite = fruits[1];
    }

    public void TransitionToSink()
    {
        KitchenBackground.SetActive(false);
        SinkBackground.SetActive(true);

        SinkBackground.transform.Find("Sprite").GetComponent<Image>().sprite = fruits[2];
    }
}
