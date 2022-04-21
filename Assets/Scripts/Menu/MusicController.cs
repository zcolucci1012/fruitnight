using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        Debug.Log(objs.Length);

        if (objs.Length > 1)
        {
            if (objs[0].name == objs[1].name)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Destroy(objs[0]);
            }
        }
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume", 0.5f);
    }

    public void PlayMusic()
    {
        if (audioSource.isPlaying) return;
        audioSource.Play();
    }
}
