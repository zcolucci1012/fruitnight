using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CombatTransition : MonoBehaviour
{
    public static string fruit = "Blackberry";
    public static bool won = false;
    public Image fruitImage;
    public Image fruitRelativeRelationshipImage;
    public Image combatImage;
    public Image overallImage;
    public Text fruitRelationshipText;

    public List<Sprite> emotionSprites;

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
        SceneManager.LoadScene("DateSelection");
    }

    private void SetRelativeRelationshipImages()
    {
        int delta = -1;
        int index = -1;
        switch (fruit)
        {
            case "strawberry":
                delta = RelationshipScore.strawberryScore - strawberryPreviousRelationshipScore;
                index = 0;
                break;
            case "blueberry":
                delta = RelationshipScore.blueberryScore - blueberryPreviousRelationshipScore;
                index = 1;
                break;
            case "lemon":
                delta = RelationshipScore.lemonScore - lemonPreviousRelationshipScore;
                index = 2;
                break;
            case "blackberry":
                delta = RelationshipScore.blackberryScore - blackberryPreviousRelationshipScore;
                index = 3;
                break;
            case "tomato":
                delta = RelationshipScore.tomatoScore - tomatoPreviousRelationshipScore;
                index = 4;
                break;
        }
        SetRelationshipImage(delta + (won ? -2 : 2), this.fruitRelativeRelationshipImage, index);

        strawberryPreviousRelationshipScore = RelationshipScore.strawberryScore;
        blueberryPreviousRelationshipScore = RelationshipScore.blueberryScore;
        lemonPreviousRelationshipScore = RelationshipScore.lemonScore;
        blackberryPreviousRelationshipScore = RelationshipScore.blackberryScore;
        tomatoPreviousRelationshipScore = RelationshipScore.tomatoScore;

        SetRelationshipImage((won ? 2 : -2), this.combatImage, index);
        SetRelationshipImage(delta, this.overallImage, index);
    }

    private void SetRelationshipImage(int delta, Image relativeImage, int index)
    {
        if (delta < -2)
        {
            this.fruitImage.sprite = emotionSprites[index * 3 + 2];
            relativeImage.sprite = doubleDownArrow;
            this.fruitRelationshipText.text = "Okay, bye.";
        }
        else if (delta < 0)
        {
            this.fruitImage.sprite = emotionSprites[index * 3 + 2];
            relativeImage.sprite = singleDownArrow;
            this.fruitRelationshipText.text = "Well, I gotta go";
        }
        else if (delta > 2)
        {
            this.fruitImage.sprite = emotionSprites[index * 3 + 1];
            relativeImage.sprite = doubleUpArrow;
            this.fruitRelationshipText.text = "I had so much fun! Let's do this again sometime!";
        }
        else if (delta > 0)
        {
            this.fruitImage.sprite = emotionSprites[index * 3 + 1];
            relativeImage.sprite = singleUpArrow;
            this.fruitRelationshipText.text = "Bye! Have a nice day!";
        }
        else
        {
            this.fruitImage.sprite = emotionSprites[index * 3 + 0];
            relativeImage.sprite = noChange;
            this.fruitRelationshipText.text = "See ya around!";
        }
    }

    public void LoadNextDate()
    {
        SceneManager.LoadScene("DateSelection");
    }
}
