using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileRotaionRunGame : MonoBehaviour
{
    GameObject ui1;
    GameObject ui2;
    CanvasScaler _rootCanvasScaler;
    Vector2 _UIReferenceResolution;
    // Start is called before the first frame update
    void Start()
    {
        _rootCanvasScaler = GameObject.Find("Canvas").GetComponent<CanvasScaler>();
        _UIReferenceResolution = _rootCanvasScaler.referenceResolution;
        InitUI1();
        InitUI2();
        ui1.SetActive(true);
        ui2.SetActive(false);
    }

    void InitUI1() {
        ui1 = GameObject.Find("Canvas/UI1");
        ui1.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => {
            ui1.SetActive(false);
            ui2.SetActive(true);
            SetRotation(false);
        });
    }

    void InitUI2() {
        ui2 = GameObject.Find("Canvas/UI2");
        ui2.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => {
            ui1.SetActive(true);
            ui2.SetActive(false);
            SetRotation(true);
        });
    }

    #region 横竖屏旋转
    bool _isHorizontal = true;
    ScreenOrientation lastScreenOrientation = ScreenOrientation.Portrait;
    public void SetRotation(bool isHorizontal) {
        if (_rootCanvasScaler == null) return;
        Debug.Log("==SetRotation==" + Screen.orientation + " : " + lastScreenOrientation);
        if (_isHorizontal != isHorizontal) {
            _isHorizontal = isHorizontal;
            var screenOrientation = Screen.orientation;
            Screen.autorotateToLandscapeLeft = isHorizontal;
            Screen.autorotateToLandscapeRight = isHorizontal;
            Screen.autorotateToPortrait = !isHorizontal;
            Screen.autorotateToPortraitUpsideDown = false;
            Screen.orientation = lastScreenOrientation;
            lastScreenOrientation = screenOrientation;
            if (_isHorizontal) {
                _rootCanvasScaler.referenceResolution = _UIReferenceResolution;
            } else {
                _rootCanvasScaler.referenceResolution = new Vector2(_UIReferenceResolution.y, _UIReferenceResolution.x);
            }
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }

    IEnumerator delay() {
        yield return new WaitForEndOfFrame();
        Screen.orientation = ScreenOrientation.AutoRotation;
    }
    #endregion
}