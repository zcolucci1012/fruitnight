using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TournamentManager : MonoBehaviour
{

    public int RelationshipScoreThreshold = 3;
    public GameObject DialogueWindow;
    public GameObject TextBox;
    public GameObject ExitButton;
    public GameObject Sprites;
    public Text nameText;
    public Text textBody;
    public GameObject fruitImage;

    public GameObject[] FighterPrefabs;

    public Sprite[] fruitSprites;
    public Sprite[] fighterSprites;

    private List<string> fruits = new List<string>{"Strawberry", "Blueberry", "Lemon", "Blackberry", "Tomato" };
    public static List<Fighter> AllyPair = new List<Fighter>();
    public static List<Fighter> OpponentPair = new List<Fighter>();
    public static List<Sprite> FighterSprites = new List<Sprite>();
    public static bool tournamentStarted = false;
    private static List<Fighter> opponentPair1 = new List<Fighter>();
    private static List<Fighter> opponentPair2 = new List<Fighter>();

    public AnimationClip enemyClip;
    public AnimationClip allyClip;

    // Start is called before the first frame update
    void Start()
    {
        PickAnotherPartner();
        DontDestroyOnLoad(this.gameObject);
        RelationshipScore.blueberryScore = 100;
        RelationshipScore.blueberryVerbal = true;
        RelationshipScore.strawberryScore = 100;
        RelationshipScore.strawberryVerbal = true;
    }

    public void StrawberryPicked()
    {
        if (RelationshipScore.strawberryScore >= RelationshipScoreThreshold)
        {
            SetUI("Strawberry", 0);
        }
        else
        {
            SetUI("Strawberry", 1);
        }
    }

    public void BlueberryPicked()
    {
        if (RelationshipScore.blueberryScore >= RelationshipScoreThreshold)
        {
            SetUI("Blueberry", 2);
        }
        else
        {
            SetUI("Blueberry", 3);
        }
    }

    public void LemonPicked()
    {
        if (RelationshipScore.lemonScore >= RelationshipScoreThreshold)
        {
            SetUI("Lemon", 4);
        }
        else
        {
            SetUI("Lemon", 5);
        }
    }

    public void BlackberryPicked()
    {
        if (RelationshipScore.blackberryScore >= RelationshipScoreThreshold)
        {
            SetUI("Blackberry", 6);
        }
        else
        {
            SetUI("Blackberry", 7);
        }
    }

    public void TomatoPicked()
    {
        if (RelationshipScore.tomatoScore >= RelationshipScoreThreshold)
        {
            SetUI("Tomato", 8);
        }
        else
        {
            SetUI("Tomato", 9);
        }
    }

    public static void TransitionToNextFight()
    {
        if (OpponentPair == opponentPair1)
        {
            OpponentPair = opponentPair2;
            FighterSprites.RemoveRange(2, 2);
            SceneManager.LoadScene("TournamentFightPreview");
        }
        else
        {
            Fruit2BlenderAnimation.fruit = AllyPair[1].name.ToLower();
            SceneManager.LoadScene("EndScreen");
        }
    }

    private void SetUpOpponentPairs()
    {
        Random.InitState(System.Guid.NewGuid().GetHashCode());
        int index = Random.Range(0, fruits.Count);
        AddFighter(fruits[index], opponentPair1);
        fruits.RemoveAt(index);
        index = Random.Range(0, fruits.Count);
        AddFighter(fruits[index], opponentPair1);
        fruits.RemoveAt(index);
        AddFighter(fruits[0], opponentPair2);
        AddFighter(fruits[1], opponentPair2);
    }

    private void AddFighter(string fruit, List<Fighter> fighters)
    {
        if (fruit.Equals("Strawberry"))
        {
            fighters.Add(FighterPrefabs[1].GetComponent<Strawberry>());
            FighterSprites.Add(fighterSprites[1]);
        }
        else if (fruit.Equals("Blueberry"))
        {
            fighters.Add(FighterPrefabs[2].GetComponent<BlueberryFighter>());
            FighterSprites.Add(fighterSprites[2]);
        }
        else if (fruit.Equals("Lemon"))
        {
            fighters.Add(FighterPrefabs[3].GetComponent<LemonFighter>());
            FighterSprites.Add(fighterSprites[3]);
        }
        else if (fruit.Equals("Blackberry"))
        {
            fighters.Add(FighterPrefabs[4].GetComponent<BlackberryFighter>());
            FighterSprites.Add(fighterSprites[4]);
        }
        else if (fruit.Equals("Tomato"))
        {
            fighters.Add(FighterPrefabs[5].GetComponent<Tomato>());
            FighterSprites.Add(fighterSprites[5]);
        }
    }

    private void ToTournament(string partner)
    {
        UpdateAnimations(partner);
        AllyPair.Add(FighterPrefabs[0].GetComponent<Banana>());
        FighterSprites.Add(fighterSprites[0]);
        fruits.Remove(partner);
        AddFighter(partner, AllyPair);
        SetUpOpponentPairs();
        OpponentPair = opponentPair1;
        tournamentStarted = true;
        SceneManager.LoadScene("TournamentFightPreview");
    }
    
    private void UpdateAnimations(string partner)
    {
        foreach (string fruit in fruits)
        {
            int index = -1;
            switch (fruit)
            {
                case "Strawberry":
                    index = 1;
                    break;
                case "Blueberry":
                    index = 2;
                    break;
                case "Lemon":
                    index = 3;
                    break;
                case "Blackberry":
                    index = 4;
                    break;
                case "Tomato":
                    index = 5;
                    break;
            }
            if (fruit != partner)
            {
                FighterPrefabs[index].GetComponent<Animation>().clip = enemyClip;
                FighterPrefabs[index].GetComponent<Animation>().AddClip(enemyClip, "EnemyFlippedAttack");
            }
            else
            {
                FighterPrefabs[index].GetComponent<Animation>().clip = allyClip;
                FighterPrefabs[index].GetComponent<Animation>().AddClip(enemyClip, "AllyAttack");
            }
        }
    }

    private void PickAnotherPartner()
    {
        DialogueWindow.SetActive(false);
        Sprites.SetActive(true);
    }

    private void SetUI(string fruit, int spriteIndex)
    {
        Sprites.SetActive(false);
        DialogueWindow.SetActive(true);
        nameText.text = $"{fruit}: ";
        fruitImage.GetComponent<Image>().sprite = fruitSprites[spriteIndex];

        if (spriteIndex % 2 == 0)
        {
            textBody.text = "I'd be happy to pair up with you!";
            ExitButton.GetComponent<Button>().onClick.AddListener(delegate { ToTournament(fruit); });
            ExitButton.GetComponentInChildren<Text>().text = "Continue";
        }
        else
        {
            textBody.text = "I don't know you well enough to pair up with you.";
            ExitButton.GetComponent<Button>().onClick.AddListener(delegate { PickAnotherPartner(); });
            ExitButton.GetComponentInChildren<Text>().text = "Choose a different partner";
        }
    }    
}
