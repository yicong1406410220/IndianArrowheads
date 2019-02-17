using System;
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

    public static void AddLive()
    {
        double LiveCoolingTime = KeyValue.GetDouble("LiveCoolingTime", 0);
        double DTime = LiveCoolingTime - TimeManager.GetNow();
        if (DTime <= 0)
        {
            int AdditionalLiveNumber = PlayerPrefs.GetInt("AdditionalLiveNumber", 0);
            PlayerPrefs.SetInt("AdditionalLiveNumber", AdditionalLiveNumber + 1);
        }
        else
        {
            if (DTime > 10 * 60)
            {
                KeyValue.SetDouble("LiveCoolingTime", LiveCoolingTime - 10 * 60);
            }
            else
            {
                KeyValue.SetDouble("LiveCoolingTime", TimeManager.GetNow());
                PlayerPrefs.SetInt("AdditionalLiveNumber", 0);
            }           
        }
    }

    public static int GetLive()
    {
        int number;
        double LiveCoolingTime = KeyValue.GetDouble("LiveCoolingTime", 0);
        double DTime = LiveCoolingTime - TimeManager.GetNow();
        if (DTime <= 0)
        {
            int AdditionalLiveNumber = PlayerPrefs.GetInt("AdditionalLiveNumber", 0);
            number = 5 + AdditionalLiveNumber;
        }
        else
        {            
            number = 5;
            while (DTime > 0)
            {
                number--;
                DTime = DTime - 10 * 60;
            }
        }        
        return number;
    }

    public static void UseLive()
    {
        double LiveCoolingTime = KeyValue.GetDouble("LiveCoolingTime", 0);
        double DTime = LiveCoolingTime - TimeManager.GetNow();
        if (DTime <= 0)
        {
            int AdditionalLiveNumber = PlayerPrefs.GetInt("AdditionalLiveNumber", 0);
            if (AdditionalLiveNumber - 1 >= 0)
            {
                PlayerPrefs.SetInt("AdditionalLiveNumber", AdditionalLiveNumber - 1);
            }
            else
            {
                KeyValue.SetDouble("LiveCoolingTime", TimeManager.GetNow() + 10 * 60);
            }
            
        }
        else
        {
            KeyValue.SetDouble("LiveCoolingTime", LiveCoolingTime + 10 * 60);           
        }

    }

    /// <summary>
    /// 下一次恢复体力的冷却时间
    /// </summary>
    /// <returns></returns>
    public static double GetLiveRecoverTime()
    {
        double LiveRecoverTime;
        double LiveCoolingTime = KeyValue.GetDouble("LiveCoolingTime", 0);
        double DTime = LiveCoolingTime - TimeManager.GetNow();
        if (DTime <= 0)
        {
            LiveRecoverTime = -1;
        }
        else
        {
            LiveRecoverTime = DTime;
        }
        return LiveRecoverTime;
    }

    public static string GetLiveRecoverTimeString()
    {
        string LiveRecoverTimeString;
        int LiveRecoverTime = (int)GetLiveRecoverTime();
        LiveRecoverTime = LiveRecoverTime % (10 * 60);
        if (LiveRecoverTime >= 0)
        {
            int a = LiveRecoverTime / 60;
            int b = LiveRecoverTime % 60;
            string A;
            string B;
            if (a < 10)
            {
                A = "0" + a;          
            }
            else
            {
                A = "" + a;
            }

            if (b < 10)
            {
                B = "0" + b;
            }
            else
            {
                B = "" + b;
            }

            LiveRecoverTimeString = A + ":" + B;
        }
        else
        {
            LiveRecoverTimeString = "full";
        }

        return LiveRecoverTimeString;
    }

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
