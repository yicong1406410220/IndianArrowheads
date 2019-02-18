using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource audioSource;

    public static SoundManager instance;

    public AudioClip[] audioClip;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        RefreshSound();
    }

    // Use this for initialization
    void Start () {
        
	}

    public void RefreshSound()
    {
        if (KeyValue.GetBool("DB_CloseSound"))
        {
            audioSource.mute = true;
        }
        else
        {
            audioSource.mute = false;
        }
    }

    public void PlayBtn()
    {
        audioSource.PlayOneShot(audioClip[0]);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
