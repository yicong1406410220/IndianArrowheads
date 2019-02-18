using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPanel : PanelBase {

    public static KeyPanel instance;

    public InputField inputField;

    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = PanelLayer.Panel;
        instance = this;
        
    }

    public override void OnShowing()
    {
        base.OnShowing();
    }

    public void InputKey()
    {
        string KEY = inputField.text;        
        ENDKEY(KEY);
    }

    private void ENDKEY(string key)
    {
        string[] KeyStr = key.Split(' ');
        if (KeyStr[0] == "open")
        {
            int DB_GateLevel = PlayerPrefs.GetInt("DB_GateLevel", 0);
            int GateLevel = Convert.ToInt32(KeyStr[1]);
            if (GateLevel > DB_GateLevel)
            {
                for (int i = DB_GateLevel + 1; i < GateLevel + 1; i++)
                {
                    OpenALLStar(i);
                }
                //ÉèÖÃ¹Ø¿¨
                PlayerPrefs.SetInt("DB_GateLevel", GateLevel);
            }
            Close();
        }
    }

    private void OpenALLStar(int i)
    {
        KeyValue.SetBool("DB_LV" + i + "StarNumber1", true);
        KeyValue.SetBool("DB_LV" + i + "StarNumber2", true);
        KeyValue.SetBool("DB_LV" + i + "StarNumber3", true);
    }
}
