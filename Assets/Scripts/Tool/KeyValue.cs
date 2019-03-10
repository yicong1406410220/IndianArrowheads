using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System;

/// <summary>
/// 键值处理
/// </summary>
public static class KeyValue{

#if UNITY_EDITOR
    [MenuItem("Tools/清除PlayPres #&D", false, 1)]
#endif
    static public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }


    public static void SetDouble(string key, double value)
    {
        PlayerPrefs.SetString(key, value.ToString());
    }

    public static double GetDouble( string key, double value)
    {
        string str = PlayerPrefs.GetString(key, "");
        if (str == "")
        {
            return value;
        }
        double val = Convert.ToDouble(str);
        return val;
    }

    public static void SetBool(string key, bool value)
    {
        if (value)
            PlayerPrefs.SetInt(key, 1);
        else
            PlayerPrefs.SetInt(key, 0);
    }

    public static bool GetBool(string key)
    {
        int val = PlayerPrefs.GetInt(key, 0);
        if (val == 1)
            return true;
        return false;
    }

    public static bool GetBool(string key, bool value)
    {
        int val = PlayerPrefs.GetInt(key, 0);
        if (val == 1)
            return true;
        return value;
    }
}
