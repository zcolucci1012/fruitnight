using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseSceneManager : MonoBehaviour
{
    public void RestartCombat()
    {
        SceneManager.LoadScene("TournamentFightPreview");
    }
}
