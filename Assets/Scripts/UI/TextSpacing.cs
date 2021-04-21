using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/Effects/TextSpacing")]
public class TextSpacing : BaseMeshEffect {
    [SerializeField]
    private float spacing_x;
    [SerializeField]
    private float spacing_y;
    private List<UIVertex> mVertexList;
    public override void ModifyMesh(VertexHelper vh) {
        if (spacing_x == 0 && spacing_y == 0) { return; }
        if (!IsActive()) { return; }
        int count = vh.currentVertCount;
        if (count == 0) { return; }
        if (mVertexList == null) { mVertexList = new List<UIVertex>(); }
        vh.GetUIVertexStream(mVertexList);
        int row = 1;
        int column = 2;
        int vertex_count = mVertexList.Count;
        List<UIVertex> sub_vertexs;
        float min_row_left = -999999f;
        for (int i = 6; i < vertex_count;) {
            if (i % 6 == 0) {
                sub_vertexs = mVertexList.GetRange(i, 6);
                float tem_row_left = GetMin(sub_vertexs);
                if (tem_row_left <= min_row_left) {
                    min_row_left = tem_row_left;
                    ++row;
                    column = 1;
                } else {
                    min_row_left = tem_row_left;
                }
            }
            for (int j = 0; j < 6; j++) {
                UIVertex vertex = mVertexList[i];
                vertex.position += Vector3.right * (column - 1) * spacing_x;
                vertex.position += Vector3.down * (row - 1) * spacing_y;
                mVertexList[i] = vertex;
                ++i;
            }
            ++column;
        }
        vh.Clear();
        vh.AddUIVertexTriangleStream(mVertexList);
    }

    float GetMin(List<UIVertex> list) {
        float ret = 0;
        for (int i = 0; i < list.Count; i++) {
            UIVertex v = list[i];
            if (i == 0 || ret > v.position.x) {
                ret = v.position.x;
            }
        }
        return ret;
    }
}