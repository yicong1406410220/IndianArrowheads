using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMiner : MonoBehaviour
{
    [SerializeField] MiningMachine miningMachine;
    [SerializeField] Animator animator;
 
    public void Drop()
    {
        if (IsDropAble())
        {
            animator.Play("Drab");
            miningMachine.Status = MiningMachineStatus.Drop;
        }
    }


    public bool IsDropAble()
    {
        return miningMachine.Status == MiningMachineStatus.Idle;
    }

   
    public void UpdateProcess()
    {
        miningMachine.UpdateProcess();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hook")
        {
            if (miningMachine.Status != MiningMachineStatus.Idle)
            {
                animator.Play("Idle");
                miningMachine.Status = MiningMachineStatus.Idle;
            }
        }
        else if (collision.tag == "Treasures")
        {
            Treasure treasure = collision.GetComponentInParent<Treasure>();
            if (treasure == miningMachine.DragTreasure)
            {    
                BattleCanvas.Instance.AddScore(treasure.GetScore());
                miningMachine.DragTreasure = null;
                GameObject.Destroy(treasure.gameObject);
            } 
        }
    }

}
