using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipScore : MonoBehaviour
{
    public static int strawberryScore = 0;
    public static int blueberryScore = 0;
    public static int lemonScore = 0;
    public static int tomatoScore = 0;
    public static int blackberryScore = 0;


    public static bool strawberryVerbal = false;
    public static bool blueberryVerbal = false;
    public static bool lemonVerbal = false;
    public static bool tomatoVerbal = false;
    public static bool blackberryVerbal = false;

    public void changeScore(string name, int score)
    {
        switch(name)
        {
            case "Strawberry":
                strawberryScore += score;
                break;
            case "Blueberry":
                blueberryScore += score;
                break;
            case "Lemon":
                lemonScore += score;
                break;
            case "Tomato":
                tomatoScore += score;
                break;
            case "Blackberry":
                blackberryScore += score;
                break;
            default:
                break;
        }

        
        Debug.Log("strawberryScore: " + strawberryScore);
        Debug.Log("blueberryScore: " + blueberryScore);
        Debug.Log("lemonScore: " + lemonScore);
        Debug.Log("tomatoScore: " + tomatoScore);
        Debug.Log("blackberryScore: " + blackberryScore);

    }

    public void unlockVerbal(string name)
    {
        switch (name)
        {
            case "Strawberry":
                strawberryVerbal = true;
                break;
            case "Blueberry":
                blueberryVerbal = true;
                break;
            case "Lemon":
                lemonVerbal = true;
                break;
            case "Tomato":
                tomatoVerbal = true;
                break;
            case "Blackberry":
                blackberryVerbal = true;
                break;
            default:
                break;
        }
    }
}
