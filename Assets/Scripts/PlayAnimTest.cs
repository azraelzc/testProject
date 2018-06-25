using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimTest : MonoBehaviour {

    private float delayTime = 0;
    private Animation anim;
	// Use this for initialization
	void Start () {
        anim = transform.GetComponent<Animation>();
    }
	
	// Update is called once per frame
	void Update () {
        delayTime += Time.deltaTime;
        if (delayTime > 5)
        {
            delayTime = 0;
            if (anim != null)
            {
                Debug.Log("===play===="+anim.Play("testAnimation"));
            }
        }
    }
}
