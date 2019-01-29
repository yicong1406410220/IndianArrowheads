using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abPanel : PanelBase {


    public override void Init(params object[] args)
    {
        base.Init(args);
        skinPath = "abPanel";
        layer = PanelLayer.Panel;
        
    }

    public override void OnShowing()
    {
        base.OnShowing();

    }


}
