using UnityEngine;
using System;


public static class TreasureCreator {
    public static Treasure Create(LevelData levelData)
    {
        TreasureID treasureID = (TreasureID)Convert.ToInt32(levelData.type);
        if (treasureID == TreasureID.MinGold)
            return Create("MinGold");
        else if (treasureID == TreasureID.MidGold)
            return Create("MidGold");
        else if (treasureID == TreasureID.MinDiamond)
            return Create("MinDiamond");
        else if (treasureID == TreasureID.Chest)
            return Create("Chest");
        else if (treasureID == TreasureID.SigleMouse)
        {
            Treasure treasure = Create("SigleMouse");
            if (Convert.ToInt32(levelData.total) % 2 != 0)
            {
                treasure.transform.localScale = new Vector3(1, -1, 1);
                treasure.transform.Rotate(new Vector3(0, 0, 180));
            }
            
            return treasure;
        }    
        else if (treasureID == TreasureID.MinStone)
            return Create("MinStone");
        else if (treasureID == TreasureID.DiamondMouse)
            return Create("DiamondMouse");
        else if (treasureID == TreasureID.MidStone)
            return Create("MidStone");
        else if (treasureID == TreasureID.BigGold)
            return Create("BigGold");
        else   
            Debug.LogWarning("not match treasure id: " + treasureID);

        return Create("Unknown");
    }
	
    static Treasure Create(string name)
    {
        return GameObject.Instantiate(Resources.Load<Treasure>("Prefabs/Treasures/" + name));
    }
}
