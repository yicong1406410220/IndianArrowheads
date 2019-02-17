using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondStorePanel : PanelBase {

    public static DiamondStorePanel instance;

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

    public void OnClickBtn1()
    {
        SoundManager.instance.PlayBtn();
        PlayerData.AddDiamond(30);
        Close();
    }

    public void OnClickBtn2()
    {
        SoundManager.instance.PlayBtn();
        PlayerData.AddDiamond(70);
        Close();
    }

    public void OnClickBtn3()
    {
        SoundManager.instance.PlayBtn();
        PlayerData.AddDiamond(180);
        Close();
    }

    public void OnClickBtn4()
    {
        SoundManager.instance.PlayBtn();
        PlayerData.AddDiamond(250);
        Close();
    }

}
