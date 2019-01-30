using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    public AudioSource audioSource;

    void Awake()
    {
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

    // Update is called once per frame
    void Update () {
		
	}
}
