﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMostUnitNumberInCircle : MonoBehaviour {
    public float m_Radius = 100; // 圆环的半径
    public float m_Theta = 0.1f; // 值越低圆环越平滑
    public Color m_Color = Color.green; // 线框颜色

    void Start() {

    }
        // Update is called once per frame
    void Update () {
        Debug.LogError("===Update====" + Time.deltaTime + " : " + Time.realtimeSinceStartup);
    }

    void FixedUpdate() {
        Debug.Log("===FixedUpdate====" + Time.fixedDeltaTime + " : " + Time.fixedTime);
    }

    void OnDrawGizmos() {
        if(m_Theta < 0.0001f)
            m_Theta = 0.0001f;

        // 设置矩阵
        Matrix4x4 defaultMatrix = Gizmos.matrix;
        Gizmos.matrix = transform.localToWorldMatrix;

        // 设置颜色
        Color defaultColor = Gizmos.color;
        Gizmos.color = m_Color;

        // 绘制圆环
        Vector3 beginPoint = Vector3.zero;
        Vector3 firstPoint = Vector3.zero;
        for(float theta = 0; theta < 2 * Mathf.PI; theta += m_Theta) {
            float x = m_Radius * Mathf.Cos(theta);
            float z = m_Radius * Mathf.Sin(theta);
            Vector3 endPoint = new Vector3(x, 0, z);
            if(theta == 0) {
                firstPoint = endPoint;
            } else {
                Gizmos.DrawLine(beginPoint, endPoint);
            }
            beginPoint = endPoint;
        }

        // 绘制最后一条线段
        Gizmos.DrawLine(firstPoint, beginPoint);

        // 恢复默认颜色
        Gizmos.color = defaultColor;

        // 恢复默认矩阵
        Gizmos.matrix = defaultMatrix;

    }
}
