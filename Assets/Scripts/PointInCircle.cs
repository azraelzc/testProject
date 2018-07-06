using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointInCircle : MonoBehaviour {

    public Transform m_Transform;
    public float m_Radius = 1; // 圆环的半径
    public float m_Theta = 0.1f; // 值越低圆环越平滑
    public Color m_Color = Color.green; // 线框颜色

    void Start()
    {
        if (m_Transform == null)
        {
            throw new Exception("Transform is NULL.");
        }
    }

    void OnDrawGizmos()
    {
        if (m_Transform == null) return;
        if (m_Theta < 0.0001f) m_Theta = 0.0001f;

        // 设置矩阵
        Matrix4x4 defaultMatrix = Gizmos.matrix;
        Gizmos.matrix = m_Transform.localToWorldMatrix;

        // 设置颜色
        Color defaultColor = Gizmos.color;
        Gizmos.color = m_Color;

        // 绘制圆环
        Vector3 beginPoint = Vector3.zero;
        Vector3 firstPoint = Vector3.zero;
        for (float theta = 0; theta < 2 * Mathf.PI; theta += m_Theta)
        {
            float x = m_Radius * Mathf.Cos(theta);
            float z = m_Radius * Mathf.Sin(theta);
            Vector3 endPoint = new Vector3(x, 0, z);
            if (theta == 0)
            {
                firstPoint = endPoint;
            }
            else
            {
                Gizmos.DrawLine(beginPoint, endPoint);
            }
            
            beginPoint = endPoint;
        }

        // 绘制最后一条线段
        Gizmos.DrawLine(firstPoint, beginPoint);
        DrawPoint();

        // 恢复默认颜色
        Gizmos.color = defaultColor;

        // 恢复默认矩阵
        Gizmos.matrix = defaultMatrix;
    }

    private void DrawPoint()
    {
        Vector3 size = new Vector3(0.01f, 0, 0.01f);
        int num = 1000;
        Gizmos.color = Color.red;
        for (int i = 1; i <= num; i++)
        {
            float ranNum = UnityEngine.Random.Range(0f, 1f);
            float ranNum1 = UnityEngine.Random.Range(0f, 1f);
            float theta = ranNum * 2 * Mathf.PI;
            float ranR = UnityEngine.Random.Range(0f, m_Radius);
            //float x = Mathf.Sin(theta) * ranR;
            //float y = Mathf.Cos(theta) * ranR;
            float x = Mathf.Sin(theta) * Mathf.Sqrt(ranNum1) * m_Radius;
            float y = Mathf.Cos(theta) * Mathf.Sqrt(ranNum1) * m_Radius;
            Vector3 v = new Vector3(x,0, y);
            Gizmos.DrawCube(v, size);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
