using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelBase : MonoBehaviour {

    //层级
    public PanelLayer layer;

    //面板参数
    public object[] args;

    private Button CloseButton;

    #region 生命周期
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="args"></param>
    public virtual void Init(params object[] args)
    {
        this.args = args;
        //panel的生命周期
        OpenAnimation();
        Transform CloseTf = gameObject.transform.Find("CloseButton");
        if (CloseTf != null)
        {
            CloseButton = CloseTf.GetComponent<Button>();
            CloseButton.onClick.AddListener(OnCloseBotton);
        }
    }

    private void OnCloseBotton()
    {
        Close();
    }

    /// <summary>
    /// 显示面板前
    /// </summary>
    public virtual void OnShowing() { }

    /// <summary>
    /// 显示面板后
    /// </summary>
    public virtual void OnShowed() { }

    /// <summary>
    /// 帧更新
    /// </summary>
    public virtual void Update() { }

    /// <summary>
    /// 关闭前
    /// </summary>
    public virtual void OnClosing() { }

    /// <summary>
    /// 关闭后
    /// </summary>
    public virtual void OnClosed() { }

    #endregion

    #region 操作
    public virtual void Close()
    {
        string PanelName = this.GetType().ToString();
        PanelMgr.instance.ClosePanel(PanelName);
    }

    #endregion

    // Use this for initialization
    void Start () {

		
	}

    public virtual void OpenAnimation()
    {
        OnShowing();
        //Tweener tweener = transform.DOLocalMoveX(-1300, 2f).From();
        //tweener.SetEase(Ease.InOutBack);
        //tweener.OnComplete(() => { OnShowed(); });
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOScale(1.1f, 0.3f)).Append(transform.DOScale(1f, 0.2f)).AppendCallback(() => { OnShowed(); });

    }

    public virtual void CloseAnimation()
    {
        OnClosing();
        //Tweener tweener = transform.DOLocalMoveX(1300, 2f);
        //tweener.SetEase(Ease.OutBack);
        //tweener.OnComplete(() => {
        //    OnClosed();
        //    GameObject.Destroy(gameObject);
        //});
        OnClosed();
        GameObject.Destroy(gameObject);
    }
}
