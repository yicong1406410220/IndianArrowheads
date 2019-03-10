using UnityEngine;
using DG.Tweening;


public enum EffectID
{
    None,
    Vanishes,
    Sparksfly
}

public static class EffectManager {
    public static GameObject Create(EffectID effectID)
    {
        Animator effectObject = null;
        if (effectID == EffectID.Sparksfly)
            effectObject = Create("Sparksfly");
        else if (effectID == EffectID.Vanishes)
            effectObject = Create("Vanishes");
        else
            Debug.LogError("not match EffectID id: " + effectID);

        float effectLength = effectObject.GetCurrentAnimatorStateInfo(0).length;
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(effectLength);
        sequence.AppendCallback(() => GameObject.Destroy(effectObject.gameObject));
        sequence.Play();

        return effectObject.gameObject;
    }

    static Animator Create(string name)
    {
        return GameObject.Instantiate(Resources.Load<Animator>("Prefabs/Effects/" + name));
    }
}
