using UnityEngine;


[System.Serializable]
public class LevelData
{
    public string total;
    public string level;
    public string timeStep;
    public string isTimeOrStep;
    public string target1;
    public string target2;
    public string type;
    public string blood;
    public string pos;
    public string isCure;
    public string isStop;
    public string isShow;
    public string isOnNum;
    public string isSpeed;
    public string height;
    public string route;

    public override string ToString()
    {
        return "total: " + total
             + ", level: " + level
             + ", timeStep: " + timeStep
             + ", isTimeOrStep: " + isTimeOrStep
             + ", target1: " + target1
             + ", target2: " + target2
             + ", type: " + type
             + ", blood: " + blood
             + ", pos: " + pos
             + ", isCure: " + isCure
             + ", isStop: " + isStop
             + ", isShow: " + isShow
             + ", isOnNum: " + isOnNum
             + ", isSpeed: " + isSpeed
             + ", height: " + height
             + ", route: " + route;
    }
}


public static class LevelDataReader {
    private class LevelDataArray
    {
        public LevelData[] json;
    }

    public static LevelData[] GetLevelDatas(int level)
    {
        string jsonText = Resources.Load<TextAsset>("Levels/level" + level).text;
        return JsonUtility.FromJson<LevelDataArray>(jsonText).json;
    }
}

