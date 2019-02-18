using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCanvas : MonoBehaviour {

    private Canvas canvas;

    private void Awake()
    {
        Debug.Log("你好");
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
