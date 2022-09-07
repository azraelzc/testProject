using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(()=>{ 
            Debug.LogError("======11111=====");
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
