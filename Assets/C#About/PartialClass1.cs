using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PartialTest : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
        PartialClass1 c = new PartialClass1();
        c.t();
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}

public partial class PartialClass1  {

	partial void test();
    partial void test1();
}

public partial class PartialClass1  {
    partial void test1()
    {
        Debug.Log("====test1====");
    }
	
    public void t()
    {
        test();
        test1();
    }
}
