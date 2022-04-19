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
        SceneManager.LoadScene("DateSelection");
    }
}
