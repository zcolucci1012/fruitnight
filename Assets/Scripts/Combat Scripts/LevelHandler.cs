using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelHandler : MonoBehaviour
{
    public Fighter[] players;
    public Fighter[] enemies;

    public GameObject player1Attack1Button;
    public GameObject player1Attack2Button;
    public GameObject player2Attack1Button;
    public GameObject player2Attack2Button;
    public GameObject descriptionText;

    public Color defaultColor;
    public Color grayedOut;

    List<Fighter> entities = new List<Fighter>();
    int turn = 0;
    string description;

    // Start is called before the first frame update
    void Start()
    {
        entities.AddRange(players);
        entities.AddRange(enemies);

        player1Attack1Button.GetComponentInChildren<Text>().text =
            players[0].attack1name;
        player1Attack2Button.GetComponentInChildren<Text>().text =
            players[0].attack2name;

        player2Attack1Button.GetComponentInChildren<Text>().text =
            players[1].attack1name;
        player2Attack2Button.GetComponentInChildren<Text>().text =
            players[1].attack2name;
    }

    // Update is called once per frame
    void Update()
    {
        PickAttack();

        descriptionText.GetComponent<Text>().text = description;
    }

    void PickAttack()
    {
        player1Attack1Button.GetComponent<Button>().enabled = turn == 0;
        player1Attack2Button.GetComponent<Button>().enabled = turn == 0;
        player2Attack1Button.GetComponent<Button>().enabled = turn == 1;
        player2Attack2Button.GetComponent<Button>().enabled = turn == 1;

        player1Attack1Button.GetComponent<EventTrigger>().enabled = turn == 0;
        player1Attack2Button.GetComponent<EventTrigger>().enabled = turn == 0;
        player2Attack1Button.GetComponent<EventTrigger>().enabled = turn == 1;
        player2Attack2Button.GetComponent<EventTrigger>().enabled = turn == 1;

        player1Attack1Button.GetComponent<Image>().color = turn == 0 ? defaultColor : grayedOut;
        player1Attack2Button.GetComponent<Image>().color = turn == 0 ? defaultColor : grayedOut;
        player2Attack1Button.GetComponent<Image>().color = turn == 1 ? defaultColor : grayedOut;
        player2Attack2Button.GetComponent<Image>().color = turn == 1 ? defaultColor : grayedOut;
    }

    public void Player1Attack1()
    {
        players[0].Attack1();
    }

    public void Player1Attack2()
    {
        players[0].Attack2();
    }

    public void Player2Attack1()
    {
        players[1].Attack1();
    }

    public void Player2Attack2()
    {
        players[1].Attack2();
    }

    public void UpdateDescription(int button)
    {
        switch (button)
        {
            case 0:
                description = players[0].attack1desc;
                break;
            case 1:
                description = players[0].attack2desc;
                break;
            case 2:
                description = players[1].attack1desc;
                break;
            case 3:
                description = players[1].attack2desc;
                break;
            default:
                break;
        }
    }
}
