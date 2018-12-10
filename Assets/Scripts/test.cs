using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A
{
    public static string strText;
    public string Text;
    static A()
    {
        strText = "AAA";
    }
    public A()
    {
        Text = "AAAAAAAAAAAAAAAAAAAAAAAAAA";
    }
}
public class B : A
{
    static B()
    {
        strText = "BBB";
    }
    public B()
    {
        Text = "BBBBBBBBBBBBBBBBB";
    }
}
