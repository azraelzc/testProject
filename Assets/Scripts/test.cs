
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    float y = 100;
    // Use this for initialization
    void Start () {
        Debug.Log(transform.right);
        Debug.Log(transform.up);
        Debug.Log(transform.forward);
    }
	
	// Update is called once per frame
	void Update () {
        transform.right = new Vector3(0, y, 1);
        Debug.LogError("=======" + y + " : " + transform.right + " : " + transform.localEulerAngles);
        y--;
    }
}

