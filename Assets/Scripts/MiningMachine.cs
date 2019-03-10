using UnityEngine;


public enum MiningMachineStatus
{
    Idle,
    Drop,
    Drag
}


public class MiningMachine : MonoBehaviour {
    [SerializeField] GameObject hook;
    [SerializeField] SpriteRenderer lineSpriteRender;
    [SerializeField] float dropSpeed = 1;
    [SerializeField] float dragSpeed = 1;
    [SerializeField] float rotateSpeed = 1;
    [SerializeField] float rotateAngleLimit = 80;
    bool isRotateRight = true;

    public Treasure DragTreasure { get; set; }
    public MiningMachineStatus Status { get; set; }

    public void UpdateProcess()
    {
        if (Status == MiningMachineStatus.Idle)
        {
            Rotate();
        }
        else
        {
            if (Status == MiningMachineStatus.Drop)
                Drop();
            else if (Status == MiningMachineStatus.Drag)
                Drag();
        }
    }


    void Drop()
    {
        DragDrop(dropSpeed);
    }


    void Drag()
    {
        if (DragTreasure == null)
            DragDrop(-dragSpeed);
        else
        {
            if (DragTreasure.GetMass() != 0)
                DragDrop(-dragSpeed / (DragTreasure.GetMass() * 0.11f));
            else
                Debug.LogError("DragTreasure Mass Is Zero!!");
        }        
    }


    void Rotate()
    {
        Vector3 position = transform.position;
        float angle = transform.eulerAngles.z;
        if (angle > 180 && angle <= 360)
            angle = angle - 360;

        if (isRotateRight)
        {
            if (angle < rotateAngleLimit)
               transform.RotateAround(transform.parent.position, Vector3.forward, Time.deltaTime * rotateSpeed);
            else
               isRotateRight = false;
        }
        else
        {
            if (angle > -rotateAngleLimit)
                transform.RotateAround(transform.parent.position, Vector3.forward, Time.deltaTime * -rotateSpeed);
            else
                isRotateRight = true;
        }

        transform.position = position;

        var levelEntity = EntityManager.Instance.GetLevelEntity();
        if (!levelEntity.isTimeOrStep && levelEntity.timeStep == 0)
        {
            if (EntityManager.Instance.GetPlayerMinerEntity().starCount == 0)
                PanelMgr.instance.OpenPanel<LosePanel>("");
            else
                PanelMgr.instance.OpenPanel<WinPanel>("");

            EntityManager.Instance.GetLevelEntity().isPause = true;
        }
    }


    void DragDrop(float speed) {
        lineSpriteRender.size = new Vector2(lineSpriteRender.size.x + speed * Time.deltaTime, lineSpriteRender.size.y);
        hook.transform.position += hook.transform.right * speed * Time.deltaTime;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Status == MiningMachineStatus.Drop)
        {
            if (collision.tag == "Wall")
                Status = MiningMachineStatus.Drag;
            else if (collision.tag == "Treasures")
            {               
                Treasure treasure = collision.transform.GetComponentInParent<Treasure>();    
                float treasureHalfWidth = treasure.GetComponent<SpriteRenderer>().sprite.bounds.size.x * 0.5f;

                treasure.transform.position = hook.transform.position + hook.transform.right * treasureHalfWidth;
                treasure.transform.SetParent(hook.transform);

                DragTreasure = treasure;
                Status = MiningMachineStatus.Drag;
            }
            else if (collision.tag == "Chest")
                Status = MiningMachineStatus.Drag;
        }
    }
}
