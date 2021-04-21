using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEulerAngles : MonoBehaviour {

    Vector3 vector;
    float interval = 0;
    float changeTime = 0.1f;
    // Start is called before the first frame update
    void Start() {
        vector = transform.localEulerAngles;
        
        
        Vector3 v1 = new Vector3(-2, 15, 0);
        Vector3 v2 = new Vector3(7, -18, 0);
        Vector3 vec = v2 - v1;
        float angle = GetAngle(1, 0, 0, vec.x, vec.y, 0);
        Debug.LogError("==vec==" + vec);
        transform.localEulerAngles = new Vector3(0,0, angle);
    }

    public static float GetAngle(float x, float y, float z, float tx, float ty, float tz) {
        float angle = Vector3.Angle(new Vector3(x, y, z), new Vector3(tx, ty, tz));
        if (ty - y < 0) {
            angle = -angle;
        }
        return angle;
    }

    // Update is called once per frame
    void Update() {
        //interval += Time.deltaTime;
        //if (interval >= changeTime) {
        //    vector.x = vector.x + 1;
        //    transform.localEulerAngles = vector;
        //}
    }
}
