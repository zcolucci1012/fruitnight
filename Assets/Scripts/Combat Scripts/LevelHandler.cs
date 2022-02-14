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
    string description = "";
    bool selectingTarget = false;
    string currentAttack = "";
    string currentAttackName = "";
    AttackType currentAttackType = AttackType.SingleTarget;

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
        if (selectingTarget && turn < players.Length)
        {
            SelectTarget();
        }
        else if (turn >= players.Length)
        {
            EnemyAttack();
            turn++;
            if (turn >= entities.Count)
            {
                turn = 0;
            }
        }
        else
        {
            PickAttack();
        }

        descriptionText.GetComponent<Text>().text = description;
    }

    void EnemyAttack()
    {

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
        selectingTarget = true;
        currentAttack = "player1attack1";
        currentAttackName = players[0].attack1name;
        currentAttackType = players[0].attack1type;
        
    }

    public void Player1Attack2()
    {
        selectingTarget = true;
        currentAttack = "player1attack2";
        currentAttackName = players[0].attack2name;
        currentAttackType = players[0].attack2type;
    }

    public void Player2Attack1()
    {
        selectingTarget = true;
        currentAttack = "player2attack1";
        currentAttackName = players[1].attack1name;
        currentAttackType = players[1].attack1type;
    }

    public void Player2Attack2()
    {
        selectingTarget = true;
        currentAttack = "player2attack2";
        currentAttackName = players[1].attack2name;
        currentAttackType = players[1].attack2type;
    }

    public void Hovering(int n)
    {
        switch (n)
        {
            case 0:
                description = players[0].attack1desc;
                player1Attack1Button.GetComponentInChildren<Text>().text =
                    "> " + players[0].attack1name;
                break;
            case 1:
                description = players[0].attack2desc;
                player1Attack2Button.GetComponentInChildren<Text>().text =
                    "> " + players[0].attack2name;
                break;
            case 2:
                description = players[1].attack1desc;
                player2Attack1Button.GetComponentInChildren<Text>().text =
                    "> " + players[1].attack1name;
                break;
            case 3:
                description = players[1].attack2desc;
                player2Attack2Button.GetComponentInChildren<Text>().text =
                    "> " + players[1].attack2name;
                break;
            default:
                break;
        }
    }

    public void SelectTarget()
    {
        if (currentAttackType == AttackType.AllyTarget)
        {
            description = currentAttackName + ":\nSelect ally target";
            for (int i = 0; i < players.Length; i++)
            {
                if (i != turn)
                {
                    players[i].GetComponent<Button>().enabled = true;
                }
            }
        }
        else if (currentAttackType == AttackType.SingleTarget)
        {
            description = currentAttackName + ":\nSelect enemy target";
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Button>().enabled = true;
            }
        } else if (currentAttackType == AttackType.MultiTarget)
        {
            SelectedTarget(enemies);
        }
    }

    public void SelectedTarget(Fighter target)
    {
        switch (currentAttack)
        {
            case "player1attack1":
                description = players[0].Attack1(new Fighter[] { target });
                break;
            case "player1attack2":
                description = players[0].Attack2(new Fighter[] { target });
                break;
            case "player2attack1":
                description = players[1].Attack1(new Fighter[] { target });
                break;
            case "player2attack2":
                description = players[1].Attack2(new Fighter[] { target });
                break;
            default:
                break;
        }

        selectingTarget = false;
        turn++;
        foreach (Fighter e in entities)
        {
            e.GetComponent<Button>().enabled = false;
        }
    }

    public void SelectedTarget(Fighter[] targets)
    {
        switch (currentAttack)
        {
            case "player1attack1":
                description = players[0].Attack1(targets);
                break;
            case "player1attack2":
                description = players[0].Attack2(targets);
                break;
            case "player2attack1":
                description = players[1].Attack1(targets);
                break;
            case "player2attack2":
                description = players[1].Attack2(targets);
                break;
            default:
                break;
        }

        selectingTarget = false;
        turn++;
        foreach (Fighter e in entities)
        {
            e.GetComponent<Button>().enabled = false;
        }
    }

    public void ExitHover()
    {
        player1Attack1Button.GetComponentInChildren<Text>().text =
            players[0].attack1name;
        player1Attack2Button.GetComponentInChildren<Text>().text =
            players[0].attack2name;

        player2Attack1Button.GetComponentInChildren<Text>().text =
            players[1].attack1name;
        player2Attack2Button.GetComponentInChildren<Text>().text =
            players[1].attack2name;

        description = "";
    }
}
