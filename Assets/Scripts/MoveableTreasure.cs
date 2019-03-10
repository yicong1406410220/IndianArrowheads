using UnityEngine;


public class MoveableTreasure : Treasure {
    [SerializeField] float speed;

    void Update () {
        if (speed != 0f)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

}
