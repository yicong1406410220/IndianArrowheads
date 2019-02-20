using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationListener : MonoBehaviour {

    public static AnimationEvent animationEvent = new AnimationEvent();

    public void MyCustomEvent(int intValue)
    {
        animationEvent.Invoke(intValue);
    }

}

public class AnimationEvent : UnityEvent<int> { }
