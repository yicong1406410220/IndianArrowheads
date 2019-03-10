using UnityEngine;


public enum ChestTreasureID
{
    Gold,
    Stone,
    MinDiamond,
    MidDiamond
}


public static class ChestTreasureCreator {
    public static Treasure Create(ChestTreasureID treasureID)
    {
        if (treasureID == ChestTreasureID.Gold)
            return Create("ChestGold");
        else if (treasureID == ChestTreasureID.Stone)
            return Create("ChestStone");
        else if (treasureID == ChestTreasureID.MinDiamond)
            return Create("ChestMinDiamond");
        else if (treasureID == ChestTreasureID.MidDiamond)
            return Create("ChestMidDiamond");
        else
            Debug.LogWarning("not match treasure id: " + treasureID);

        return Create("Unknown");
    }

    static Treasure Create(string name)
    {
        return GameObject.Instantiate(Resources.Load<Treasure>("Prefabs/Treasures/" + name));
    }
}
