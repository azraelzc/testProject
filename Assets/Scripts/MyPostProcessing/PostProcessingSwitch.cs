using Kino;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class PostProcessingSwitch: MonoBehaviour
{
    // Start is called before the first frame update
    MonoBehaviour[] bloomScripts = new MonoBehaviour[5];
    void Start()
    {
        bloomScripts[0] = GetComponent<PostProcessingBehaviour>();
        bloomScripts[1] = GetComponent<ImageEffectTest>();
        bloomScripts[2] = GetComponent<Bloom1>();
        bloomScripts[3] = GetComponent<Bloom2>();
        bloomScripts[4] = GetComponent<MobileBloom>();
    }

    // Update is called once per frame
    void Update()
    {
        if (oldIndex != toolbarInt) {
            for (int i = 0;i < bloomScripts.Length;i++) {
                bloomScripts[i].enabled = i == toolbarInt;
            }
            oldIndex = toolbarInt;
        }
    }

    private int toolbarInt = 0;
    int oldIndex = -1;
    private string[] toolbarStrings = { "bloom1", "bloom2", "bloom3", "bloom4", "bloom5", "close" };

    void OnGUI() {
        toolbarInt = GUI.Toolbar(new Rect(25, 25, 250, 30), toolbarInt, toolbarStrings);
    }

}
