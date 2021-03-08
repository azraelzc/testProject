using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 重力为垂直于a、b两点，方向可以指定左右
 */
public class GravityFlyXY : MonoBehaviour {
    public float time = 3;//代表从A点出发到B经过的时长
    public Vector2 pointA;//点A
    public Vector2 pointB;//点B
    public float gravity;//重力向量
    public bool isUp;

    Vector2 _StartPos;
    Vector2 _EndPos;
    float _Time;
    bool _IsUp;

    Vector2 _CurrentVec; //力的向量
    Vector2 _GravityForce;  //重力向量
    Vector2 _PointDir;

    bool isFly = false;
    void Start() {
        _StartPos = pointA;
        _EndPos = pointB;
        _Time = time;
        _IsUp = isUp;
        transform.position = _StartPos;//将物体置于A点
        _PointDir = _EndPos - _StartPos;
        //通过一个式子计算初速度
        _CurrentVec = _PointDir / _Time;
        _GravityForce = GetVerticalVec() * gravity;
        _CurrentVec = _CurrentVec - _GravityForce * _Time / 2;
        isFly = true;
        Debug.LogError("==_GravityForce==" + _GravityForce + " : " + Vector3.Dot(_PointDir, _GravityForce));
    }

    // Update is called once per frame
    void Update() {
        if (isFly) {
            _CurrentVec += _GravityForce * Time.deltaTime;
            Vector2 targetVec = _CurrentVec * Time.deltaTime;
            Vector3 v = new Vector3(targetVec.x, targetVec.y,0);
            transform.position = transform.position + v;
            float angle = GetAngle(_CurrentVec, Vector2.right);
            transform.localEulerAngles = new Vector3(0, 0, angle);
            _Time -= Time.deltaTime;
            if (_Time <= 0) {
                Debug.Log("====arrive===");
                isFly = false;
                //Start();
            }
        }
    }

    Vector2 GetVerticalVec() {
        if (_IsUp) {
            return new Vector2(_CurrentVec.y, -_CurrentVec.x).normalized;
        } else {
            return new Vector2(-_CurrentVec.y, _CurrentVec.x).normalized;
        }
    }

    float GetAngle(Vector2 a, Vector2 b) {
        float angle = Vector2.Angle(a,b);
        b.x -= a.x;
        b.y -= a.y;
        if (b.y > 0) {
            angle = -angle;
        }
        return angle;
    }
}
