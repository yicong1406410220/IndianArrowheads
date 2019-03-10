using UnityEngine;



public enum TreasureID
{
    MinGold = 0,
    MidGold = 1,
    BigGold = 2,
    MinDiamond = 3,
    Chest = 7,             
    SigleMouse = 32,
    MinStone = 12,
    DiamondMouse = 9,
    //   Chest = ,
    MidStone = 13,
}


public class Treasure : MonoBehaviour {
    [SerializeField] int score;
    [SerializeField] float mass;

    public int GetScore()
    {
        return score;
    }


    public float GetMass()
    {
        return mass;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        onGrab();
    }


    protected virtual void onGrab()
    {
        
    }
}
