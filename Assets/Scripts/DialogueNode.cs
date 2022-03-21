using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode
{
    public string text;
    public DialogueOption option1;
    public DialogueOption option2;
    public string emotion = "base";
    public string speaker;
    public string bg;
    public int score = 0;
    public bool unlockVerbal = false;

    public DialogueNode()
    {
        option1 = new DialogueOption();
        option2 = new DialogueOption();
    }
}
