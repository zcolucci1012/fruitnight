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
    public GameObject comboAttackButton;
    public GameObject descriptionText;

    public Color defaultColor;
    public Color grayedOut;

    List<Fighter> entities = new List<Fighter>();
    int turn = 0;
    string description = "";
    bool selectingTarget = false;
    bool enemyAttacking = false;
    string currentAttack = "";
    string currentAttackName = "";
    AttackType currentAttackType = AttackType.SingleTarget;

    // Start is called before the first frame update
    void Start()
    {
        //populate entities array with all entities, players first, then enemies
        entities.AddRange(players);
        entities.AddRange(enemies);

        //set button names to names of attacks
        player1Attack1Button.GetComponentInChildren<Text>().text =
            players[0].attack1name;
        player1Attack2Button.GetComponentInChildren<Text>().text =
            players[0].attack2name;

        player2Attack1Button.GetComponentInChildren<Text>().text =
            players[1].attack1name;
        player2Attack2Button.GetComponentInChildren<Text>().text =
            players[1].attack2name;

        comboAttackButton.GetComponentInChildren<Text>().text =
            GetComponent<ComboAttacks>().ComboAttack(players[0], players[1]).attackName;
    }

    // Update is called once per frame
    void Update()
    {
        if (turn >= entities.Count)
        {
            turn = 0;
        }
        //skip turn if unconcsious
        if (entities[turn].unconscious)
        {
            turn++;
        }
        //checks if player is selecting a target, and if its a player's turn
        if (selectingTarget && turn < players.Length)
        {
            SelectTarget();
        }
        //if enemy's turn, play enemy attack after 2 seconds
        else if (turn >= players.Length)
        {
            if (!enemyAttacking)
            {
                Invoke("BeginEnemyAttack", 2);
                enemyAttacking = true;
            }
        }

        //ensure attack buttons are enabled/disabled
        ToggleAttackButtons();

        descriptionText.GetComponent<Text>().text = description;
    }

    

    //toggles player 1 and 2 attacks on or off depending on turn
    void ToggleAttackButtons()
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

    //begins attack 1 for player 1
    public void Player1Attack1()
    {
        selectingTarget = true;
        currentAttack = "player1attack1";
        currentAttackName = players[0].attack1name;
        currentAttackType = players[0].attack1type;
        
    }

    //begins attack 2 for player 1
    public void Player1Attack2()
    {
        selectingTarget = true;
        currentAttack = "player1attack2";
        currentAttackName = players[0].attack2name;
        currentAttackType = players[0].attack2type;
    }

    //begins attack 1 for player 2
    public void Player2Attack1()
    {
        selectingTarget = true;
        currentAttack = "player2attack1";
        currentAttackName = players[1].attack1name;
        currentAttackType = players[1].attack1type;
    }

    //begins attack 2 for player 2
    public void Player2Attack2()
    {
        selectingTarget = true;
        currentAttack = "player2attack2";
        currentAttackName = players[1].attack2name;
        currentAttackType = players[1].attack2type;
    }

    public void ComboAttack()
    {
        selectingTarget = true;
        currentAttack = "comboAttack";
        Attack comboAttack = GetComponent<ComboAttacks>().ComboAttack(players[0], players[1]);
        currentAttackName = comboAttack.attackName;
        currentAttackType = comboAttack.type;
    }

    //displays description and adds ">" over hovered attack
    //n = attack number (1 -> p1a1, 2 -> p1a2, 3 -> p2a1, 4 -> p2a2)
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

    //enables selection of targets dependant on attack type
    //in the case of a multi-target attack, executes the attack on all targets regardless
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

    //executes current attack on selected target
    //changes description based on attack result
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

        NextTurn();
    }

    //overloaded for multiple targets
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

        NextTurn();
    }

    //stops attack selection, increments turn
    //reveals if entity is unconscious
    public void NextTurn()
    {
        selectingTarget = false;
        turn++;
        for (int i = 0; i < entities.Count; i++)
        {
            entities[i].GetComponent<Button>().enabled = false;
            if (entities[i].unconscious || entities[i].hp <= 0)
            {
                description += "\n" + entities[i].name + " has fallen unconscious!";
            }
        }

        ToggleAttackButtons();
    }

    
    //return description back to normal after hovering
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

    // ENEMY ATTACK: three steps, begin attack, attack, end attack

    //updates description, starts attack after 2 seconds
    void BeginEnemyAttack()
    {
        description = entities[turn].name + " is attacking...";
        Invoke("EnemyAttack", 2);
    }

    //exectues attack, updates description, ends after 5 seconds
    void EnemyAttack()
    {
        Fighter enemy = entities[turn];

        int attack = Random.Range(0, 2);
        switch (attack)
        {
            case 0:
                if (enemy.attack1type == AttackType.SingleTarget)
                {
                    Fighter player = players[Random.Range(0, players.Length)];
                    description = enemy.Attack1(new Fighter[] { player });
                }
                else if (enemy.attack1type == AttackType.AllyTarget)
                {
                    Fighter otherEnemy = null;
                    do
                    {
                        otherEnemy = enemies[Random.Range(0, enemies.Length)];
                    } while (enemy == otherEnemy);

                    description = enemy.Attack1(new Fighter[] { otherEnemy });
                }
                else if (enemy.attack1type == AttackType.MultiTarget)
                {
                    description = enemy.Attack1(players);
                }
                break;
            case 1:
                if (enemy.attack2type == AttackType.SingleTarget)
                {
                    Fighter player = players[Random.Range(0, players.Length)];
                    description = enemy.Attack2(new Fighter[] { player });
                }
                else if (enemy.attack2type == AttackType.AllyTarget)
                {
                    Fighter otherEnemy = null;
                    do
                    {
                        otherEnemy = enemies[Random.Range(0, enemies.Length)];
                    } while (enemy == otherEnemy);

                    description = enemy.Attack2(new Fighter[] { otherEnemy });
                }
                else if (enemy.attack2type == AttackType.MultiTarget)
                {
                    description = enemy.Attack2(players);
                }
                break;

        }

        Invoke("EndAttack", 5);
    }

    //ends attack by incrememting turn and stopping enemy attack
    void EndAttack()
    {
        turn++;
        enemyAttacking = false;
    }
}
