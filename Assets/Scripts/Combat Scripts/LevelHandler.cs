using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;

public class LevelHandler : MonoBehaviour
{
    public Fighter[] players;
    public Fighter[] enemies;

    public GameObject player1Attack1Button;
    public GameObject player1Attack2Button;
    public GameObject player1Attack3Button;
    public GameObject player1ComplimentButton;
    public GameObject player1InsultButton;
    public GameObject player2Attack1Button;
    public GameObject player2Attack2Button;
    public GameObject player2Attack3Button;
    public GameObject comboAttackButton;
    public GameObject descriptionText;

    public Color defaultColor;
    public Color grayedOut;

    List<Fighter> entities = new List<Fighter>();
    int turn = 0;
    string description = "";
    bool selectingTarget = false;
    bool enemyAttacking = false;
    Attack currentAttack = null;
    Attack comboAttack = null;

    public string fruit = "";
    public int relationshipScore = 1;
    public RelationshipScore scoreObject;

    public VerbalAttacks verbalAttacks;

    bool isGameOver = false;

    // TODO : add dialogue queue

    // Start is called before the first frame update
    void Start()
    {
        if (TournamentManager.tournamentStarted)
        {
            players = TournamentManager.AllyPair.ToArray();
            enemies = TournamentManager.OpponentPair.ToArray();
        }

        if (players[1] is Strawberry)
        {
            fruit = "strawberry";
        }
        else if (players[1] is BlueberryFighter)
        {
            fruit = "blueberry";
        }
        else if (players[1] is LemonFighter)
        {
            fruit = "lemon";
        }
        else if (players[1] is BlackberryFighter)
        {
            fruit = "blackberry";
        }
        else if (players[1] is Tomato)
        {
            fruit = "tomato";
        }
        //populate entities array with all entities, players first, then enemies
        entities.AddRange(players);
        entities.AddRange(enemies);

        //set button names to names of attacks
        player1Attack1Button.GetComponentInChildren<Text>().text =
            players[0].attack1name;
        player1Attack2Button.GetComponentInChildren<Text>().text =
            players[0].attack2name;
        player1Attack3Button.GetComponentInChildren<Text>().text =
            players[0].attack3name;
        player1ComplimentButton.GetComponentInChildren<Text>().text =
            "Compliment";
        player1InsultButton.GetComponentInChildren<Text>().text =
            "Insult";

        player2Attack1Button.GetComponentInChildren<Text>().text =
            players[1].attack1name;
        player2Attack2Button.GetComponentInChildren<Text>().text =
            players[1].attack2name;
        player2Attack3Button.GetComponentInChildren<Text>().text =
            players[1].attack3name;

        this.comboAttack = GetComponent<ComboAttacks>().ComboAttack(players[0], players[1]);

        comboAttackButton.GetComponentInChildren<Text>().text = this.comboAttack.attackName;

        if (fruit.Equals("strawberry")) {
            relationshipScore  = RelationshipScore.strawberryScore;
        } else if (fruit.Equals("lemon")) {
            relationshipScore  = RelationshipScore.lemonScore;
        } else if (fruit.Equals("blueberry")) {
            relationshipScore  = RelationshipScore.blueberryScore;
        } else if (fruit.Equals("blackberry")) {
            relationshipScore = RelationshipScore.blackberryScore;
        } else if (fruit.Equals("tomato")){
            relationshipScore = RelationshipScore.tomatoScore;
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (!isGameOver)
        {
            //skip turn if unconcsious or frozen
            while (turn < entities.Count && (entities[turn].unconscious || entities[turn].turnsFrozen > 0))
            {
                turn++;
            }

            // reset turn
            if (turn >= entities.Count)
            {
                // handle updating fighter stats that decay
                foreach (Fighter player in players)
                {
                    player.endOfRoundUpdate();
                }

                foreach (Fighter enemy in enemies)
                {
                    enemy.endOfRoundUpdate();
                }
                turn = 0;
            }

            //checks if player is selecting a target, and if its a player's turn
            if (selectingTarget && turn < players.Length)
            {
                SelectTarget();
            }
            //if enemy's turn, play enemy attack after a certain number of seconds
            else if (turn >= players.Length)
            {
                if (!enemyAttacking)
                {
                    float duration = Mathf.Max(1.5f, description.Length / 50f);
                    Invoke("BeginEnemyAttack", duration);
                    enemyAttacking = true;
                }
            }

            // checks if the combat should end
            if (AllUnconscious(enemies))
            {
                Invoke("WinGame", 2);
                isGameOver = true;
            }
            else if (AllUnconscious(players))
            {
                Invoke("LoseGame", 2);
                isGameOver = true;
            }

            //ensure attack buttons are enabled/disabled
            ToggleAttackButtons();

            descriptionText.GetComponent<Text>().text = description;
        }
    }

    void LoseGame()
    {
        if (TournamentManager.tournamentStarted)
        {
            SceneManager.LoadScene("TournamentCombat");
        }
        else
        {
            CombatTransition.fruit = this.fruit;
            CombatTransition.won = false;
            if (fruit.Equals("strawberry"))
            {
                RelationshipScore.strawberryScore -= 2;
            }
            else if (fruit.Equals("lemon"))
            {
                RelationshipScore.lemonScore -= 2;
            }
            else if (fruit.Equals("blueberry"))
            {
                RelationshipScore.blueberryScore -= 2;
            }
            else if (fruit.Equals("blackberry"))
            {
                RelationshipScore.blackberryScore -= 2;
            }
            else if (fruit.Equals("tomato"))
            {
                RelationshipScore.tomatoScore -= 2;
            }
            SceneManager.LoadScene("CombatTransition");
        }
    }

    void WinGame()
    {
        if (TournamentManager.tournamentStarted)
        {
            TournamentManager.TransitionToFightTwo();
        }
        else
        {
            CombatTransition.fruit = this.fruit;
            CombatTransition.won = true;
            if (fruit.Equals("strawberry"))
            {
                RelationshipScore.strawberryScore += 2;
                StrawberryFruit.EndDate();
            }
            else if (fruit.Equals("lemon"))
            {
                RelationshipScore.lemonScore += 2;
            }
            else if (fruit.Equals("blueberry"))
            {
                RelationshipScore.blueberryScore += 2;
            }
            else if (fruit.Equals("blackberry"))
            {
                RelationshipScore.blackberryScore += 2;
            }
            else if (fruit.Equals("tomato"))
            {
                RelationshipScore.tomatoScore += 2;
            }
            SceneManager.LoadScene("CombatTransition");
        }
    }

    bool AllUnconscious(Fighter[] fighters)
    {
        foreach (Fighter f in fighters)
        {
            if (!f.unconscious)
            {
                return false;
            }
        }
        return true;
    }

    //toggles player 1 and 2 attacks on or off depending on turn
    void ToggleAttackButtons()
    {
        player1Attack1Button.GetComponent<Button>().enabled = turn == 0;
        player1Attack2Button.GetComponent<Button>().enabled = turn == 0;
        player1Attack3Button.GetComponent<Button>().enabled = turn == 0;
        player1ComplimentButton.GetComponent<Button>().enabled = turn == 0;
        player1InsultButton.GetComponent<Button>().enabled = turn == 0;
        player2Attack1Button.GetComponent<Button>().enabled = turn == 1;
        player2Attack2Button.GetComponent<Button>().enabled = turn == 1;
        player2Attack3Button.GetComponent<Button>().enabled = turn == 1;
        comboAttackButton.GetComponent<Button>().enabled = turn == 0 || turn == 1;

        player1Attack1Button.GetComponent<EventTrigger>().enabled = turn == 0;
        player1Attack2Button.GetComponent<EventTrigger>().enabled = turn == 0;
        player1Attack3Button.GetComponent<EventTrigger>().enabled = turn == 0;
        player1ComplimentButton.GetComponent<EventTrigger>().enabled = turn == 0;
        player1InsultButton.GetComponent<EventTrigger>().enabled = turn == 0;
        player2Attack1Button.GetComponent<EventTrigger>().enabled = turn == 1;
        player2Attack2Button.GetComponent<EventTrigger>().enabled = turn == 1;
        player2Attack3Button.GetComponent<EventTrigger>().enabled = turn == 1;
        comboAttackButton.GetComponent<EventTrigger>().enabled = turn == 0 || turn == 1;

        comboAttackButton.GetComponent<Button>().interactable = relationshipScore > 2 && !players[0].unconscious && !players[1].unconscious;

        player1Attack1Button.GetComponent<Image>().color = turn == 0 ? defaultColor : grayedOut;
        player1Attack2Button.GetComponent<Image>().color = turn == 0 ? defaultColor : grayedOut;
        player1Attack3Button.GetComponent<Image>().color = turn == 0 ? defaultColor : grayedOut;
        player1ComplimentButton.GetComponent<Image>().color = turn == 0 ? defaultColor : grayedOut;
        player1InsultButton.GetComponent<Image>().color = turn == 0 ? defaultColor : grayedOut;
        player2Attack1Button.GetComponent<Image>().color = turn == 1 ? defaultColor : grayedOut;
        player2Attack2Button.GetComponent<Image>().color = turn == 1 ? defaultColor : grayedOut;
        player2Attack3Button.GetComponent<Image>().color = turn == 1 ? defaultColor : grayedOut;
        comboAttackButton.GetComponent<Image>().color = turn == 0 || turn == 1 ? defaultColor : grayedOut;
    }

    //begins attack 1 for player 1
    public void Player1Attack1()
    {
        selectingTarget = true;
        currentAttack = players[0].attack1;
    }

    //begins attack 2 for player 1
    public void Player1Attack2()
    {
        selectingTarget = true;
        currentAttack = players[0].attack2;
    }

    //begins attack 3 for player 1
    public void Player1Attack3()
    {
        selectingTarget = true;
        currentAttack = players[0].attack3;
    }

    // begins compliment attack for player 1
    public void Player1Compliment() 
    {
        selectingTarget = true;
        currentAttack = verbalAttacks.VerbalAttack(true);
    }

    // begins insult attack for player 1
    public void Player1Insult() 
    {
        selectingTarget = true;
        currentAttack = verbalAttacks.VerbalAttack(false);
    }

    //begins attack 1 for player 2
    public void Player2Attack1()
    {
        selectingTarget = true;
        currentAttack = players[1].attack1;
    }

    //begins attack 2 for player 2
    public void Player2Attack2()
    {
        selectingTarget = true;
        currentAttack = players[1].attack2;
    }

    //begins attack 3 for player 2
    public void Player2Attack3()
    {
        selectingTarget = true;
        currentAttack = players[1].attack3;
    }

    public void ComboAttack()
    {
        selectingTarget = true;
        currentAttack = this.comboAttack;
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
                description = players[0].attack3desc;
                player1Attack3Button.GetComponentInChildren<Text>().text =
                    "> " + players[0].attack3name;
                break;
            case 3: // compliment attack
                description = "Compliment an ally or opponent.";
                player1ComplimentButton.GetComponentInChildren<Text>().text =
                    "> Compliment";
                break;
            case 4: // insult atack
                description = "Insult an ally or opponent.";
                player1InsultButton.GetComponentInChildren<Text>().text =
                    "> Insult";
                break;
            case 5:
                description = players[1].attack1desc;
                player2Attack1Button.GetComponentInChildren<Text>().text =
                    "> " + players[1].attack1name;
                break;
            case 6:
                description = players[1].attack2desc;
                player2Attack2Button.GetComponentInChildren<Text>().text =
                    "> " + players[1].attack2name;
                break;
            case 7:
                description = players[1].attack3desc;
                player2Attack3Button.GetComponentInChildren<Text>().text =
                    "> " + players[1].attack3name;
                break;
            case -1:
                description = relationshipScore > 2 ? this.comboAttack.description : "Your partner doesn't feel comfortable enough yet to do this attack with you...";
                comboAttackButton.GetComponentInChildren<Text>().text =
                    "> " + this.comboAttack.attackName;
                break;
            default:
                break;
        }
    }

