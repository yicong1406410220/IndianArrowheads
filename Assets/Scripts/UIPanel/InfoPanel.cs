using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoPanel : PanelBase {

    Button CloseButton;

    public override void Init(params object[] args)
    {
        base.Init(args);
        layer = PanelLayer.Panel;
        
    }

    public override void OnShowing()
    {
        base.OnShowing();
        Transform skinTrans = transform;
        CloseButton = skinTrans.Find("CloseButton").GetComponent<Button>();
        CloseButton.onClick.AddListener(Close);
    }



}
