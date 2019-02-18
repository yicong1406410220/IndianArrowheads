using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClickStart()
    {
        SoundManager.instance.PlayBtn();
        SceneJump.instance.Jump(SceneType.Map);
    }
}
