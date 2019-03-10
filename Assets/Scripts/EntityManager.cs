

public class EntityManager {
    static EntityManager instance;
    public static EntityManager Instance
    {
        get
        {
            if (instance == null)
                instance = new EntityManager();

            return instance;
        }
    }

    LevelEntity levelEntity = new LevelEntity();
    PlayerMinerEntity playerMinerEntity = new PlayerMinerEntity();

    public LevelEntity GetLevelEntity()
    {
        return levelEntity;
    }

    public PlayerMinerEntity GetPlayerMinerEntity()
    {
        return playerMinerEntity;
    }
}

