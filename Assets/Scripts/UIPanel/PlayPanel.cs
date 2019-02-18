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

    // Use this for initialization
    void Start()
    {
        StartCoroutine(LiveUpdate());
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


}
