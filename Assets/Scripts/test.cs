
using System;
using System.Collections;
using UnityEngine;

public class test : MonoBehaviour {

    float y = 100;
    // Use this for initialization
    void Start () {
        Application.targetFrameRate = 60;
        StartCoroutine("ObjectTest");
    }
	
	// Update is called once per frame
	void Update () {
    }

    public String GetStackTraceInfo() {
        string info = null;
        //设置为true，这样才能捕获到文件路径名和当前行数，当前行数为GetFrames代码的函数，也可以设置其他参数
        System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(true);
        //得到当前的所以堆栈
        System.Diagnostics.StackFrame[] sf = st.GetFrames();
        for (int i = 0;i < sf.Length;++i) {
            info = info + "\r\n" + " FileName=" + sf[i].GetFileName() + " fullname=" + sf[i].GetMethod().DeclaringType.FullName + " function=" + sf[i].GetMethod().Name + " FileLineNumber=" + sf[i].GetFileLineNumber();
        }
        return info;
    }

    IEnumerator ObjectTest() {
        UnityEngine.Object[] s = new UnityEngine.Object[20000];
        int count = 0;
        for (int i = 0;i < s.Length;i++) {
            count++;
            var obj = new UnityEngine.GameObject();
            obj.name = "object";
            s[i] = obj;
            if (count == 20) {
                count = 0;
                yield return null;
            }
            
        }
        Debug.LogError("==create complate===");
        UnityEngine.Profiling.Profiler.BeginSample("===DestroyInternalObjects==");
        for (int i = 0;i < s.Length;i++) {
            var obj = s[i];
            if (obj.name.IndexOf("abcd") == 0) {
                Debug.LogError("==2222==");
            }
        }
        UnityEngine.Profiling.Profiler.EndSample();
        UnityEngine.Profiling.Profiler.BeginSample("===DestroyInternalObjects111==");
        foreach (var obj in s) {
            if (obj.name.IndexOf("abcd") == 0) {
                Debug.LogError("==3333==");
            }
        }
        UnityEngine.Profiling.Profiler.EndSample();
    }
}

