using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerStorePanel : PanelBase {

    public static PowerStorePanel instance;

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
        UseDiamondAddLive(15, 5);
    }

    public void OnClickBtn2()
    {
        SoundManager.instance.PlayBtn();
        UseDiamondAddLive(30, 11);
    }

    public void OnClickBtn3()
    {
        SoundManager.instance.PlayBtn();
        UseDiamondAddLive(60, 24);
    }

    public void OnClickBtn4()
    {
        SoundManager.instance.PlayBtn();
        UseDiamondAddLive(120, 52);
    }


    private void UseDiamondAddLive(int useDiamond, int addLive)
    {
        int Diamond = PlayerData.GetDiamond();
        if (Diamond < useDiamond)
        {
            PanelMgr.instance.OpenPanel<DiamondStorePanel>("");
        }
        else
        {
            PlayerData.UseDiamond(useDiamond);
            PlayerData.AddLive(addLive);
            Close();
        }
    }

}
