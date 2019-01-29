using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitlePanel : PanelBase {

    Button startBtn;
    Button infoBtn;

    public override void Init(params object[] args)
    {
        base.Init(args);
        skinPath = "TitlePanel";
        layer = PanelLayer.Panel;

    }

    public override void OnShowing()
    {
        base.OnShowing();
        Transform skinTrans = skin.transform;
        startBtn = skinTrans.Find("StartBtn").GetComponent<Button>();
        infoBtn = skinTrans.Find("InfoBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(OnStartClick);
        infoBtn.onClick.AddListener(OnInfoClick);

    }

    private void OnInfoClick()
    {
        PanelMgr.instance.OpenPanel<InfoPanel>("");
    }

    private void OnStartClick()
    {
        Debug.Log("游戏开始!");
        Close();
    }
}
