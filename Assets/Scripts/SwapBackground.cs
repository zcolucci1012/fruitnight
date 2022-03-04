using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapBackground : MonoBehaviour
{

    public List<Sprite> backgrounds;
    public Sprite defaultBg;
    public Image image;

    public void swapBackground(string bg)
    {


        image.sprite = defaultBg;

        if (bg == null)
        {
            return;
        }


        foreach (Sprite sprite in backgrounds)
        {
            if (sprite.name.Equals(bg))
            {
                // set new picture
                image.sprite = sprite;
                return;
            }
        }

        

    }

  
}
