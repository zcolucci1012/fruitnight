using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public GameObject winText;
    public GameObject credits;
    public GameObject mainMenuButton;

    private void Start()
    {
        //any rewards would go here (extra costumes :) )
    }

    public void AnimateWinText(Color color)
    {
        winText.GetComponent<Animation>().Play("MoveText");
        winText.GetComponent<Text>().color = color;
        winText.GetComponent<AudioSource>().Play();
    }

    public void AnimateScrollText(Color color)
    {
        credits.GetComponent<Animation>().Play("ScrollText");
        credits.GetComponent<Text>().color = color;
    }

    public void DisplayMainMenu()
    {
        mainMenuButton.SetActive(true);
    }

    public void MainMenu()
    {
        SaveData.Restart();
        SceneManager.LoadScene("MainMenu");
    }
}
