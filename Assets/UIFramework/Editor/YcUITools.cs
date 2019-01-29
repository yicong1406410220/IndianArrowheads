using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.IO;

public class YcUITools : Editor {

    public const string tempPath = "/UIFramework/Editor/Templete/";
    public const string detailPanelPath = "/Scripts/UIPanel/";

    [MenuItem("Tools/生成UI #&C", false, 1)]
    static public void CreateUIPage()
    {
        GameObject active = UnityEditor.Selection.activeGameObject;

        if (null == active || active.name == "Panel" || !active.name.EndsWith("Panel"))
        {
            EditorUtility.DisplayDialog("提示！", "请在Hierarchy面板选择一个UI文件(以Panel结尾)", "是");
            return;
        }

        if (active.name.EndsWith("Panel"))
        {
            CreateUI();
        }
    }

    private static void CreateUI()
    {
        GameObject active = UnityEditor.Selection.activeGameObject;
        string scriptName = active.name;
        string PanelPath = CreatePanel(scriptName);
        if(PanelPath == "")
        {
            Debug.LogWarning("UI脚本没有生成，如需重新生成请删除 "  + Application.dataPath + detailPanelPath + scriptName + ".cs");
        }
        else
        {
            Debug.LogWarning("UI脚本生成完成 path = " + PanelPath);
        }        
        // 刷新编辑器，使刚创建的资源立刻被导入，才能接下来立刻使用上该资源
        AssetDatabase.Refresh();
    }

    private static string CreatePanel(string scriptName)
    {
        if (!Directory.Exists(Application.dataPath + detailPanelPath + "/"))
            Directory.CreateDirectory(Application.dataPath + detailPanelPath + "/");
        if (System.IO.File.Exists(Application.dataPath + detailPanelPath + "/" + scriptName + ".cs"))
        {
            Debug.LogWarning(" 文件已经存在 " + scriptName);
            return "";
        }

        string temp = GetTemplete("UIPanelTemplet");
        temp = temp.Replace("<ScriptNamePanel>", scriptName);
        temp = temp.Replace("<ScriptNameBase>", "PanelBase");
        temp = temp.Replace("<skinPath>", scriptName);
        string outPutFile = Application.dataPath + detailPanelPath + "/" + scriptName + ".cs";
        Save(outPutFile, temp);
        return outPutFile;
    }

    private static string GetTemplete(string tempName)
    {
        TextAsset textAsset = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets" + tempPath + tempName + ".txt");
        string temp = textAsset.text;
        return temp;
    }

    static void Save(string outPutFile, string uiScript)
    {
        StreamWriter sw = new StreamWriter(outPutFile, false);
        sw.Write(uiScript);
        sw.Close();
        AssetDatabase.SaveAssets();
    }
}
