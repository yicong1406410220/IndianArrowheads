using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookTest : MonoBehaviour {

    public Transform target;


    // Use this for initialization
    void Start () {
        // Direction vector towards other object (relative to this transform):
        var directionTo = (target.transform.position - transform.position).normalized;

        // align forward axis to direction:
        transform.up = directionTo;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
