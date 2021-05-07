using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class UITextFadeIn : MonoBehaviour {

    Text label;
    TextMesh lableMesh;

    public float dt = 0.001f;//打字间隔时间
    public float showingTime = 1f;//显示使用的时间

    Action onComplete;
    bool _isPlaying;
    string _text;
    // Start is called before the first frame update
    void Start() {
        Play("我<color='#00ffffff'>帅哥</color>啊",10,1);
    }

    // Update is called once per frame
    void Update() {

    }

    public void OnComplete(Action com) {
        onComplete = () => {
            _isPlaying = false;
            com.Invoke();
        };
    }

    public void Play(string text, float speed, float fadeTime) {
        if (label == null) {
            label = GetComponent<Text>();
            lableMesh = GetComponent<TextMesh>();
        }
        dt = 1 / speed;
        showingTime = fadeTime;
        _isPlaying = true;
        _text = text;
        StartCoroutine(Typing(_text));
    }

    public void ShowAllText() {
        if (label) {
            label.text = _text;
        } else if (lableMesh) {
            lableMesh.text = _text;
        }
        onComplete?.Invoke();
    }

    private IEnumerator Typing(string text) {
        float Startime = Time.time, aTime, dTime = Time.time;
        //-----
        int index = 0;
        float timeScale;
        int a = 0;
        bool start = false;
        GetRichTextDataList(text);
        //-----
        if (label && label.gameObject.activeSelf) {
            while ((index < text.Length || a < 255) && _isPlaying) {
                label.text = "";
                timeScale = 256 / (index * showingTime);
                aTime = (Time.time - Startime) * timeScale;
                for (int i = 0; i <= index && i < text.Length; i++) {
                    a = (int)(aTime * (index - i));
                    a = Mathf.Clamp(a, 0, 255);

                    if (a == 255 && i == 0 && start == false) {
                        label.text += "<color=#" + ColorToHex(label.color) + "ff>";
                        start = true;
                    }
                    if (a == 255 && start) {
                        label.text += text[i];
                        continue;
                    }
                    if (a != 255 && start) {
                        start = false;
                        label.text += "</color>";
                    }

                    string aStr = Convert.ToString(a, 16);
                    aStr = (aStr.Length == 1 ? "0" : "") + aStr;
                    label.text += "<color=#" + ColorToHex(label.color) + aStr + ">" + text[i] + "</color>";
                }
                if (a == 255 && start)
                    label.text += "</color>";
                if (Time.time - dTime >= dt) {
                    dTime = Time.time;
                    index++;
                }
                yield return 0;
            }
        } else if (lableMesh && lableMesh.gameObject.activeSelf) {
            while (index < text.Length || a < 255) {
                lableMesh.text = "";
                timeScale = 256 / (index * showingTime);
                aTime = (Time.time - Startime) * timeScale;
                for (int i = 0; i <= index && i < text.Length; i++) {
                    a = (int)(aTime * (index - i));
                    a = Mathf.Clamp(a, 0, 255);

                    if (a == 255 && i == 0 && start == false) {
                        lableMesh.text += "<color=#" + ColorToHex(lableMesh.color) + "ff>";
                        start = true;
                    }
                    if (a == 255 && start) {
                        lableMesh.text += text[i];
                        continue;
                    }
                    if (a != 255 && start) {
                        start = false;
                        lableMesh.text += "</color>";
                    }

                    string aStr = Convert.ToString(a, 16);
                    aStr = (aStr.Length == 1 ? "0" : "") + aStr;
                    lableMesh.text += "<color=#" + ColorToHex(lableMesh.color) + aStr + ">" + text[i] + "</color>";
                }
                if (a == 255 && start)
                    lableMesh.text += "</color>";
                if (Time.time - dTime >= dt) {
                    dTime = Time.time;
                    index++;
                }
                yield return 0;
            }
        }
        onComplete?.Invoke();
    }

    private string ColorToHex(Color color) //十进制转十六进制
    {
        int r = Mathf.RoundToInt(color.r * 255.0f);
        int g = Mathf.RoundToInt(color.g * 255.0f);
        int b = Mathf.RoundToInt(color.b * 255.0f);
        int a = Mathf.RoundToInt(color.a * 255.0f);
        string hex = string.Format("{0:X2}{1:X2}{2:X2}", r, g, b);
        return hex;
    }

    List<RichTextData> GetRichTextDataList(string text) {
        Debug.LogError("==GetRichTextDataList=="+ text.Length);
        string[] splitStr = Regex.Split(text, "</color>");
        for (int i = 0; i < splitStr.Length; i++) {

        }
        return null;
    }

    class RichTextData {

    }
}
