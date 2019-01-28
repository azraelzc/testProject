using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    // Use this for initialization
    void Start () {
        
        B b = new B();
        //Debug.Log("============");
        A a = new A();
        Debug.Log(a.rNum);
        Debug.Log(A.num);
        //Debug.Log(B.strText);
        //a = null;
        a[10,""] = 101;
        Debug.Log(A.num);
        Debug.Log(a[10,null]);
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(B.strText);
	}
}


public class A : IDisposable
{
    public const int j = i * 2;
    public const int i = 1;
    public static int num;
    public static string strText;
    public string Text;
    readonly public int rNum;
    readonly public static int rNum1;
    static A()
    {
        Debug.Log("===A===");
        strText = "AAA";
        rNum1 = 100;
    }
    public A()
    {
        rNum = 100;
        Text = "AAAAAAAAAAAAAAAAAAAAAAAAAA";
    }
    ~A()
    {
        Debug.Log("===Destructor A===");
    }

    public void Dispose()
    {
        Debug.Log("===Dispose A===");
    }

    public int this [int index,string str]
    {
        get
        {
            index = str == "" ? i : index;
            return index <= i ? i : j;
        }
        set
        {
            num = value;
        }
    }
}
public class B : A
{
    static B()
    {
        Debug.Log("===B===");
        strText = "BBB";
    }
    public B()
    {
        Text = "BBBBBBBBBBBBBBBBB";
    }
    ~B()
    {
        Debug.Log("===Destructor B===");
    }
    public new void Dispose()
    {
        Debug.Log("===Dispose B===");
    }
}
