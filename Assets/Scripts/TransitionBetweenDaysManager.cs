using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TransitionBetweenDaysManager : MonoBehaviour
{
    public Image strawberryRelativeRelationshipImage;
    public Image blueberryRelativeRelationshipImage;
    public Image lemonRelativeRelationshipImage;
    public Image blackberryRelativeRelationshipImage;
    public Image tomatoRelativeRelationshipImage;

    public Text strawberryRelationshipText;
    public Text blueberryRelationshipText;
    public Text lemonRelationshipText;
    public Text blackberryRelationshipText;
    public Text tomatoRelationshipText;

    public Sprite doubleUpArrow;
    public Sprite singleUpArrow;
    public Sprite doubleDownArrow;
    public Sprite singleDownArrow;
    public Sprite noChange;

    private static int strawberryPreviousRelationshipScore = 0;
    private static int blueberryPreviousRelationshipScore = 0;
    private static int lemonPreviousRelationshipScore = 0;
    private static int blackberryPreviousRelationshipScore = 0;
    private static int tomatoPreviousRelationshipScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetRelativeRelationshipImages();   
    }

    public void StartNextDay()
    {
        Debug.Log("START THE NEXT DAY GOSH DARN");
        SceneManager.LoadScene("DateSelection");
    }

    private void SetRelativeRelationshipImages()
    {
        SetRelationshipImage(RelationshipScore.strawberryScore - strawberryPreviousRelationshipScore, strawberryRelativeRelationshipImage, strawberryRelationshipText, "Strawberry");
        SetRelationshipImage(RelationshipScore.blueberryScore - blueberryPreviousRelationshipScore, blueberryRelativeRelationshipImage, blueberryRelationshipText, "Blueberry");
        SetRelationshipImage(RelationshipScore.lemonScore - lemonPreviousRelationshipScore, lemonRelativeRelationshipImage, lemonRelationshipText, "Lemon");
        SetRelationshipImage(RelationshipScore.blackberryScore - blackberryPreviousRelationshipScore, blackberryRelativeRelationshipImage, blackberryRelationshipText, "Blackberry");
        SetRelationshipImage(RelationshipScore.tomatoScore - tomatoPreviousRelationshipScore, tomatoRelativeRelationshipImage, tomatoRelationshipText, "Tomato");

        strawberryPreviousRelationshipScore = RelationshipScore.strawberryScore;
        blueberryPreviousRelationshipScore = RelationshipScore.blueberryScore;
        lemonPreviousRelationshipScore = RelationshipScore.lemonScore;
        blackberryPreviousRelationshipScore = RelationshipScore.blackberryScore;
        tomatoPreviousRelationshipScore = RelationshipScore.tomatoScore;
    }

    private void SetRelationshipImage(int delta, Image image, Text text, string name)
    {
        if (delta < -2)
        {
            image.sprite = doubleDownArrow;
            text.text = name + " had an awful time with you. You said some things that they really didn't want to hear.";
        }
        else if (delta < 0)
        {
            image.sprite = singleDownArrow;
            text.text = name + " didn't have much fun with you. You should be more careful with what you say to them.";
        }
        else if (delta > 2)
        {
            image.sprite = doubleUpArrow;
            text.text = name + " had an amazing time with you. They can't wait to go on another date with you.";
        }
        else if (delta > 0)
        {
            image.sprite = singleUpArrow;
            text.text = name + " had some fun hanging out with you. They wouldn't mind going on another date with you.";
        }
        else
        {
            image.sprite = noChange;
            text.text = name + " did their own thing. Maybe you should take them out on a date to see what they're up to.";
        }
    }
}
