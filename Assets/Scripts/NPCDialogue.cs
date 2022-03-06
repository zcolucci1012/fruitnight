using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDialogue : MonoBehaviour
{

    private Dialogue d = new Dialogue();

    private GameObject name_text;
    private GameObject dialogue_text;
    private GameObject option_1;
    private GameObject option_2;
    private GameObject exit_button;

    private int selected_option = -2;
    private string prevEmotion = "";

    public GameObject DialogueWindow;
    public TextAsset dialoguePath;
    public string nextScene;
    public AudioClip clickSFX;
    public GameObject audioPlayer;

    // initialization
    void Start()
    {

        DialogueWindow.SetActive(true);
        d.loadDialogue(dialoguePath);

        name_text = GameObject.Find("NPC Name");
        dialogue_text = GameObject.Find("NPC Dialogue");
        option_1 = GameObject.Find("Option 1");
        option_2 = GameObject.Find("Option 2");
        exit_button = GameObject.Find("Exit");

        exit_button.SetActive(false);

        RunDialogue();
    }

    public void RunDialogue()
    {
        StartCoroutine(run());
    }

    private void SetSelectedOption(int x)
    {
        selected_option = x;
        AudioSource.PlayClipAtPoint(clickSFX, audioPlayer.transform.position);
    }

    public IEnumerator run()
    {
        int node_id = 0;

        while (node_id != -1)
        {
            display_node(d.nodes[node_id]);

            selected_option = -2;
            while (selected_option == -2)
            {
                yield return new WaitForSeconds(0.25f);
            }
            node_id = selected_option;
        }
    }

    private void display_node(DialogueNode node)
    {
        // change text
        dialogue_text.GetComponent<Text>().text = node.text;
        
        // change score
        if (node.score != 0)
        {
            FindObjectOfType<RelationshipScore>().changeScore(node.speaker, node.score);
        }


        // change image
        this.GetComponent<SwapEmotion>().swapEmotion(node.speaker, node.emotion);
        if (!prevEmotion.Equals(node.speaker + " " + node.emotion))
        {
            FindObjectOfType<DialogueAudio>().PlayAudio(node.speaker, node.emotion);
        }
        prevEmotion = node.speaker + " " + node.emotion;
        this.GetComponent<SwapBackground>().swapBackground(node.bg);

        // change name in textbox
        if (!node.speaker.Equals("noSpeaker"))
        {
            name_text.GetComponent<Text>().text = node.speaker + ":";
        }
        else
        {
            name_text.GetComponent<Text>().text = " ";
        }


        // change options
        option_1.SetActive(false);
        option_2.SetActive(false);

        if (node.option1.id != 0)
        {
            option_1.SetActive(true);
            option_1.GetComponentInChildren<Text>().text = node.option1.text;
            option_1.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(node.option1.id); });
        }

        if (node.option2.id != 0)
        {
            option_2.SetActive(true);
            option_2.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(node.option2.id); });
            option_2.GetComponentInChildren<Text>().text = node.option2.text;
        }

        if (node.option1.id == 0 && node.option2.id == 0)
        {
            exit_button.SetActive(true);
            exit_button.GetComponent<Button>().onClick.AddListener(delegate { DialogueWindow.SetActive(false); });
            exit_button.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene(nextScene); });
        }

    }

}
