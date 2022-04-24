using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TournamentFightPreviewManager : MonoBehaviour
{
    public Image Ally1Image;
    public Image Ally2Image;
    public Image Opponent1Image;
    public Image Opponent2Image;


    // Start is called before the first frame update
    void Start()
    {
        Ally1Image.sprite = TournamentManager.FighterSprites[0];
        Ally2Image.sprite = TournamentManager.FighterSprites[1];
        Opponent1Image.sprite = TournamentManager.FighterSprites[2];
        Opponent2Image.sprite = TournamentManager.FighterSprites[3];
    }

    public void StartCombat()
    {
        SceneManager.LoadScene("TournamentCombat");
    }
}
