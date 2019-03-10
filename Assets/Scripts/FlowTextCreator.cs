using UnityEngine;


public static class FlowTextCreator  {
    public static ScoreFlowText CreateScoreFlowText(Vector3 startPos, string text, float height, float duration)
    {
        var flowText = GameObject.Instantiate(Resources.Load<ScoreFlowText>("Prefabs/UI/ScoreFlowText"));
        flowText.Show(startPos, text, height, duration);
        return flowText;
    }
}

