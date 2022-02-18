using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour
{

    private Dialogue d = new Dialogue();

    private GameObject name_text;
    private GameObject dialogue_text;
    private GameObject option_1;
    private GameObject option_2;
    private GameObject exit_button;

    private int selected_option = -2;

    public GameObject DialogueWindow;
    public TextAsset dialoguePath;
    public int score = 0;
    public string NPCName;

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

        name_text.GetComponent<Text>().text = NPCName + ":";

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
        // add sound
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
        dialogue_text.GetComponent<Text>().text = node.text;
        score += node.score;
        // change image
        this.GetComponent<SwapEmotion>().swapEmotion(node.emotion);


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
        }

    }

}
