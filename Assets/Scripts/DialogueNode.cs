using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueNode
{
    public string text;
    public DialogueOption option1;
    public DialogueOption option2;

    public DialogueNode()
    {
        option1 = new DialogueOption();
        option2 = new DialogueOption();
    }
}
