using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEntity
{
    public LevelData[] levelDatas;
    public int level;
    public int passScore;
    public int perAddStarScore;
    public bool isTimeOrStep;
    public int timeStep;
    public bool isPause;
}


public class PlayerMinerEntity
{
    public int rewardDiamond;
    public int score;
    public string prop1;
    public string prop2;
    public string prop3;
    public int starCount;
}
