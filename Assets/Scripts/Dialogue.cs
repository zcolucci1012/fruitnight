using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    //public TextAsset dialogueTextFile;
    public List<DialogueNode> nodes = new List<DialogueNode>();

    public void loadDialogue(TextAsset dialogueTextFile)
    {
        PasssageListObject passages = JsonUtility.FromJson<PasssageListObject>(dialogueTextFile.text);
        foreach (Passage passage in passages.passages)
        {
            DialogueNode node = new DialogueNode();

            if (passage.links.Count == 0)
            {
                node.text = passage.text;
            }
            else
            {
                int index = passage.text.IndexOf("[");
                node.text = passage.text.Substring(0, index);
            }

            for (int i = 0; i < passage.links.Count; i++)
            {
                if (i == 0)
                {
                    node.option1.text = passage.links[i].name;
                    node.option1.id = passage.links[i].pid - 1; // the pid is stored 1-indexed, so subtract one to zero index
                }
                else
                {
                    node.option2.text = passage.links[i].name;
                    node.option2.id = passage.links[i].pid - 1;
                }
            }
            nodes.Add(node);
        }
    }
}

[System.Serializable]
class PasssageListObject
{
    public List<Passage> passages;
}

[System.Serializable]
class Passage
{
    public string text;
    public List<Link> links;
}

[System.Serializable]
class Link
{
    public string name;
    public int pid;
}
