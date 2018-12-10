using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //C1 c1 = new C2();
        //C2 c2 = new C3();
        //C2 c3 = new C2();
        //c1.W();
        //c2.W();
        //c3.W();

        //int i1 = 0;
        //MyMethod1(i1);
        //int i2 = 0;
        //MyMethod2(ref i2);
        //int i3 = 0;
        //MyMethod1(i3);
        //Debug.Log(i1 + ":" + i2 + ":" + i3);
    }

    void MyMethod1(int i) { i++; }
    void MyMethod2(ref int i) { i++; }
    void MyMethod3(out int i) { i = 0; i++; }


    // Update is called once per frame
    void Update () {
        transform.Rotate(Vector3.up);
        transform.RotateAround(new Vector3(0,transform.position.y,0), Vector3.up, 1);
	}

    class C1
    {
        public virtual void W()
        {
            Debug.Log("1111");
        }
    }
    class C2 : C1
    {
        public new virtual void W()
        {
            Debug.Log("2222");
        }
    }
    class C3:C2
    {
        public override void W()
        {
            Debug.Log("3333");
        }
    }
}
