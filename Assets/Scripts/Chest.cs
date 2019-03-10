using UnityEngine;
using DG.Tweening;


public class Chest : Treasure {
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite chestOpenSprite;
    public bool IsOpened { get; set; }

    protected override void onGrab()
    {
        if (!IsOpened)
        {
            spriteRenderer.sprite = chestOpenSprite;
            spriteRenderer.DOFade(0, 1.5f)
                .SetDelay(0.3f)
                .OnComplete(() => GameObject.Destroy(gameObject));


            Vector3 destPos = BattleCanvas.Instance.GetScoreTipPanel().transform.position + new Vector3(0.25f, -0.3f,0);
            Treasure chestTreasure = getRandomChestTreasure();
            chestTreasure.transform.position = new Vector3(transform.position.x - 0.15f, transform.position.y , 0);
            chestTreasure.transform.SetParent(transform.parent);
            chestTreasure.transform
                         .DOMoveY(spriteRenderer.sprite.bounds.size.y * 0.5f, 0.35f)
                         .SetRelative();

            chestTreasure.transform.localScale = Vector3.zero;
            chestTreasure.transform.DOScale(1, 0.35f);

            chestTreasure.transform
                         .DOMove(destPos, Vector3.Distance(chestTreasure.transform.position, destPos) * 0.0045f)
                         .SetDelay(2f)
                         .OnComplete(() => {
                             BattleCanvas.Instance.AddScore(chestTreasure.GetScore());
                             GameObject.Destroy(chestTreasure.gameObject);
                         });


            IsOpened = true;
        }
    }

    Treasure getRandomChestTreasure()
    {
        ChestTreasureID[] treasureIDs = System.Enum.GetValues(typeof(ChestTreasureID)) as ChestTreasureID[];
        return ChestTreasureCreator.Create(treasureIDs[Random.Range(0, treasureIDs.Length)]);
    }
}
