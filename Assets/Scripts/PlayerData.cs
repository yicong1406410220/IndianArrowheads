using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData {

    public static void AddGold(int value)
    {
        int gold = PlayerPrefs.GetInt("GoldNumber", 0);
        PlayerPrefs.GetInt("GoldNumber", gold + value);
    }

    public static void UseGold(int value)
    {
        int gold = PlayerPrefs.GetInt("GoldNumber", 0);
        PlayerPrefs.GetInt("GoldNumber", gold - value);
    }

    public static int GetGold()
    {
        int gold = PlayerPrefs.GetInt("GoldNumber", 0);
        return gold;
    }

    public static void AddDiamond(int value)
    {
        int gold = PlayerPrefs.GetInt("DiamondNumber", 0);
        PlayerPrefs.GetInt("DiamondNumber", gold + value);
    }

    public static void UseDiamond(int value)
    {
        int gold = PlayerPrefs.GetInt("DiamondNumber", 0);
        PlayerPrefs.GetInt("DiamondNumber", gold - value);
    }

    public static int GetDiamond()
    {
        int gold = PlayerPrefs.GetInt("DiamondNumber", 0);
        return gold;
    }

    public static void AddLive(int value)
    {
        int gold = PlayerPrefs.GetInt("LiveNumber", 0);
        PlayerPrefs.GetInt("LiveNumber", gold + value);
    }

    public static void UseLive(int value)
    {
        int gold = PlayerPrefs.GetInt("LiveNumber", 0);
        PlayerPrefs.GetInt("LiveNumber", gold - value);
    }

    public static int GetLive()
    {
        int gold = PlayerPrefs.GetInt("LiveNumber", 0);
        return gold;
    }
}
