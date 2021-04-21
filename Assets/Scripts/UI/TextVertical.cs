using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

//[ExecuteInEditMode]
public class TextVertical : MonoBehaviour {
    public enum TextVerticalAligment {
        TopLeft,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight,
    }

    [TextArea]
    public string _input_str;
    public TextVerticalAligment _aligment = TextVerticalAligment.MiddleCenter;
    public int _fontSize = 14;
    public Font _font;
    public Color _color = Color.white;
    public float _speed = 10;
    public int _lineSpace = 0;

    List<GameObject> _gameObjects = new List<GameObject>();
    Queue<string> lineStrQueue = new Queue<string>();
    // Start is called before the first frame update
    void Start() {
        ShowText(_input_str);
    }

    // Update is called once per frame
    void Update() {

    }

    public void ShowText(string inputStr) {
        lineStrQueue.Clear();
        string[] lines = inputStr.Split('\n');
        int length = lines.Length;
        for (int i = 0; i < length; i++) {
            string s = lines[i];
            GameObject go;
            Text text;
            if (_gameObjects.Count > i) {
                go = _gameObjects[i];
                text = GetComponent<Text>();
            } else {
                go = new GameObject("Line" + (i + 1));
                go.transform.SetParent(transform, false);
                text = go.AddComponent<Text>();
                text.horizontalOverflow = HorizontalWrapMode.Wrap;
                text.verticalOverflow = VerticalWrapMode.Overflow;
                go.AddComponent<UITextFadeIn>();
                _gameObjects.Add(go);
            }
            text.color = _color;
            text.font = _font;
            text.fontSize = _fontSize;
            int space = _lineSpace + _fontSize;
            RectTransform rectTransform = go.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(_fontSize, s.Length * _fontSize);
            switch (_aligment) {
                case TextVerticalAligment.TopLeft:
                    rectTransform.anchorMin = Vector2.up;
                    rectTransform.anchorMax = Vector2.up;
                    rectTransform.pivot = Vector2.up;
                    rectTransform.anchoredPosition = new Vector2(i * space, 0);
                    break;
                case TextVerticalAligment.TopCenter:
                    rectTransform.anchorMin = new Vector2(0.5f, 1);
                    rectTransform.anchorMax = new Vector2(0.5f, 1);
                    rectTransform.pivot = new Vector2(0.5f, 1);
                    rectTransform.anchoredPosition = new Vector2((i - length / 2) * space, 0);
                    break;
                case TextVerticalAligment.TopRight:
                    rectTransform.anchorMin = Vector2.one;
                    rectTransform.anchorMax = Vector2.one;
                    rectTransform.pivot = Vector2.one;
                    rectTransform.anchoredPosition = new Vector2(-i * space, 0);
                    break;
                case TextVerticalAligment.MiddleLeft:
                    rectTransform.anchorMin = Vector2.up / 2;
                    rectTransform.anchorMax = Vector2.up / 2;
                    rectTransform.pivot = new Vector2(0f, 0.5f);
                    rectTransform.anchoredPosition = new Vector2(i * space, 0);
                    break;
                case TextVerticalAligment.MiddleCenter:
                    rectTransform.anchorMin = Vector2.one / 2;
                    rectTransform.anchorMax = Vector2.one / 2;
                    rectTransform.pivot = new Vector2(0.5f, 0.5f);
                    rectTransform.anchoredPosition = new Vector2((i - length / 2) * space, 0);
                    break;
                case TextVerticalAligment.MiddleRight:
                    rectTransform.anchorMin = new Vector2(1, 0.5f);
                    rectTransform.anchorMax = new Vector2(1, 0.5f);
                    rectTransform.pivot = new Vector2(1, 0.5f);
                    rectTransform.anchoredPosition = new Vector2((-i * space), 0);
                    break;
                case TextVerticalAligment.BottomLeft:
                    rectTransform.anchorMin = Vector2.zero;
                    rectTransform.anchorMax = Vector2.zero;
                    rectTransform.pivot = Vector2.zero;
                    rectTransform.anchoredPosition = new Vector2(i * space, 0);
                    break;
                case TextVerticalAligment.BottomCenter:
                    rectTransform.anchorMin = Vector2.right / 2;
                    rectTransform.anchorMax = Vector2.right / 2;
                    rectTransform.pivot = new Vector2(0.5f, 0);
                    rectTransform.anchoredPosition = new Vector2((i - length / 2) * space, 0);
                    break;
                case TextVerticalAligment.BottomRight:
                    rectTransform.anchorMin = Vector2.right;
                    rectTransform.anchorMax = Vector2.right;
                    rectTransform.pivot = Vector2.right;
                    rectTransform.anchoredPosition = new Vector2((-i * space), 0);
                    break;
                default:
                    break;
            }
            text.text = "";
            lineStrQueue.Enqueue(s);
        }
        if (length < _gameObjects.Count) {
            for (int i = length; i < _gameObjects.Count; i++) {
                _gameObjects[i].GetComponent<Text>().text = "";
            }
        }
        PlayFadeIn(0);
    }

    void PlayFadeIn(int index) {
        if (lineStrQueue.Count > 0) {
            string s = lineStrQueue.Dequeue();
            GameObject go = _gameObjects[index];
            UITextFadeIn textFadeIn = go.GetComponent<UITextFadeIn>();
            textFadeIn.OnComplete(() => {
                PlayFadeIn(index + 1);
            });
            textFadeIn.Play(s, _speed);
        }
    }

    public void Clear() {
        for (int i = 0; i < _gameObjects.Count; i++) {
            DestroyImmediate(_gameObjects[i]);
        }
        _gameObjects.Clear();
    }

    private void OnDestroy() {
        Clear();
    }
}
