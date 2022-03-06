using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAudio : MonoBehaviour
{

    public List<AudioClip> clips;

  public void PlayAudio(string speaker, string emotion)
    {
        foreach (AudioClip clip in clips)
        {
            if (clip.name.Equals(speaker + " " + emotion))
            {
                // play audio!
                AudioSource.PlayClipAtPoint(clip, transform.position);
            }
        }
    }
}
