using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityMath : MonoBehaviour {

	 //向量a
    private Vector3 a;
    //向量b
    private Vector3 b;
    
    void Start ()
    {
        //向量的初始化
        a = new Vector3 (1, 1, 0);
        b = new Vector3 (2, 0, 0);
        //点积的返回值
        float c = Vector3.Dot(a, b);
        //向量a,b的夹角,得到的值为弧度，我们将其转换为角度，便于查看！
        float angle = Mathf.Acos(Vector3.Dot(a.normalized, b.normalized)) * Mathf.Rad2Deg;
        Debug.Log("====" + a.normalized + " : " + b.normalized);
        Debug.Log("向量a，b的点积为：" + c);
        Debug.Log("向量a，b的夹角为：" + angle);


        //叉积的返回值
        Vector3 e = Vector3.Cross(a, b);
        Vector3 d = Vector3.Cross(b, a);
        //向量a,b的夹角,得到的值为弧度，我们将其转换为角度，便于查看！
        angle = Mathf.Asin(Vector3.Distance(Vector3.zero, Vector3.Cross(a.normalized, b.normalized))) * Mathf.Rad2Deg;
        Debug.Log("向量axb为：" + e);
        Debug.Log("向量bxa为：" + d);
        Debug.Log("向量a，b的夹角为：" + angle);
    }
}
