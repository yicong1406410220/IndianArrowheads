using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioSource audioSource;

    public static MusicManager instance;

    private void Awake()
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
    void Start ()
    {
        
    }

    public void RefreshSound()
    {
        if (KeyValue.GetBool("DB_CloseMusic"))
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
