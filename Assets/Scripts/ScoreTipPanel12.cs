using UnityEngine;
using UnityEngine.UI;


public class ScoreTipPanel12 : ScoreTipPanel
{
    [SerializeField] Text scoreText;
    [SerializeField] Text timeStepText;

    public override void SetTimeOrStep(int value)
    {
        timeStepText.text = value.ToString();
    }

    public override void SetScoreText(string text)
    {
        scoreText.text = text;
    }

    public override void SetTarget2Text(string text)
    {

    }

    public override void SetTarget2Icon(string name)
    {

    }
}
