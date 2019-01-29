using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelBase : MonoBehaviour {
    //皮肤路径
    public string skinPath;

    //皮肤
    public GameObject skin;

    //层级
    public PanelLayer layer;

    //面板参数
    public object[] args;

    #region 生命周期
    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="args"></param>
    public virtual void Init(params object[] args)
    {
        this.args = args;
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
        string name = this.GetType().ToString();
        PanelMgr.instance.ClosePanel(name);
    }

    #endregion

    // Use this for initialization
    void Start () {

		
	}
	
	
}
