using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCDialogue : MonoBehaviour
{

    private Dialogue d = new Dialogue();

    private GameObject name_text;
    private GameObject name_box;
    private GameObject dialogue_text;
    private GameObject option_1;
    private GameObject option_2;
    private GameObject option_3;
    private GameObject exit_button;
    private GameObject continue_button;

    private int selected_option = -2;
    private string prevEmotion = "";

    public float scrollSpeed = 0.03f;

    public GameObject DialogueWindow;
    public TextAsset dialoguePath;
    public string nextScene;
    public GameObject goodParticles;
    public GameObject badParticles;

    // initialization
    void Start()
    {

        DialogueWindow.SetActive(true);
        d.loadDialogue(dialoguePath);

        name_text = GameObject.Find("NPC Name");
        name_box = GameObject.Find("Name Box");
        dialogue_text = GameObject.Find("NPC Dialogue");
        option_1 = GameObject.Find("Option 1");
        option_2 = GameObject.Find("Option 2");
        option_3 = GameObject.Find("Option 3");
        continue_button = GameObject.Find("Continue");
        exit_button = GameObject.Find("Exit");

        exit_button.SetActive(false);
        continue_button.SetActive(false);

        RunDialogue();
    }

    void Update()
    {
        // let player speed up dialogue if they press space
        if (Input.GetKey(KeyCode.Space))
        {
            scrollSpeed = .00001f;
        }
        else
        {
            scrollSpeed = .03f;
        }
    }

    public void RunDialogue()
    {
        StartCoroutine(run());
    }

    private void SetSelectedOption(int x)
    {
        selected_option = x;
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
        // hide options initially
        option_1.SetActive(false);
        option_2.SetActive(false);
        option_3.SetActive(false);
        continue_button.SetActive(false);
        goodParticles.SetActive(false);
        badParticles.SetActive(false);

        // if no dialogue, only options
        if (node.speaker.Contains("option"))
        {
            DialogueWindow.SetActive(false);
            showOptions(node);
        }
        else
        {
            DialogueWindow.SetActive(true);

            // change text
            //dialogue_text.GetComponent<Text>().text = node.text;
            StartCoroutine(DisplayText(node));  

            // change score
            if (node.score != 0)
            {
                FindObjectOfType<RelationshipScore>().changeScore(node.speaker, node.score);
                if (node.score > 0)
                {
                    goodParticles.SetActive(true);
                }
                else
                {
                    badParticles.SetActive(true);
                }
            }


            // change image
            this.GetComponent<SwapEmotion>().swapEmotion(node.speaker, node.emotion);
            if (!prevEmotion.Equals(node.speaker + " " + node.emotion))
            {
                FindObjectOfType<DialogueAudio>().PlayAudio(node.speaker, node.emotion);
            }
            prevEmotion = node.speaker + " " + node.emotion;
            this.GetComponent<SwapBackground>().swapBackground(node.bg);

            if (!node.speaker.Equals("noSpeaker"))
            {
                name_box.SetActive(true);
                name_text.GetComponent<Text>().text = node.speaker + ":";
            }
            else
            {
                name_box.SetActive(false);
                name_text.GetComponent<Text>().text = " ";
            }

            // did this unlock a verbal attack?
            if (node.unlockVerbal)
            {
                FindObjectOfType<RelationshipScore>().unlockVerbal(node.speaker);
            }
        }

    }

    // scroll text as it displays
    private IEnumerator DisplayText(DialogueNode node)
    {
        dialogue_text.GetComponent<Text>().text = "";
        foreach (char c in node.text.ToCharArray())
        {
            dialogue_text.GetComponent<Text>().text += c;
            yield return new WaitForSecondsRealtime(scrollSpeed);
        }
        showOptions(node);
        yield return null;
    }

    // show the options
    private void showOptions(DialogueNode node)
    {
        // change options
        bool showOption1 = node.option1.id != 0;
        bool showOption2 = node.option2.id != 0;
        bool showOption3 = node.option3.id != 0;

        if (showOption1)
        {
            if (!showOption2 && !showOption3)
            {
                continue_button.SetActive(true);
                continue_button.GetComponentInChildren<Text>().text = node.option1.text;
                continue_button.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(node.option1.id); });
            }
            else
            {
                option_1.SetActive(true);
                option_1.GetComponentInChildren<Text>().text = node.option1.text;
                option_1.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(node.option1.id); });
            }
        }

        if (showOption2)
        {
            option_2.SetActive(true);
            option_2.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(node.option2.id); });
            option_2.GetComponentInChildren<Text>().text = node.option2.text;
        }

        if (showOption3)
        {
            option_3.SetActive(true);
            option_3.GetComponent<Button>().onClick.AddListener(delegate { SetSelectedOption(node.option3.id); });
            option_3.GetComponentInChildren<Text>().text = node.option3.text;
        }

        if (!showOption1 && !showOption2 && !showOption3)
        {
            exit_button.SetActive(true);
            exit_button.GetComponent<Button>().onClick.AddListener(delegate { DialogueWindow.SetActive(false); });
            exit_button.GetComponent<Button>().onClick.AddListener(delegate { SceneManager.LoadScene(nextScene); });
        }
    }

}
