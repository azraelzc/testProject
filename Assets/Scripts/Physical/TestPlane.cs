using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlane : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 a = Vector3.left;
        Vector3 b = Vector3.right;
        Vector3 c = Vector3.back;
        Plane plane = new Plane(a,b,c);
        Vector3 cross = Vector3.Cross(b - a, c - a);
        Debug.Log(cross);
        Vector3 normal = Vector3.Normalize(cross);
        Debug.Log(normal);
        float dis = 0f - Vector3.Dot(normal, a);
        Debug.Log(dis);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
