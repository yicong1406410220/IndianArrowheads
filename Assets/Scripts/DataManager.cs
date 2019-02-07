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
    void Start () {
        string path = Application.streamingAssetsPath+ "/Form/hello.xlsx";
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            using (ExcelPackage excel = new ExcelPackage(fs))
            {
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;
                for  (int i = 1; i <= workSheets.Count; i++)
                {
                    ExcelWorksheet workSheet = workSheets[i];
                    int colCount = workSheet.Dimension.End.Column;
                    Debug.LogFormat("Sheet {0}", workSheet.Name);
                    for (int row = 1, count = workSheet.Dimension.End.Row; row <= count; row++)
                    {
                        for (int col = 1; col <= colCount; col++)
                        {
                            var text = workSheet.Cells[row, col].Text ?? "";
                            Debug.LogFormat("下标： {0},{1} 内容：{2}", row, col, text);
                        }
                    }
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
