using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : PanelBase {

    public static WinPanel instance;

    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = PanelLayer.Panel;
        instance = this;
        int GateLevel = PlayerPrefs.GetInt("DB_GateLevel");
        if (GateLevel == DataManager.instance.PlayLV)
        {
            GateLevel++;
            PlayerPrefs.SetInt("DB_GateLevel", GateLevel);
        }
    }

    public override void OnShowing()
    {
        base.OnShowing();

    }

    public void OnLVButton()
    {
        SoundManager.instance.PlayBtn();
        SceneJump.instance.Jump(SceneType.Map);
    }

    public void OnReplayButton()
    {
        SoundManager.instance.PlayBtn();
        SceneJump.instance.Jump(SceneType.Game);
    }

    public void OnNextButton()
    {
        SoundManager.instance.PlayBtn();
        DataManager.instance.PlayLV++;
        SceneJump.instance.Jump(SceneType.Game);
    }
}
