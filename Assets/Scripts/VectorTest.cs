using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vector3 v1 = Vector3.one;
        Vector3 v2 = new Vector3(1,2,3);
        float n = Vector3.Dot(v1,v2);
        float angle = Mathf.Acos(n/(v1.magnitude * v2.magnitude)) * Mathf.Rad2Deg;
        Vector3 xCheng = Vector3.Cross(v1,v2);
        Debug.Log(n +" : " + v1.magnitude + " : "+ v2.magnitude + " : " + angle);
        Debug.Log(xCheng);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
