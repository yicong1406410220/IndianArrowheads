using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldStorePanel : PanelBase {

    public static GoldStorePanel instance;

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
        UseDiamondAddGold(10, 3500);
    }

    public void OnClickBtn2()
    {
        SoundManager.instance.PlayBtn();
        UseDiamondAddGold(50, 17500);
    }

    public void OnClickBtn3()
    {
        SoundManager.instance.PlayBtn();
        UseDiamondAddGold(100, 35000);
    }

    public void OnClickBtn4()
    {
        SoundManager.instance.PlayBtn();
        UseDiamondAddGold(300, 105000);
    }

    private void UseDiamondAddGold(int useDiamond, int addGold)
    {
        int Diamond = PlayerData.GetDiamond();
        if (Diamond < useDiamond)
        {
            PanelMgr.instance.OpenPanel<DiamondStorePanel>("");
        }
        else
        {
            PlayerData.UseDiamond(useDiamond);
            PlayerData.AddGold(addGold);
            Close();
        }
    }
}
