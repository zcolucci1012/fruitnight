using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapEmotion : MonoBehaviour
{

    public List<Sprite> emotions;

    public void swapEmotion(string emotion)
    {
        for (int i = 0; i < emotions.Count; i++)
        {
            if (emotions[i].name.Contains(emotion))
            {
                // set new picture
                this.GetComponent<SpriteRenderer>().sprite = emotions[i];
                break;
            }
        }
    }

  
}
