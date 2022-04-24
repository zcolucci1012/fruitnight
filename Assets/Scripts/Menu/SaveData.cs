using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public float saveTime = 10;
    private float saveTimer = 0;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Save Data");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        saveTimer += Time.deltaTime;
        if (saveTimer > saveTime)
        {
            Debug.Log("Saving...");
            Save();
            saveTimer = 0;
        }
    }

    // Update is called once per frame
    public static void Save()
    {
        PlayerPrefs.SetInt("strawberryRelationshipScore", RelationshipScore.strawberryScore);
        PlayerPrefs.SetInt("blueberryRelationshipScore", RelationshipScore.blueberryScore);
        PlayerPrefs.SetInt("lemonRelationshipScore", RelationshipScore.lemonScore);
        PlayerPrefs.SetInt("blackberryRelationshipScore", RelationshipScore.blackberryScore);
        PlayerPrefs.SetInt("tomatoRelationshipScore", RelationshipScore.tomatoScore);

        PlayerPrefs.SetInt("CTstrawberryRelationshipScore", CombatTransition.strawberryPreviousRelationshipScore);
        PlayerPrefs.SetInt("CTblueberryRelationshipScore", CombatTransition.blueberryPreviousRelationshipScore);
        PlayerPrefs.SetInt("CTlemonRelationshipScore", CombatTransition.lemonPreviousRelationshipScore);
        PlayerPrefs.SetInt("CTblackberryRelationshipScore", CombatTransition.blackberryPreviousRelationshipScore);
        PlayerPrefs.SetInt("CTtomatoRelationshipScore", CombatTransition.tomatoPreviousRelationshipScore);

        PlayerPrefs.SetInt("TBDstrawberryRelationshipScore", TransitionBetweenDaysManager.strawberryPreviousRelationshipScore);
        PlayerPrefs.SetInt("TBDblueberryRelationshipScore", TransitionBetweenDaysManager.blueberryPreviousRelationshipScore);
        PlayerPrefs.SetInt("TBDlemonRelationshipScore", TransitionBetweenDaysManager.lemonPreviousRelationshipScore);
        PlayerPrefs.SetInt("TBDblackberryRelationshipScore", TransitionBetweenDaysManager.blackberryPreviousRelationshipScore);
        PlayerPrefs.SetInt("TBDtomatoRelationshipScore", TransitionBetweenDaysManager.tomatoPreviousRelationshipScore);

        PlayerPrefs.SetInt("numDatesLeftInDay", DateSelectionManager.numDatesLeftInDay);

        PlayerPrefs.SetInt("strawberryNumDates", StrawberryFruit.numDates);
        PlayerPrefs.SetInt("blueberryNumDates", BlueberryFruit.numDates);
        PlayerPrefs.SetInt("lemonNumDates", LemonFruit.numDates);
        PlayerPrefs.SetInt("blackberryNumDates", BlackberryFruit.numDates);
        PlayerPrefs.SetInt("tomatoNumDates", TomatoFruit.numDates);

        PlayerPrefs.SetInt("strawberryDaysLeftUntilDateable", StrawberryFruit.daysLeftUntilDateable);
        PlayerPrefs.SetInt("blueberryDaysLeftUntilDateable", BlueberryFruit.daysLeftUntilDateable);
        PlayerPrefs.SetInt("lemonDaysLeftUntilDateable", LemonFruit.daysLeftUntilDateable);
        PlayerPrefs.SetInt("blackberryDaysLeftUntilDateable", BlackberryFruit.daysLeftUntilDateable);
        PlayerPrefs.SetInt("tomatoDaysLeftUntilDateable", TomatoFruit.daysLeftUntilDateable);

        PlayerPrefs.SetInt("tournamentStarted", TournamentManager.tournamentStarted ? 1 : 0);
    }

    public static void Restart()
    {
        PlayerPrefs.SetInt("strawberryRelationshipScore", 0);
        PlayerPrefs.SetInt("blueberryRelationshipScore", 0);
        PlayerPrefs.SetInt("lemonRelationshipScore", 0);
        PlayerPrefs.SetInt("blackberryRelationshipScore", 0);
        PlayerPrefs.SetInt("tomatoRelationshipScore", 0);

        PlayerPrefs.SetInt("CTstrawberryRelationshipScore", 0);
        PlayerPrefs.SetInt("CTblueberryRelationshipScore", 0);
        PlayerPrefs.SetInt("CTlemonRelationshipScore", 0);
        PlayerPrefs.SetInt("CTblackberryRelationshipScore", 0);
        PlayerPrefs.SetInt("CTtomatoRelationshipScore", 0);

        PlayerPrefs.SetInt("TBDstrawberryRelationshipScore", 0);
        PlayerPrefs.SetInt("TBDblueberryRelationshipScore", 0);
        PlayerPrefs.SetInt("TBDlemonRelationshipScore", 0);
        PlayerPrefs.SetInt("TBDblackberryRelationshipScore", 0);
        PlayerPrefs.SetInt("TBDtomatoRelationshipScore", 0);

        PlayerPrefs.SetInt("numDatesLeftInDay", 2);

        PlayerPrefs.SetInt("strawberryNumDates", 0);
        PlayerPrefs.SetInt("blueberryNumDates", 0);
        PlayerPrefs.SetInt("lemonNumDates", 0);
        PlayerPrefs.SetInt("blackberryNumDates", 0);
        PlayerPrefs.SetInt("tomatoNumDates", 0);

        PlayerPrefs.SetInt("strawberryDaysLeftUntilDateable", 0);
        PlayerPrefs.SetInt("blueberryDaysLeftUntilDateable", 0);
        PlayerPrefs.SetInt("lemonDaysLeftUntilDateable", 0);
        PlayerPrefs.SetInt("blackberryDaysLeftUntilDateable", 0);
        PlayerPrefs.SetInt("tomatoDaysLeftUntilDateable", 0);

        PlayerPrefs.SetInt("tournamentStarted", TournamentManager.tournamentStarted ? 1 : 0);
    }

    public static void Load()
    {
        LogData();
        RelationshipScore.strawberryScore = PlayerPrefs.GetInt("strawberryRelationshipScore", 0);
        RelationshipScore.blueberryScore = PlayerPrefs.GetInt("blueberryRelationshipScore", 0);
        RelationshipScore.lemonScore = PlayerPrefs.GetInt("lemonRelationshipScore", 0);
        RelationshipScore.blackberryScore = PlayerPrefs.GetInt("blackberryRelationshipScore", 0);
        RelationshipScore.tomatoScore = PlayerPrefs.GetInt("tomatoRelationshipScore", 0);

        CombatTransition.strawberryPreviousRelationshipScore = PlayerPrefs.GetInt("CTstrawberryRelationshipScore", 0);
        CombatTransition.blueberryPreviousRelationshipScore = PlayerPrefs.GetInt("CTblueberryRelationshipScore", 0);
        CombatTransition.lemonPreviousRelationshipScore = PlayerPrefs.GetInt("CTlemonRelationshipScore", 0);
        CombatTransition.blackberryPreviousRelationshipScore = PlayerPrefs.GetInt("CTblackberryRelationshipScore", 0);
        CombatTransition.tomatoPreviousRelationshipScore = PlayerPrefs.GetInt("CTtomatoRelationshipScore", 0);

        TransitionBetweenDaysManager.strawberryPreviousRelationshipScore = PlayerPrefs.GetInt("TBDstrawberryRelationshipScore", 0);
        TransitionBetweenDaysManager.blueberryPreviousRelationshipScore = PlayerPrefs.GetInt("TBDblueberryRelationshipScore", 0);
        TransitionBetweenDaysManager.lemonPreviousRelationshipScore = PlayerPrefs.GetInt("TBDlemonRelationshipScore", 0);
        TransitionBetweenDaysManager.blackberryPreviousRelationshipScore = PlayerPrefs.GetInt("TBDblackberryRelationshipScore", 0);
        TransitionBetweenDaysManager.tomatoPreviousRelationshipScore = PlayerPrefs.GetInt("TBDtomatoRelationshipScore", 0);

        DateSelectionManager.numDatesLeftInDay = PlayerPrefs.GetInt("numDatesLeftInDay", 2);

        StrawberryFruit.numDates = PlayerPrefs.GetInt("strawberryNumDates", 0);
        BlueberryFruit.numDates = PlayerPrefs.GetInt("blueberryNumDates", 0);
        LemonFruit.numDates = PlayerPrefs.GetInt("lemonNumDates", 0);
        BlackberryFruit.numDates = PlayerPrefs.GetInt("blackberryNumDates", 0);
        TomatoFruit.numDates = PlayerPrefs.GetInt("tomatoNumDates", 0);

        StrawberryFruit.daysLeftUntilDateable = PlayerPrefs.GetInt("strawberryDaysLeftUntilDateable", 0);
        BlueberryFruit.daysLeftUntilDateable = PlayerPrefs.GetInt("blueberryDaysLeftUntilDateable", 0);
        LemonFruit.daysLeftUntilDateable = PlayerPrefs.GetInt("lemonDaysLeftUntilDateable", 0);
        BlackberryFruit.daysLeftUntilDateable = PlayerPrefs.GetInt("blackberryDaysLeftUntilDateable", 0);
        TomatoFruit.daysLeftUntilDateable = PlayerPrefs.GetInt("tomatoDaysLeftUntilDateable", 0);

        TournamentManager.tournamentStarted = PlayerPrefs.GetInt("tournamentStarted", 0) == 1;
    }

    public static void LogData()
    {
        Debug.Log(
            "strawberryRelationshipScore: " + PlayerPrefs.GetInt("strawberryRelationshipScore", 0) + "\n" +
            "blueberryRelationshipScore: " + PlayerPrefs.GetInt("blueberryRelationshipScore", 0) + "\n" +
            "lemonRelationshipScore: " + PlayerPrefs.GetInt("lemonRelationshipScore", 0) + "\n" +
            "blackberryRelationshipScore: " + PlayerPrefs.GetInt("blackberryRelationshipScore", 0) + "\n" +
            "tomatoRelationshipScore: " + PlayerPrefs.GetInt("tomatoRelationshipScore", 0) + "\n" +

            "CTstrawberryRelationshipScore: " + PlayerPrefs.GetInt("CTstrawberryRelationshipScore", 0) + "\n" +
            "CTblueberryRelationshipScore: " + PlayerPrefs.GetInt("CTblueberryRelationshipScore", 0) + "\n" +
            "CTlemonRelationshipScore: " + PlayerPrefs.GetInt("CTlemonRelationshipScore", 0) + "\n" +
            "CTblackberryRelationshipScore: " + PlayerPrefs.GetInt("CTblackberryRelationshipScore", 0) + "\n" +
            "CTtomatoRelationshipScore: " + PlayerPrefs.GetInt("CTtomatoRelationshipScore", 0) + "\n" +

            "TBDstrawberryRelationshipScore: " + PlayerPrefs.GetInt("TBDstrawberryRelationshipScore", 0) + "\n" +
            "TBDblueberryRelationshipScore: " + PlayerPrefs.GetInt("TBDblueberryRelationshipScore", 0) + "\n" +
            "TBDlemonRelationshipScore: " + PlayerPrefs.GetInt("TBDlemonRelationshipScore", 0) + "\n" +
            "TBDblackberryRelationshipScore: " + PlayerPrefs.GetInt("TBDblackberryRelationshipScore", 0) + "\n" +
            "TBDtomatoRelationshipScore: " + PlayerPrefs.GetInt("TBDtomatoRelationshipScore", 0) + "\n" +

            "numDatesLeftInDay: " + PlayerPrefs.GetInt("numDatesLeftInDay", 2) + "\n" +

            "strawberryNumDates: " + PlayerPrefs.GetInt("strawberryNumDates", 0) + "\n" +
            "blueberryNumDates: " + PlayerPrefs.GetInt("blueberryNumDates", 0) + "\n" +
            "lemonNumDates: " + PlayerPrefs.GetInt("lemonNumDates", 0) + "\n" +
            "blackberryNumDates: " + PlayerPrefs.GetInt("blackberryNumDates", 0) + "\n" +
            "tomatoNumDates: " + PlayerPrefs.GetInt("tomatoNumDates", 0) + "\n" +

            "strawberryDaysLeftUntilDateable: " + PlayerPrefs.GetInt("strawberryDaysLeftUntilDateable", 0) + "\n" +
            "blueberryDaysLeftUntilDateable: " + PlayerPrefs.GetInt("blueberryDaysLeftUntilDateable", 0) + "\n" +
            "lemonDaysLeftUntilDateable: " + PlayerPrefs.GetInt("lemonDaysLeftUntilDateable", 0) + "\n" +
            "blackberryDaysLeftUntilDateable: " + PlayerPrefs.GetInt("blackberryDaysLeftUntilDateable", 0) + "\n" +
            "tomatoDaysLeftUntilDateable: " + PlayerPrefs.GetInt("tomatoDaysLeftUntilDateable", 0) + "\n" +

            "tournamentStarted: " + PlayerPrefs.GetInt("tournamentStarted", 0) + "\n"
            );
    }
}
