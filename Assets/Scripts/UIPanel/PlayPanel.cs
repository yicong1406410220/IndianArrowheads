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

    private int UseDiamondNumber = 0;

    // Use this for initialization
    void Start()
    { 
        StartCoroutine(LiveUpdate());
        for (int i = 0; i < SelectionStatuss.Length; i++)
        {
            SelectionStatuss[i] = false;
        }
        PropButtons[0].onClick.AddListener(OnPropButton0);
        PropButtons[1].onClick.AddListener(OnPropButton1);
        PropButtons[2].onClick.AddListener(OnPropButton2);
        PropButtons[3].onClick.AddListener(OnPropButton3);
        PropButtons[4].onClick.AddListener(OnPropButton4);
        PropButtons[5].onClick.AddListener(OnPropButton5);
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

    public void OnPropButton0()
    {
        OnPropButton(0, 30);
    }

    public void OnPropButton1()
    {
        OnPropButton(1, 10);
    }

    public void OnPropButton2()
    {
        OnPropButton(2, 10);
    }

    public void OnPropButton3()
    {
        OnPropButton(3, 10);
    }

    public void OnPropButton4()
    {
        OnPropButton(4, 10);
    }

    public void OnPropButton5()
    {
        OnPropButton(5, 20);
    }

    private void OnPropButton(int value, int NeedDiamond)
    {
        SoundManager.instance.PlayBtn();
        Debug.Log("value = " + value);
        if (SelectionStatuss[value] == false)
        {
            if (UseDiamondNumber + NeedDiamond <= PlayerData.GetDiamond())
            {
                SelectionStatuss[value] = true;
                UseDiamondNumber = UseDiamondNumber + NeedDiamond;
                PropFronts[value].SetActive(true);
            }
            else
            {
                PanelMgr.instance.OpenPanel<DiamondStorePanel>("");
            }
        }
        else
        {
            SelectionStatuss[value] = false;
            UseDiamondNumber = UseDiamondNumber - NeedDiamond;
            PropFronts[value].SetActive(false);
        }
    }
}
