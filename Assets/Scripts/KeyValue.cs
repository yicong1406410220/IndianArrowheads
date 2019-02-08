using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 键值处理
/// </summary>
public static class KeyValue{

    [MenuItem("Tools/清除PlayPrefeb #&D", false, 1)]
    static public void DeleteAll()
    {
        PlayerPrefs.DeleteAll();
    }


    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key, 0);
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static float GetFloat(string key)
    {
        return PlayerPrefs.GetFloat(key, 0);
    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public static string GetString(string key)
    {
        return PlayerPrefs.GetString(key, "");
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
}
