using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ScoreFlowText : MonoBehaviour {
    [SerializeField] Text flowText;

    public void Show(Vector3 startPos, string text, float height, float duration)
    {
        transform.position = startPos;
        flowText.text = text;
        transform.DOLocalMoveY(height, duration)
                 .SetRelative()
                 .OnComplete(() => GameObject.Destroy(gameObject));
    }
}
