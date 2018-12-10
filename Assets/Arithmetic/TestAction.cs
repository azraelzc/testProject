using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestAction : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ///Action<T>的用法
        ///这里的T为代理函数的传入类型,无返回值
        Action<string[]> action = delegate (string[] x)
        {
            var result = from p in x
                         where p.Contains("s")
                         select p;
            foreach (string s in result.ToList())
            {
                Debug.Log(s);
            }
        };
        string[] str = { "charlies", "nancy", "alex", "jimmy", "selina" };
        action(str);

        Func<int,string, int> func = CallStringLength;
        Func<string> func1 = delegate ()
        {
            return "我是Func<TResult>委托返回的结果";
        };
        Debug.Log(func(11,"1111"));
        Debug.Log(func1());

#region Predicate
        ///bool Predicate<T>的用法
        ///输入一个T类型的参数,返回值为bool类型
        Predicate<string[]> predicate = delegate(string[] x)
        {
            var result = from p in x
                         where p.Contains("s")
                         select p;
            if (result.ToList().Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        };
        string[] _value = { "charlies", "nancy", "alex", "jimmy", "selina" };
        if (predicate(_value))
        {
                Debug.Log("They contain.");
        }
        else
        {
                Debug.Log("They don't contain.");
        }
#endregion
    }

    

    int CallStringLength(int i,string str)
    {
        return str.Length;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
