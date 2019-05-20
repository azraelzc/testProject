using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForce : MonoBehaviour {

    // Use this for initialization
    void Start () {
        Rigidbody rb = transform.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0,1000,0));
        StartCoroutine(Test());
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public IEnumerator Test()
    {
        Debug.Log("Test1"); 
        yield return null;
        Debug.Log("Test2");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("1111111111");
    }

    private void OnCollisionStay(Collision collision)
    {
        //Debug.Log("2222222222");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("3333333333");
    }
}
