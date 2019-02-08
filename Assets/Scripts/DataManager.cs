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
        hello = ExcelDocumentsParse.LoadExcel("hello");
    }

    public Dictionary<string, Dictionary<string, string>> hello;

    // Update is called once per frame
    void Update () {
		
	}
}
