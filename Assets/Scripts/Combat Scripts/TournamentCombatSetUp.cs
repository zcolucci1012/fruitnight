using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TournamentCombatSetUp : MonoBehaviour
{

    public GameObject Ally1;
    public GameObject Ally2;
    public GameObject Enemy1;
    public GameObject Enemy2;

    public GameObject Ally1ProfileImage;
    public GameObject Ally2ProfileImage;

    private Vector3 Ally1OriginalEulerAngles;
    private Vector3 Ally2OriginalEulerAngles;
    private Vector3 Enemy1OriginaElulerAngles;
    private Vector3 Enemy2OriginaElulerAngles;

    // Start is called before the first frame update
    void Start()
    {
        ResetFighters();

        Ally1OriginalEulerAngles = Ally1.transform.eulerAngles;
        Ally2OriginalEulerAngles = Ally2.transform.eulerAngles;
        Enemy1OriginaElulerAngles = Enemy1.transform.eulerAngles;
        Enemy2OriginaElulerAngles = Enemy2.transform.eulerAngles;

        Ally1.GetComponentInChildren<HealthBar>().fighter = TournamentManager.AllyPair[0];
        Ally2.GetComponentInChildren<HealthBar>().fighter = TournamentManager.AllyPair[1];
        Enemy1.GetComponentInChildren<HealthBar>().fighter = TournamentManager.OpponentPair[0];
        Enemy2.GetComponentInChildren<HealthBar>().fighter = TournamentManager.OpponentPair[1];

        TournamentManager.AllyPair[0].healthBar = Ally1.GetComponentInChildren<HealthBar>();
        TournamentManager.AllyPair[0].healthBarObject = Ally1.transform.Find("HealthBar").gameObject;
        TournamentManager.AllyPair[1].healthBar = Ally2.GetComponentInChildren<HealthBar>();
        TournamentManager.AllyPair[1].healthBarObject = Ally2.transform.Find("HealthBar").gameObject;
        TournamentManager.OpponentPair[0].healthBar = Enemy1.GetComponentInChildren<HealthBar>();
        TournamentManager.OpponentPair[0].healthBarObject = Enemy1.transform.Find("HealthBar").gameObject;
        TournamentManager.OpponentPair[1].healthBar = Enemy2.GetComponentInChildren<HealthBar>();
        TournamentManager.OpponentPair[1].healthBarObject = Enemy2.transform.Find("HealthBar").gameObject;

        Ally1.GetComponent<Image>().sprite = TournamentManager.FighterSprites[0];
        Ally2.GetComponent<Image>().sprite = TournamentManager.FighterSprites[1];
        Enemy1.GetComponent<Image>().sprite = TournamentManager.FighterSprites[2];
        Enemy2.GetComponent<Image>().sprite = TournamentManager.FighterSprites[3];
        Ally1ProfileImage.GetComponent<Image>().sprite = TournamentManager.FighterSprites[0];
        Ally2ProfileImage.GetComponent<Image>().sprite = TournamentManager.FighterSprites[1];

        Ally1.GetComponent<Button>().onClick.AddListener(delegate { FindObjectOfType<LevelHandler>().SelectedTarget(TournamentManager.AllyPair[0]); });
        Ally2.GetComponent<Button>().onClick.AddListener(delegate { FindObjectOfType<LevelHandler>().SelectedTarget(TournamentManager.AllyPair[1]); });
        Enemy1.GetComponent<Button>().onClick.AddListener(delegate { FindObjectOfType<LevelHandler>().SelectedTarget(TournamentManager.OpponentPair[0]); });
        Enemy2.GetComponent<Button>().onClick.AddListener(delegate { FindObjectOfType<LevelHandler>().SelectedTarget(TournamentManager.OpponentPair[1]); });

        TournamentManager.AllyPair[0].healthBar = Ally1.GetComponentInChildren<HealthBar>();
        TournamentManager.AllyPair[1].healthBar = Ally2.GetComponentInChildren<HealthBar>();
        TournamentManager.OpponentPair[0].healthBar = Enemy1.GetComponentInChildren<HealthBar>();
        TournamentManager.OpponentPair[1].healthBar = Enemy2.GetComponentInChildren<HealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TournamentManager.AllyPair[0].unconscious)
        {
            Ally1.transform.eulerAngles = Ally1OriginalEulerAngles + new Vector3(0, 0, 90);
        }
        else
        {
            Ally1.transform.eulerAngles = Ally1OriginalEulerAngles;
        }

        if (TournamentManager.AllyPair[1].unconscious)
        {
            Ally2.transform.eulerAngles = Ally2OriginalEulerAngles + new Vector3(0, 0, 90);
        }
        else
        {
            Ally2.transform.eulerAngles = Ally2OriginalEulerAngles;
        }

        if (TournamentManager.OpponentPair[0].unconscious)
        {
            Enemy1.transform.eulerAngles = Enemy1OriginaElulerAngles + new Vector3(0, 0, 90);
        }
        else
        {
            Enemy1.transform.eulerAngles = Enemy1OriginaElulerAngles;
        }

        if (TournamentManager.OpponentPair[1].unconscious)
        {
            Enemy2.transform.eulerAngles = Enemy2OriginaElulerAngles + new Vector3(0, 0, 90);
        }
        else
        {
            Enemy2.transform.eulerAngles = Enemy2OriginaElulerAngles;
        }

        Ally1.GetComponent<Button>().enabled = TournamentManager.AllyPair[0].GetComponent<Button>().IsActive();
        Ally2.GetComponent<Button>().enabled = TournamentManager.AllyPair[1].GetComponent<Button>().IsActive();
        Enemy1.GetComponent<Button>().enabled = TournamentManager.OpponentPair[0].GetComponent<Button>().IsActive();
        Enemy2.GetComponent<Button>().enabled = TournamentManager.OpponentPair[1].GetComponent<Button>().IsActive();
    }

    private void ResetFighters()
    {
        TournamentManager.AllyPair[0].currentHp = TournamentManager.AllyPair[0].maxHp;
        TournamentManager.AllyPair[1].currentHp = TournamentManager.AllyPair[1].maxHp;
        TournamentManager.AllyPair[0].unconscious = false;
        TournamentManager.AllyPair[1].unconscious = false;
        TournamentManager.AllyPair[0].poisonAttacks.Clear();
        TournamentManager.AllyPair[1].poisonAttacks.Clear();
        TournamentManager.AllyPair[0].turnsCantHeal = 0;
        TournamentManager.AllyPair[1].turnsCantHeal = 0;
        TournamentManager.AllyPair[0].turnsFrozen = 0;
        TournamentManager.AllyPair[1].turnsFrozen = 0;
        TournamentManager.AllyPair[0].turnsStrongHit = 0;
        TournamentManager.AllyPair[1].turnsStrongHit = 0;

        TournamentManager.OpponentPair[0].currentHp = TournamentManager.OpponentPair[0].maxHp;
        TournamentManager.OpponentPair[1].currentHp = TournamentManager.OpponentPair[1].maxHp;
        TournamentManager.OpponentPair[0].unconscious = false;
        TournamentManager.OpponentPair[1].unconscious = false;
        TournamentManager.OpponentPair[0].poisonAttacks.Clear();
        TournamentManager.OpponentPair[1].poisonAttacks.Clear();
        TournamentManager.OpponentPair[0].turnsCantHeal = 0;
        TournamentManager.OpponentPair[1].turnsCantHeal = 0;
        TournamentManager.OpponentPair[0].turnsFrozen = 0;
        TournamentManager.OpponentPair[1].turnsFrozen = 0;
        TournamentManager.OpponentPair[0].turnsStrongHit = 0;
        TournamentManager.OpponentPair[1].turnsStrongHit = 0;
    }
}
