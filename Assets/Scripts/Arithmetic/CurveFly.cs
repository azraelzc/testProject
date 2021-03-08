using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveFly : MonoBehaviour {
    public Vector3 StartPos;
    public Vector3 EndPos;
    public Vector3 InitialVec;
    public float FlyTime;
    public GameObject obj;

    Vector3 _CurrentPos;
    Vector3 _EndPos;
    Vector3 _CurrectVec;
    float _Time;
    float _TotalTime;
    float _Speed;
    bool isFly = false;
    // Start is called before the first frame update
    void Start() {
        _CurrentPos = StartPos;
        _EndPos = EndPos;
        transform.position = StartPos;
        _CurrectVec = InitialVec;
        _Time = FlyTime;
        _TotalTime = FlyTime;
        isFly = true;

        _Speed = Vector3.Distance(StartPos,EndPos)/_Time;
    }

    // Update is called once per frame
    void Update() {
        if (isFly) {
            Vector3 targetVec = (_EndPos - _CurrentPos) / _Time * Time.deltaTime;
            _CurrectVec = (_CurrectVec+ targetVec);
            _CurrentPos = _CurrentPos + _CurrectVec;
            //obj.transform.LookAt(_CurrectVec);
            transform.position = _CurrentPos;
            Debug.LogError("==Update==" + _CurrentPos + " : " + _CurrectVec + " : " + targetVec);
            _Time -= Time.deltaTime;
            if (_Time <= 0) {
                //transform.position = _EndPos;
                Debug.Log("====arrive===");
                isFly = false;
                //Start();
            }
        }
    }
}
