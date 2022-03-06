using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapEmotion : MonoBehaviour
{

    public List<Sprite> emotions;
    public Image image;

    public void swapEmotion(string speaker, string emotion)
    {

        image.sprite = null;
        image.color = new Color(255, 255, 255, 0);


        foreach (Sprite sprite in emotions)
        {
            if (sprite.name.Equals(speaker + " " + emotion))
            {
                // set new picture
                image.color = new Color(255, 255, 255, 255);
                image.sprite = sprite;
                return;
            }
        }

    }

  
}
