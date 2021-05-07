using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIAutoAlignmentGrid : MonoBehaviour {

    public GameObject CloneObj;
    public AlignmentType Alignment = AlignmentType.MiddleCenter;
    public GridFixedType GridFixed;
    public int fixedCount = 0;
    public Vector2 itemSize = Vector2.zero;
    public Vector2 rootSize = Vector2.zero;
    public Vector2 padding = Vector2.zero;
    public enum AlignmentType {
        LeftTop,
        MiddleTop,
        RightTop,
        LeftCenter,
        MiddleCenter,
        RightCenter,
        LeftBottom,
        MiddleBottom,
        RightBottom,
    }

    public enum GridFixedType {
        ColumnCountFixed,
        RowCountFixed,
    }

    int countX;
    int countY;
    int totalCount;

    Action<AutoAlignmentItem, int, int, int> _onCreate;
    List<AutoAlignmentItem> _showList = new List<AutoAlignmentItem>();

    private void Start() {
        CloneObj.SetActive(false);
        //test
        InitGrid((item, index, row, column) => {
            item.gameObject.GetComponentInChildren<Text>().text = index.ToString() + "," + row + "," + column;
        });
        SetListItemCount(15);
        //SetListItemCount(4);
    }

    public void InitGrid(Action<AutoAlignmentItem, int, int, int> action) {
        _onCreate = action;
        if (itemSize == Vector2.zero) {
            RectTransform rectTransform = CloneObj.GetComponent<RectTransform>();
            itemSize = rectTransform.sizeDelta;
            rootSize = GetComponent<RectTransform>().sizeDelta;
        }
    }

    public void SetListItemCount(int count) {
        totalCount = count;
        if (GridFixed == GridFixedType.ColumnCountFixed) {
            countX = count <= fixedCount ? count : fixedCount;
            countY = count / fixedCount;
            if (count % fixedCount != 0) {
                countY++;
            }
        } else {
            countX = count / fixedCount;
            countY = count <= fixedCount ? count : fixedCount;
            if (count % fixedCount != 0) {
                countX++;
            }
        }
        
        for (int i = 0; i < totalCount; i++) {
            CreateItem(i);
        }
        for (int i = count; i < _showList.Count; i++) {
            _showList[i].gameObject.SetActive(false);
        }
    }

    void CreateItem(int index) {
        AutoAlignmentItem item = GetGameObject(index);
        item.Index = index;
        int x = index % fixedCount;
        int y = index / fixedCount;
        if (GridFixed == GridFixedType.ColumnCountFixed) {
            item.Column = x;
            item.Row = y;
        } else {
            item.Column = y;
            item.Row = x;
        }
        AlignmentItem(item);
        _onCreate?.Invoke(item, item.Index, item.Row, item.Column);
    }

    void AlignmentItem(AutoAlignmentItem item) {
        RectTransform rectTransform = item.GetComponent<RectTransform>();
        float sizeX = 0;
        float sizeY = 0;
        switch (Alignment) {
            case AlignmentType.LeftTop:
                sizeX = -rootSize.x / 2 + (itemSize.x + padding.x) * item.Column;
                sizeY = rootSize.y / 2 - (itemSize.y + padding.y) * item.Row;
                break;
            case AlignmentType.MiddleTop:
                sizeX = -((float)(countX - 1) / 2 - item.Column) * (itemSize.x + padding.x);
                sizeY = rootSize.y / 2 - (itemSize.y + padding.y) * item.Row;
                break;
            case AlignmentType.RightTop:
                sizeX = rootSize.x / 2 - (itemSize.x + padding.x) * item.Column;
                sizeY = rootSize.y / 2 - (itemSize.y + padding.y) * item.Row;
                break;
            case AlignmentType.LeftCenter:
                sizeX = -rootSize.x / 2 + (itemSize.x + padding.x) * item.Column;
                sizeY = ((float)(countY - 1) / 2 - item.Row) * (itemSize.y + padding.y);
                break;
            case AlignmentType.MiddleCenter:
                sizeX = -((float)(countX - 1) / 2 - item.Column) * (itemSize.x + padding.x);
                sizeY = ((float)(countY - 1) / 2 - item.Row) * (itemSize.y + padding.y);
                break;
            case AlignmentType.RightCenter:
                sizeX = rootSize.x / 2 - (itemSize.x + padding.x) * item.Column;
                sizeY = ((float)(countY - 1) / 2 - item.Row) * (itemSize.y + padding.y);
                break;
            case AlignmentType.LeftBottom:
                sizeX = -rootSize.x / 2 + (itemSize.x + padding.x) * item.Column;
                sizeY = -rootSize.y / 2 + (itemSize.y + padding.y) * item.Row;
                break;
            case AlignmentType.MiddleBottom:
                sizeX = -((float)(countX - 1) / 2 - item.Column) * (itemSize.x + padding.x);
                sizeY = -rootSize.y / 2 + (itemSize.y + padding.y) * item.Row;
                break;
            case AlignmentType.RightBottom:
                sizeX = rootSize.x / 2 - (itemSize.x + padding.x) * item.Column;
                sizeY = -rootSize.y / 2 + (itemSize.y + padding.y) * item.Row;
                break;
            default:
                break;
        }
        
        rectTransform.anchoredPosition = new Vector2(sizeX, sizeY);
    }

    void SetHorizontalPosition(AutoAlignmentItem item,int index) {
        RectTransform rectTransform = item.GetComponent<RectTransform>();
        float sizeX = -(countX / 2 - item.Column) * (itemSize.x + padding.x);
        float sizeY = (countY / 2 - item.Row) * (itemSize.y + padding.y);
        rectTransform.anchoredPosition = new Vector2(sizeX, sizeY);
    }

    void SetVerticalPosition(AutoAlignmentItem item, int index) {
        RectTransform rectTransform = item.GetComponent<RectTransform>();
        float sizeX = -(countX / 2 - item.Column) * (itemSize.x + padding.x);
        float sizeY = (countY / 2 - item.Row) * (itemSize.y + padding.y);
        rectTransform.anchoredPosition = new Vector2(sizeX, sizeY);
    }

    AutoAlignmentItem GetGameObject(int index) {
        AutoAlignmentItem obj = null;
        if (_showList.Count > index) {
            obj = _showList[index];
        }
        if (obj == null) {
            obj = Instantiate(CloneObj).AddComponent<AutoAlignmentItem>();
            obj.transform.SetParent(transform, false);
            _showList.Add(obj);
        }
        obj.gameObject.SetActive(true);
        return obj;
    }

    public class AutoAlignmentItem : MonoBehaviour {
        public int Index;
        public int Row;
        public int Column;
        public bool isInit = false;
    }
}
