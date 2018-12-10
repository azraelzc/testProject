using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void TestEventHandler(string str);
public class ClassA
{
    public event TestEventHandler TestEvent;  

    public void addEvent(TestEventHandler testEvent)
    {
        TestEvent += testEvent;
    }

    public void BroadCast()
    {
        TestEvent("aaa");
    }
}
