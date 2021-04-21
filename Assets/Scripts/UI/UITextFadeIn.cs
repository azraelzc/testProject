using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UITextFadeIn : MonoBehaviour {

    Text obj;
    TextMesh objMesh;

    public float dt = 0.001f;//打字间隔时间
    public float showingTime = 1f;//显示使用的时间

    Action onComplete;
    bool _isPlaying;
    string _text;
    StringBuilder sb;
    // Start is called before the first frame update
    void Start() {
        Play("我<color=#FF0000>迷</color>迷糊糊", 10);
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

    public void Play(string text, float speed) {
        if (obj == null) {
            obj = GetComponent<Text>();
            objMesh = GetComponent<TextMesh>();
        }
        dt = 1 / speed;
        _isPlaying = true;
        _text = text;
        StartCoroutine(Typing(_text));
    }

    public void ShowAllText() {
        if (obj) {
            obj.text = _text;
        } else if (objMesh) {
            objMesh.text = _text;
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
        //-----
        if (obj) {
            while ((index < text.Length || a < 255) && _isPlaying) {
                obj.text = "";
                timeScale = 256 / (index * showingTime);
                aTime = (Time.time - Startime) * timeScale;
                for (int i = 0; i <= index && i < text.Length; i++) {
                    a = (int)(aTime * (index - i));
                    a = Mathf.Clamp(a, 0, 255);

                    if (a == 255 && i == 0 && start == false) {
                        obj.text += "<color=#" + ColorToHex(obj.color) + "ff>";
                        start = true;
                    }
                    if (a == 255 && start) {
                        obj.text += text[i];
                        continue;
                    }
                    if (a != 255 && start) {
                        start = false;
                        obj.text += "</color>";
                    }

                    string aStr = Convert.ToString(a, 16);
                    aStr = (aStr.Length == 1 ? "0" : "") + aStr;
                    obj.text += "<color=#" + ColorToHex(obj.color) + aStr + ">" + text[i] + "</color>";
                }
                if (a == 255 && start)
                    obj.text += "</color>";
                if (Time.time - dTime >= dt) {
                    dTime = Time.time;
                    index++;
                }
                yield return 0;
            }
        } else {
            while (index < text.Length || a < 255) {
                objMesh.text = "";
                timeScale = 256 / (index * showingTime);
                aTime = (Time.time - Startime) * timeScale;
                for (int i = 0; i <= index && i < text.Length; i++) {
                    a = (int)(aTime * (index - i));
                    a = Mathf.Clamp(a, 0, 255);

                    if (a == 255 && i == 0 && start == false) {
                        objMesh.text += "<color=#" + ColorToHex(objMesh.color) + "ff>";
                        start = true;
                    }
                    if (a == 255 && start) {
                        objMesh.text += text[i];
                        continue;
                    }
                    if (a != 255 && start) {
                        start = false;
                        objMesh.text += "</color>";
                    }

                    string aStr = Convert.ToString(a, 16);
                    aStr = (aStr.Length == 1 ? "0" : "") + aStr;
                    objMesh.text += "<color=#" + ColorToHex(objMesh.color) + aStr + ">" + text[i] + "</color>";
                }
                if (a == 255 && start)
                    objMesh.text += "</color>";
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
}
