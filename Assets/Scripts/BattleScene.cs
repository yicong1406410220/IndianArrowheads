using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : MonoBehaviour {
    PlayerMiner playerMiner;

    void Start () {
        int level = 1;
        var levelDatas = LevelDataReader.GetLevelDatas(level);
        initLevelEntity(level, levelDatas);
        initPlayerEntity();
        loadBattleCanvas(level, levelDatas[0]);
        loadTreasures(levelDatas);
        loadPlayerMiner();
        loadWall();
    }

    void Update()
    {
        playerMiner.UpdateProcess();
        if (Input.GetKeyDown(KeyCode.A))
            BattleCanvas.Instance.AddScoreStar();
    }


    void initLevelEntity(int level, LevelData[] levelDatas)
    {
        var levelEntity = EntityManager.Instance.GetLevelEntity();
        levelEntity.levelDatas = levelDatas;
        levelEntity.level = level;
        levelEntity.passScore = Convert.ToInt32(levelDatas[0].target1.Split(',')[1]);
    }


    void initPlayerEntity()
    {
        var playerEntity = EntityManager.Instance.GetPlayerMinerEntity();
        playerEntity.score = 0;
        playerEntity.rewardDiamond = 0;
    }

	
    void loadBattleCanvas(int level, LevelData levelData)
    {
        BattleCanvas battleCanvas = BattleCanvas.Instance;
        battleCanvas.transform.SetParent(transform, false);
        battleCanvas.SetLevelText(level);

        if (level <= 20)
            battleCanvas.SetBgImage("GameMain_1_bg");
        else if (level <= 40)
            battleCanvas.SetBgImage("GameMain_2_bg");
        else if (level <= 60)
            battleCanvas.SetBgImage("GameMain_3_bg");
        else
            Debug.LogError("invalid level");

        string[] target1datas = levelData.target1.Split(',');
        string[] target2datas = levelData.target2.Split(',');
        if (levelData.isTimeOrStep == "0")
        {
            if(target2datas[0] == "-2")
                battleCanvas.SetScoreTipPanel("ScoreTip1");
            else if (target2datas[0] == "11")
                battleCanvas.SetScoreTipPanel("ScoreTip3");    
            else
                Debug.LogError("invalid target2datas[0]");


            battleCanvas.SetProp1Image("propTimeUp");
            battleCanvas.SetProp2Image("propStopBaby");
            battleCanvas.SetProp3Image("propBomb");

            battleCanvas.SetProp1Count(PlayerData.GetGameProps(GameProps.TimeUp));
            battleCanvas.SetProp2Count(PlayerData.GetGameProps(GameProps.StopBaby));
            battleCanvas.SetProp3Count(PlayerData.GetGameProps(GameProps.Bomb));
        }
        else if (levelData.isTimeOrStep == "1")
        {
            if (target2datas[0] == "-2")
                battleCanvas.SetScoreTipPanel("ScoreTip2");
            else if (target2datas[0] == "11")
                battleCanvas.SetScoreTipPanel("ScoreTip4");
            else
                Debug.LogError("invalid target2datas[0]");


            battleCanvas.SetProp1Image("propStepUp");
            battleCanvas.SetProp2Image("propStopBaby");
            battleCanvas.SetProp3Image("propBomb");

            battleCanvas.SetProp1Count(PlayerData.GetGameProps(GameProps.StepUp));
            battleCanvas.SetProp2Count(PlayerData.GetGameProps(GameProps.StopBaby));
            battleCanvas.SetProp3Count(PlayerData.GetGameProps(GameProps.Bomb));
        }
        else
            Debug.LogError("invalid levelData.isTimeOrStep");


        if (target2datas[0] == "11")
        {
            battleCanvas.GetScoreTipPanel().SetTarget2Icon("RescueObject_type11");
            battleCanvas.GetScoreTipPanel().SetTarget2Text(target2datas[1]);
        }

        battleCanvas.GetScoreTipPanel().SetTimeOrStep(Convert.ToInt32(levelData.timeStep));
        battleCanvas.GetScoreTipPanel().SetScoreText("0 / " + target1datas[1]);
    }


    void loadTreasures(LevelData[] levelDatas)
    {
        GameObject treasures = new GameObject("Treasures");
        treasures.transform.SetParent(transform, false);

        const int rangeWidth = 1280;
        const int rangeHeight = 768;
        const int pixelsPerUnit = 100;
        foreach (var levelData in levelDatas)
        {
            if (levelData.isShow == "1")
            {
                string[] posData = levelData.pos.Split(',');
                var treasure = TreasureCreator.Create(levelData);
                float x = (Convert.ToSingle(posData[0]) - rangeWidth * 0.5f) / pixelsPerUnit;
                float y = (Convert.ToSingle(posData[1]) - rangeHeight * 0.5f) / pixelsPerUnit;

                treasure.transform.position = new Vector3(x, y, 0);
                treasure.transform.SetParent(treasures.transform, false);
            }
        }
    }


    void loadWall()
    {
        GameObject.Instantiate(Resources.Load<GameObject>("Prefabs/Wall"), transform, false);
    }


    void loadPlayerMiner()
    {
        playerMiner = GameObject.Instantiate(Resources.Load<PlayerMiner>("Prefabs/PlayerMiner"));
        playerMiner.transform.position = new Vector3(0, Camera.main.orthographicSize - 1.1f, 0);
        playerMiner.transform.SetParent(transform);
        BattleCanvas.Instance.AddMinerControlDetector(playerMiner);
    }
}
