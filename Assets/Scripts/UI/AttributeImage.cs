using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeImage : Graphic {

    List<Vector2> pos = new List<Vector2>();
    VertexHelper vh = new VertexHelper();

    public int VertexNum;
    // Use this for initialization
    protected override void Start () {
        
    }

    // Update is called once per frame
    // 自己手动刷新
    void Update() {
        CalVertexPosition();
        //SetNativeSize();
        SetVerticesDirty();
    }
    protected override void OnPopulateMesh(VertexHelper vh) {
        if (pos.Count == 0) {
            return;
        }
        Color32 color32 = color;
        vh.Clear();
        // 这里我用5对GameObject的坐标来与该Image对象的五个顶点绑定起来
        // AddVert的最后一个参数是UV值
        for (int i = 0;i < pos.Count;i++) {
            vh.AddVert(pos[i], color32, new Vector2(0f, 0f));
            if (i > 0 && i + 1 < pos.Count) {
                vh.AddTriangle(0, i, i+1);
            }
        }
    }

    int radius = 200;
    void CalVertexPosition() {
        if (VertexNum < 3 ) {
            VertexNum = 3;
        }
        
        pos.Clear();
        Vector2 v = new Vector2(0,200);
        pos.Add(v);
        float angle = 360f / VertexNum;
        float rad = angle * Mathf.Deg2Rad;
        for (int i = 1;i < VertexNum;i++) {
            float x0 = v.x * Mathf.Cos(rad) - v.y * Mathf.Sin(rad);
            float y0 = v.x * Mathf.Sin(rad) + v.y * Mathf.Cos(rad);
            v = new Vector2(x0, y0);
            pos.Add(v);
        }
        
    }
}
