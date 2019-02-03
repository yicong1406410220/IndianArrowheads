using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayPanel : PanelBase {

    public static PlayPanel instance;

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
