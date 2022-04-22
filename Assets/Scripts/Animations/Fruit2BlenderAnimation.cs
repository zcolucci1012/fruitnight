using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fruit2BlenderAnimation : MonoBehaviour
{
    public static string fruit = "tomato";

    public Image blenderColor;
    public Image fruitImage;
    private Color fruitColor;

    public Sprite[] fruitImages;

    public Color strawberryColor;
    public Color blueberryColor;
    public Color lemonColor;
    public Color blackberryColor;
    public Color tomatoColor;  

    Animation anim;
    bool started = false;
    bool done = false;
    EndGameController egc;

    private void Awake()
    {
        egc = GameObject.FindObjectOfType<EndGameController>();
        switch (fruit)
        {
            case "strawberry":
                fruitImage.sprite = fruitImages[0];
                fruitColor = strawberryColor;
                break;
            case "blueberry":
                fruitImage.sprite = fruitImages[1];
                fruitColor = blueberryColor;
                break;
            case "lemon":
                fruitImage.sprite = fruitImages[2];
                fruitColor = lemonColor;
                break;
            case "blackberry":
                fruitImage.sprite = fruitImages[3];
                fruitColor = blackberryColor;
                break;
            case "tomato":
                fruitImage.sprite = fruitImages[4];
                fruitColor = tomatoColor;
                break;
        }
        anim = GetComponent<Animation>();

        anim.PlayQueued("Stop", QueueMode.CompleteOthers);
        anim.PlayQueued("Walk", QueueMode.CompleteOthers);
        anim.PlayQueued("ShortWalk", QueueMode.CompleteOthers);
        anim.PlayQueued("Stop", QueueMode.CompleteOthers);
        anim.PlayQueued("Fruit2Jump", QueueMode.CompleteOthers);
    }

    private void Update()
    {
        if (!anim.isPlaying)
        {
            if (started && !done)
            {
                blenderColor.color = (blenderColor.color + fruitColor) / 2;
                Invoke("WinText", 2);
                done = true;
            }
            started = true;
        }
    }

    private void WinText()
    {
        egc.AnimateWinText(blenderColor.color);
        Invoke("MainMenu", 2);
    }

    private void MainMenu()
    {
        egc.DisplayMainMenu();
    }
}
