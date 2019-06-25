using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MVPTransform : MonoBehaviour {

    Material m;
	// Use this for initialization
	void Start () {
        m = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        Matrix4x4 mvp = Camera.main.previousViewProjectionMatrix * Camera.main.worldToCameraMatrix * transform.localToWorldMatrix;
        m.SetMatrix("mvp", mvp);

    }
}
