using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SaveData.Restart();
        SaveData.Load();
        SceneManager.LoadScene("Intro Dialogue");
    }

    public void ContinueGame()
    {
        SaveData.Load();
        if (PlayerPrefs.GetInt("tournamentStarted", 0) == 1) {
            SceneManager.LoadScene("Tournament Selection");
        }
        else
        {
            SceneManager.LoadScene("DateSelection");
        }
    }
}
