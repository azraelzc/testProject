using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uniform : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.SetVector("_SecondColor",new Vector4(1f,0f,0f,1));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