    //enables selection of targets dependant on attack type
    //in the case of a multi-target attack, executes the attack on all targets regardless
    public void SelectTarget()
    {
        if (currentAttack.type == AttackType.AllyTarget)
        {
            description = currentAttack.attackName + ":\nSelect ally target";
            for (int i = 0; i < players.Length; i++)
            {
                if (!players[i].unconscious)
                {
                    players[i].GetComponent<Button>().enabled = true;
                }
            }
        }
        else if (currentAttack.type == AttackType.SingleTarget)
        {
            description = currentAttack.attackName + ":\nSelect enemy target";
            for (int i = 0; i < enemies.Length; i++)
            {
                if (!enemies[i].unconscious)
                {
                    enemies[i].GetComponent<Button>().enabled = true;
                }
            }
        } 
        else if (currentAttack.type == AttackType.MultiTarget)
        {
            SelectedTarget(enemies.ToList<Fighter>().FindAll(x => !x.unconscious).ToArray<Fighter>());
        } else if (currentAttack.type == AttackType.MultiAllyTarget) {
            SelectedTarget(players.ToList<Fighter>().FindAll(x => !x.unconscious).ToArray<Fighter>());
        } else if (currentAttack.type == AttackType.AnyTarget) {
            description = currentAttack.attackName + ":\nSelect ally or enemy target";
            for (int i = 0; i < enemies.Length; i++)
            {
                if (!enemies[i].unconscious)
                {
                    enemies[i].GetComponent<Button>().enabled = true;
                }
            }

            for (int i = 0; i < players.Length; i++)
            {
                if (!players[i].unconscious)
                {
                    players[i].GetComponent<Button>().enabled = true;
                }
            }
        }
    }

