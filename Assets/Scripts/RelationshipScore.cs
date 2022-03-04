using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipScore : MonoBehaviour
{

    public static int strawberryScore = 0;
    public static int blueberryScore = 0;
    public static int lemonScore = 0;

    public void changeScore(string name, int score)
    {
        if (name.Equals("Strawberry"))
        {
            strawberryScore += score;
        }
        else if (name.Equals("Blueberry"))
        {
            blueberryScore += score;
        }
        else if (name.Equals("Lemon"))
        {
            lemonScore += score;
        }

        
        Debug.Log("strawberryScore: " + strawberryScore);
        Debug.Log("blueberryScore: " + blueberryScore);
        Debug.Log("lemonScore: " + lemonScore);
        
    }

}
