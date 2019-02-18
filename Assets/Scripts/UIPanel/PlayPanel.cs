using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPanel : PanelBase {

    public static PlayPanel instance;

    public Text LiveNumber;
    public Text LiveTime;
    public Text GemNumber;

    public GameObject[] hints;
    public GameObject[] PropFronts;
    public Button[] PropButtons;

    public bool[] SelectionStatuss = new bool[6];

    // Use this for initialization
    void Start()
    { 
        StartCoroutine(LiveUpdate());
        for (int i = 0; i < SelectionStatuss.Length; i++)
        {
            SelectionStatuss[i] = false;
        }

    }

    private IEnumerator LiveUpdate()
    {
        while (true)
        {
            LiveNumber.text = PlayerData.GetLive().ToString();
            LiveTime.text = PlayerData.GetLiveRecoverTimeString().ToString();
            GemNumber.text = PlayerData.GetDiamond().ToString();
            yield return new WaitForSeconds(1.0f);
        }

    }

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

    public override void OpenAnimation()
    {
        OnShowing();
        Transform bg = gameObject.transform.Find("bg");
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(bg.DOScale(1.1f, 0.3f)).Append(bg.DOScale(1f, 0.2f)).AppendCallback(() => { OnShowed(); });

    }


    public void OpenDiamondStorePanel()
    {
        SoundManager.instance.PlayBtn();
        PanelMgr.instance.OpenPanel<DiamondStorePanel>("");
    }

    //public void OpenGoldStorePanel()
    //{
    //    SoundManager.instance.PlayBtn();
    //    PanelMgr.instance.OpenPanel<GoldStorePanel>("");
    //}

    public void OpenPowerStorePanel()
    {
        SoundManager.instance.PlayBtn();
        PanelMgr.instance.OpenPanel<PowerStorePanel>("");
    }


}
