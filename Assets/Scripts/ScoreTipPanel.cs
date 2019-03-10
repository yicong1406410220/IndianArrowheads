using UnityEngine;

public abstract class ScoreTipPanel : MonoBehaviour
{
    public abstract void SetTimeOrStep(int value);
    public abstract void SetScoreText(string text);
    public abstract void SetTarget2Text(string text);
    public abstract void SetTarget2Icon(string name);
}
