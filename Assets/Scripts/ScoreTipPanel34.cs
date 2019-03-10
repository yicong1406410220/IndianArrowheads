using UnityEngine;
using UnityEngine.UI;


public class ScoreTipPanel34 : ScoreTipPanel
{
    [SerializeField] Text scoreText;
    [SerializeField] Text timeStepText;
    [SerializeField] Text target2Text;
    [SerializeField] Image target2Icon;

  
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
        target2Text.text = text;
    }

    public override void SetTarget2Icon(string name)
    {
        target2Icon.sprite = Resources.Load<Sprite>("Textures/" + name);
    }
}

