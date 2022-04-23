using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BananaBlenderAnimation : MonoBehaviour
{
    public Image blenderColor;
    public Color bananaColor;
    Animation anim;
    bool started = false;
    bool done = false;

    private void Awake()
    {
        anim = GetComponent<Animation>();

        anim.PlayQueued("Walk", QueueMode.CompleteOthers);
        anim.PlayQueued("Stop", QueueMode.CompleteOthers);
        anim.PlayQueued("Jump", QueueMode.CompleteOthers);
    }

    private void Update()
    {
        if (!anim.isPlaying)
        {
            if (started && !done)
            {
                blenderColor.color = bananaColor;
                done = true;
            }
            started = true;
        }
    }
}
