using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycast : MonoBehaviour {
    Camera mainCamera;
    // Start is called before the first frame update
    void Start() {
        mainCamera = GetComponent<Camera>();

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
                Debug.LogError("=====" + hit.collider.gameObject.name);
            }
        }
    }
}
