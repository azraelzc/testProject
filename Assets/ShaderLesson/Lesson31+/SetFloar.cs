using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloar : MonoBehaviour {

    float dis = -1;
    float r = 0.1f;
    Material m;
	// Use this for initialization
	void Start () {
        m = GetComponent<Renderer>().material;

    }
	
	// Update is called once per frame
	void Update () {
        dis += Time.deltaTime * 0.1f;
        if (dis > 1) {
            dis = -1;
        }
        m.SetFloat("dis", dis);
        m.SetFloat("r", r);
    }
}
