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
        Matrix4x4 RM = new Matrix4x4();
        float t = Time.realtimeSinceStartup;
        RM[0, 0] = Mathf.Cos(t);
        RM[0, 2] = Mathf.Sin(t);
        RM[1, 1] = 1;
        RM[2, 0] = -Mathf.Sin(t);
        RM[2, 2] = Mathf.Cos(t);
        RM[3, 3] = 1;

        Matrix4x4 SM = new Matrix4x4();
        SM[0, 0] = Mathf.Sin(t) / 4 + 0.5f;
        SM[1, 1] = Mathf.Cos(t) / 8 + 0.5f;
        SM[2, 2] = Mathf.Sin(t) / 6 + 0.5f;
        SM[3, 3] = 1;

        Matrix4x4 mvp = Camera.main.previousViewProjectionMatrix * Camera.main.worldToCameraMatrix * transform.localToWorldMatrix;
        m.SetMatrix("mvp", mvp);
        m.SetMatrix("rm", RM);
        m.SetMatrix("sm", SM);
    }
}