    //executes current attack on selected target
    //changes description based on attack result
    public void SelectedTarget(Fighter target)
    {
        this.description = currentAttack.execute(new Fighter[] { target });

        NextTurn();
    }

    //overloaded for multiple targets
    public void SelectedTarget(Fighter[] targets)
    {
        this.description = currentAttack.execute(targets);

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
        player1Attack3Button.GetComponentInChildren<Text>().text =
            players[0].attack3name;
        player1ComplimentButton.GetComponentInChildren<Text>().text =
            "Compliment";
        player1InsultButton.GetComponentInChildren<Text>().text =
            "Insult";

        player2Attack1Button.GetComponentInChildren<Text>().text =
            players[1].attack1name;
        player2Attack2Button.GetComponentInChildren<Text>().text =
            players[1].attack2name;
        player2Attack3Button.GetComponentInChildren<Text>().text =
            players[1].attack3name;

        comboAttackButton.GetComponentInChildren<Text>().text =
            this.comboAttack.attackName;

        description = "";
    }

    // ENEMY ATTACK: three steps, begin attack, attack, end attack

    //updates description, starts attack after 2 seconds
    void BeginEnemyAttack()
    {
        description = entities[turn].name + " is attacking...";
        Invoke("EnemyAttack", 1);
    }

    //exectues attack, updates description, ends after 5 seconds
    void EnemyAttack()
    {
        Fighter enemy = entities[turn];
        Attack[] eligibleAttacks = enemy.GetEligibleAttacks();

        string msg = "ERROR";
        while (msg == "ERROR")
        {
            this.currentAttack = eligibleAttacks[Random.Range(0, eligibleAttacks.Length)];

            if (this.currentAttack.type == AttackType.SingleTarget)
            {
                Fighter player = null;
                do
                {
                    player = players[Random.Range(0, players.Length)];
                } while (player.unconscious);

                msg = this.currentAttack.execute(new Fighter[] { player });
            }
            else if (this.currentAttack.type == AttackType.AllyTarget)
            {
                Fighter otherEnemy = null;
                bool enemyUnconscious = false;
                do
                {
                    otherEnemy = enemies[Random.Range(0, enemies.Length)];
                    if (otherEnemy.unconscious)
                    {
                        enemyUnconscious = true;
                    }
                } while (enemy == otherEnemy);

                msg = enemyUnconscious ? this.currentAttack.execute(new Fighter[] { otherEnemy }) : "ERROR";
            }
            else if (this.currentAttack.type == AttackType.MultiTarget)
            {
                msg = this.currentAttack.execute(players.ToList<Fighter>().FindAll(x => !x.unconscious).ToArray<Fighter>());
            }
            else if (this.currentAttack.type == AttackType.MultiAllyTarget)
            {
                msg = this.currentAttack.execute(enemies.ToList<Fighter>().FindAll(x => !x.unconscious).ToArray<Fighter>());
            }
        }

        description = msg;


        Invoke("EndAttack", Mathf.Max(1.5f, description.Length / 50f));
    }

    //ends attack by incrememting turn and stopping enemy attack
    void EndAttack()
    {
        turn++;
        enemyAttacking = false;
    }
}