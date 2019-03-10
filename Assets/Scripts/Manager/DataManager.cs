using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataManager : MonoBehaviour {

    public static DataManager instance;

    /// <summary>
    /// 玩家要玩的关卡
    /// </summary>
    public int PlayLV = 0;

    /// <summary>
    /// 游戏选择道具列表
    /// </summary>
    public List<PlayGameProps> playGamePropsList = new List<PlayGameProps>();

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


        PlayerPrefs.SetInt("DB_GateLevel", 1);

        KeyValue.SetDouble("LiveCoolingTime", TimeManager.GetNow());
        PlayerPrefs.SetInt("AdditionalLiveNumber", 0);

        PlayerPrefs.SetInt("FirstGame", 1);

    }




    private void LoadDB()
    {

    }


 
   
}
