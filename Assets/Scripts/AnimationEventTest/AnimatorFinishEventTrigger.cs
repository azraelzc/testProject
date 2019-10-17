using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorFinishEventTrigger: MonoBehaviour
{
    public Action<string> OnFinishAnimation;
    RuntimeAnimatorController ac;
    // Start is called before the first frame update
    void Awake()
    {
        ac = GetComponent<UnityEngine.Animator>().runtimeAnimatorController;
        string methodName = "OnFinishAnimationTrigger";
        if (ac != null && ac.animationClips != null) {
            foreach (var clip in ac.animationClips) {
                bool isAdd = false;
                if (clip.events != null) {
                    foreach (var e in clip.events) {
                        if (e.functionName == methodName) {
                            isAdd = true;
                        }
                    }
                }
                if (isAdd) {
                    continue;
                }
                var finishEvent = new AnimationEvent();
                finishEvent.functionName = methodName;
                finishEvent.stringParameter = clip.name;
                finishEvent.time = clip.length;
                clip.AddEvent(finishEvent);
            }
        }
    }

    void OnFinishAnimationTrigger(string name) {
        Debug.Log("======OnFinishAnimationTrigger======" + name);
        OnFinishAnimation?.Invoke(name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
