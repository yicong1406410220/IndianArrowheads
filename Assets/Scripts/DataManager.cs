using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour {

    public static DataManager instance;

    public Dictionary<string, Dictionary<string, string>> DB_Player;
    public Dictionary<string, Dictionary<string, string>> DB_Digger;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDB();
        InitPlay();
    }

    /// <summary>
    /// 第一次进入游戏初始化数据
    /// </summary>
    private void InitPlay()
    {
        if (PlayerPrefs.GetInt("FirstGame", 0) == 1)
        {
            return;
        }

        PlayerData.AddDiamond(Convert.ToInt32(DB_Player["1"]["diamond"]));
        PlayerData.AddGold(Convert.ToInt32(DB_Player["1"]["gold"]));

        PlayerPrefs.SetInt("FirstGame", 1);

        KeyValue.SetDouble("LiveCoolingTime", TimeManager.GetNow());
        PlayerPrefs.SetInt("AdditionalLiveNumber", 0);

        PlayerPrefs.SetInt("IsSoundOpen", 1);
        PlayerPrefs.SetInt("FirstGame", 1);

    }




    private void LoadDB()
    {
        DB_Player = ExcelDocumentsParse.LoadExcel("Player");
        DB_Digger = ExcelDocumentsParse.LoadExcel("Digger");
    }


 
   
}
