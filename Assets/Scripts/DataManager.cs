using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;

public class DataManager : MonoBehaviour {

    public static DataManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start ()
    {
        DB_Hello = ExcelDocumentsParse.LoadExcel("hello");
        Debug.Log(DB_Hello["1"]["name"]);
    }

    public Dictionary<string, Dictionary<string, string>> DB_Hello;

    // Update is called once per frame
    void Update () {
		
	}
}
