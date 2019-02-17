using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconCanvas : MonoBehaviour {

    public Text LiveNumber;
    public Text LiveTime;

    public Text GemNumber;
    public Text GoldNumber;

    // Use this for initialization
    void Start () {
        StartCoroutine(LiveUpdate());
    }

    private IEnumerator LiveUpdate()
    {
        while (true)
        {
            LiveNumber.text = PlayerData.GetLive().ToString();
            LiveTime.text = PlayerData.GetLiveRecoverTimeString().ToString();
            GemNumber.text = PlayerData.GetDiamond().ToString();
            GoldNumber.text = PlayerData.GetGold().ToString();
            yield return new WaitForSeconds(1.0f);
        }
       
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerData.AddLive();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerData.UseLive();
        }
    }
}
