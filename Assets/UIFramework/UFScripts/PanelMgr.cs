using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMgr : MonoBehaviour {

    public static PanelMgr instance;

    //画布
    private GameObject canvas;

    //面板
    public Dictionary<string, PanelBase> dict;

    //层级
    public Dictionary<PanelLayer, Transform> layerDict;

    public void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        //DontDestroyOnLoad(gameObject);
        InitLayer();
        dict = new Dictionary<string, PanelBase>();


    }

    /// <summary>
    ///  初始化
    /// </summary>
    private void InitLayer()
    {
        canvas = GameObject.Find("UICanvas");
        if (canvas == null)
        {
            Debug.LogError("panelMgr.InitLayer Canvas is null!");
        }
        //各个层级
        layerDict = new Dictionary<PanelLayer, Transform>();

        foreach (PanelLayer p1 in Enum.GetValues(typeof(PanelLayer)))
        {
            string name = p1.ToString();
            Transform transform = canvas.transform.Find(name);
            layerDict.Add(p1, transform);

        }
    }

    /// <summary>
    /// 打开面板
    /// </summary>
    public void OpenPanel<T>(params object[] args) where T : PanelBase
    {
        //已经打开
        string PanelName = typeof(T).ToString();
        if (dict.ContainsKey(PanelName))
        {
            return;
        }
        GameObject GoPanel = Resources.Load<GameObject>("Panel/" + PanelName);
        if (GoPanel == null)
        {
            Debug.LogError("panelMgr.Openpanel fail， Panel is null， PanelName = " + PanelName);
        }
        T panelScript = ((GameObject)Instantiate(GoPanel)).GetComponent<T>();
        dict.Add(PanelName, panelScript);
        panelScript.Init(args);
        //坐标
        Transform PanelTrans = panelScript.transform;
        PanelLayer layer = panelScript.layer;
        Transform parent = layerDict[layer];
        PanelTrans.SetParent(parent, false);
        //panel的生命周期
        panelScript.OnShowing();
        Tweener tweener = PanelTrans.DOLocalMoveX(-1300, 2f).From();
        tweener.SetEase(Ease.InOutBack);
        tweener.OnComplete(() => { panelScript.OnShowed(); });

    }

    //关闭面板
    public void ClosePanel(string name)
    {
        PanelBase panel = (PanelBase)dict[name];
        if (panel == null)
        {
            return;
        }
        panel.OnClosing();
        dict.Remove(name);
       
        Tweener tweener = panel.transform.DOLocalMoveX(1300, 2f);
        tweener.SetEase(Ease.OutBack);
        tweener.OnComplete(() => {
            panel.OnClosed();
            GameObject.Destroy(panel.gameObject);
        });
        
    }


    // 仅在首次调用 Update 方法之前调用 Start
    void Start()
    {

    }



    // Update is called once per frame
    void Update () {
		
	}
}


public enum PanelLayer
{
    Panel,
    Tips,
}
