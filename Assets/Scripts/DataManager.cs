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
        Debug.Log(ReadExcel("hello", 1, 3, 2));
        //ReadExcel("", 1 , 1, 2);
    }

    public Dictionary<string, Dictionary<string, string>> hello;


    public static Dictionary<string, Dictionary<string, string>> LoadExcel(string path , int WhichTable = 1)
    {
        Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
        //dic.Add(ReadExcel(path, 1, 2, 2));

    }


    /// <summary>
    /// 读取Excel
    /// </summary>
    /// <param name="FileName">文件名</param>
    /// <param name="WhichTable">第几张表</param>
    /// <param name="Whichline">第几行</param>
    /// <param name="HowManyColumns">第几列</param>
    public static string ReadExcel(string FileName, int WhichTable, int Whichline, int HowManyColumns)
    {
        string path = Application.streamingAssetsPath + "/Excel/" + FileName + ".xlsx";
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (ExcelPackage excel = new ExcelPackage(fs))
            {
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;
                if (!(WhichTable >= 1 && WhichTable <= workSheets.Count))
                {
                    Debug.LogErrorFormat("工作表不存在 FileName = {0}; WhichTable = {1}; Whichline = {2}; HowManyColumns = {3}", FileName, WhichTable, Whichline, HowManyColumns);
                }
                ExcelWorksheet workSheet = workSheets[WhichTable];               
                int rowCount = workSheet.Dimension.End.Row;
                int colCount = workSheet.Dimension.End.Column;             
                if (!(HowManyColumns >= 1 && HowManyColumns <= colCount))
                {
                    Debug.LogErrorFormat("列越界 FileName = {0}; WhichTable = {1}; Whichline = {2}; HowManyColumns = {3}", FileName, WhichTable, Whichline, HowManyColumns);
                }
                if (!(Whichline >= 1 && Whichline <= rowCount))
                {
                    Debug.LogErrorFormat("行越界 FileName = {0}; WhichTable = {1}; Whichline = {2}; HowManyColumns = {3}", FileName, WhichTable, Whichline, HowManyColumns);
                }
                var text = workSheet.Cells[Whichline, HowManyColumns].Text ?? "";
                return text;
            }
        }
    }

    /// <summary>
    /// 读取Excel一共有几张工作表
    /// </summary>
    /// <param name="FileName">文件名</param>
    public static int ReadExcelWhichTableNumber(string FileName)
    {
        string path = Application.streamingAssetsPath + "/Excel/" + FileName + ".xlsx";
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (ExcelPackage excel = new ExcelPackage(fs))
            {
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;
                return workSheets.Count;
            }
        }
    }

    /// <summary>
    /// 读取Excel行数
    /// </summary>
    /// <param name="FileName">文件名</param>
    /// <param name="WhichTable">第几张表</param>
    public static int ReadExcelRow(string FileName, int WhichTable)
    {
        string path = Application.streamingAssetsPath + "/Excel/" + FileName + ".xlsx";
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (ExcelPackage excel = new ExcelPackage(fs))
            {
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;
                if (!(WhichTable >= 1 && WhichTable <= workSheets.Count))
                {
                    Debug.LogErrorFormat("工作表不存在 FileName = {0}; WhichTable = {1};", FileName, WhichTable);
                }
                ExcelWorksheet workSheet = workSheets[WhichTable];
                int rowCount = workSheet.Dimension.End.Row;
                return rowCount;
            }
        }
    }

    /// <summary>
    /// 读取Excel列数
    /// </summary>
    /// <param name="FileName">文件名</param>
    /// <param name="WhichTable">第几张表</param>
    public static int ReadExcelCol(string FileName, int WhichTable)
    {
        string path = Application.streamingAssetsPath + "/Excel/" + FileName + ".xlsx";
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (ExcelPackage excel = new ExcelPackage(fs))
            {
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;
                if (!(WhichTable >= 1 && WhichTable <= workSheets.Count))
                {
                    Debug.LogErrorFormat("工作表不存在 FileName = {0}; WhichTable = {1};", FileName, WhichTable);
                }
                ExcelWorksheet workSheet = workSheets[WhichTable];
                int colCount = workSheet.Dimension.End.Column;
                return colCount;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
