using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestDropdown : MonoBehaviour
{
    Dropdown dropdown;
    // Start is called before the first frame update
    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        dropdown.onValueChanged.AddListener((value) => { 
            Debug.Log("===value===" + value);
        });
        dropdown.options.Clear();
        for (int i = 0; i < 300; i++) {
            dropdown.options.Add(new Dropdown.OptionData(i.ToString()));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
