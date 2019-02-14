using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData {

    public static void AddGold(int value)
    {
        int number = PlayerPrefs.GetInt("GoldNumber", 0);
        PlayerPrefs.GetInt("GoldNumber", number + value);
    }

    public static void UseGold(int value)
    {
        int number = PlayerPrefs.GetInt("GoldNumber", 0);
        PlayerPrefs.GetInt("GoldNumber", number - value);
    }

    public static int GetGold()
    {
        int number = PlayerPrefs.GetInt("GoldNumber", 0);
        return number;
    }

    public static void AddDiamond(int value)
    {
        int number = PlayerPrefs.GetInt("DiamondNumber", 0);
        PlayerPrefs.GetInt("DiamondNumber", number + value);
    }

    public static void UseDiamond(int value)
    {
        int number = PlayerPrefs.GetInt("DiamondNumber", 0);
        PlayerPrefs.GetInt("DiamondNumber", number - value);
    }

    public static int GetDiamond()
    {
        int number = PlayerPrefs.GetInt("DiamondNumber", 0);
        return number;
    }

    //public static void AddLive(int value)
    //{
    //    int number = PlayerPrefs.GetInt("LiveNumber", 0);
    //    PlayerPrefs.GetInt("LiveNumber", number + value);
    //}

    //public static void UseLive(int value)
    //{
    //    int number = PlayerPrefs.GetInt("LiveNumber", 0);
    //    PlayerPrefs.GetInt("LiveNumber", number - value);
    //}

    //public static int GetLive()
    //{
    //    int number = PlayerPrefs.GetInt("LiveNumber", 0);
    //    return number;
    //}

    #region 获得道具数量
    public static void AddGameProps(GameProps gameProps, int value)
    {
        int number = PlayerPrefs.GetInt(gameProps + "LiveNumber", 0);
        PlayerPrefs.GetInt(gameProps + "LiveNumber", number + value);
    }

    public static void UseGameProps(GameProps gameProps, int value)
    {
        int number = PlayerPrefs.GetInt(gameProps + "LiveNumber", 0);
        PlayerPrefs.GetInt(gameProps + "LiveNumber", number - value);
    }

    public static int GetGameProps(GameProps gameProps)
    {
        int number = PlayerPrefs.GetInt(gameProps + "Number", 0);
        return number;
    }
    #endregion


}
