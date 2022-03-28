using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionBetweenDaysManager : MonoBehaviour
{
    public Image strawberryRelativeRelationshipImage;
    public Image blueberryRelativeRelationshipImage;
    public Image lemonRelativeRelationshipImage;
    public Image blackberryRelativeRelationshipImage;
    public Image tomatoRelativeRelationshipImage;

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

    private void SetRelativeRelationshipImages()
    {
        strawberryPreviousRelationshipScore = RelationshipScore.strawberryScore;
        blueberryPreviousRelationshipScore = RelationshipScore.blueberryScore;
        lemonPreviousRelationshipScore = RelationshipScore.lemonScore;
        blackberryPreviousRelationshipScore = RelationshipScore.blackberryScore;
        tomatoPreviousRelationshipScore = RelationshipScore.tomatoScore;
    }
}
