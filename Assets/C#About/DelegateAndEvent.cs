using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateAndEvent : MonoBehaviour {
    // Use this for initialization
    void Start () {
        ClassA a = new ClassA();
        a.addEvent((str)=> {
            Debug.Log(str + ":" + 1);
        });
        a.addEvent((str) => {
            Debug.Log(str + ":" + 2);
        });
        a.BroadCast();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
