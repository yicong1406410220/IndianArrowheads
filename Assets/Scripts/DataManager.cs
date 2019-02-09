using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OfficeOpenXml;
using System.IO;
using System;

public class DataManager : MonoBehaviour {

    public static DataManager instance;

    public Dictionary<string, Dictionary<string, string>> DB_Player;
    public Dictionary<string, Dictionary<string, string>> DB_Digger;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDB();
    }

    private void LoadDB()
    {
        DB_Player = ExcelDocumentsParse.LoadExcel("Player");
        DB_Digger = ExcelDocumentsParse.LoadExcel("Digger");
    }

   

    // Use this for initialization
    void Start ()
    {


    }


    // Update is called once per frame
    void Update () {
		
	}
}
