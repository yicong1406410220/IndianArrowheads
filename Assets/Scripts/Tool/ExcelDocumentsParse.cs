using System.Collections;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;
using UnityEngine;

public static class ExcelDocumentsParse
{

    /// <summary>
    /// 将excel解析成字典
    /// </summary>
    /// <param name="path"></param>
    /// <param name="WhichTable"></param>
    /// <returns></returns>
    public static Dictionary<string, Dictionary<string, string>> LoadExcel(string path, int WhichTable = 1)
    {
        Dictionary<string, Dictionary<string, string>> dic = new Dictionary<string, Dictionary<string, string>>();
        for (int i = 3; i <= ReadExcelRow(path, WhichTable); i++)
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            for (int j = 2; j <= ReadExcelCol(path, WhichTable); j++)
            {
                keyValues.Add(ReadExcel(path, WhichTable, 2, j), ReadExcel(path, WhichTable, i, j));
            }
            dic.Add(ReadExcel(path, WhichTable, i, 1), keyValues);
        }
        return dic;
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
}
