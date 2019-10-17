using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       StartCoroutine(DelayPlay());
    }

    IEnumerator  DelayPlay() {
        yield return new WaitForSeconds(1);
        PlayAnimation("Scale");
        yield return new WaitForSeconds(0.5f);
        PlayAnimation("Scale");
    }

    void PlayAnimation(string name) {
        Animator animator = GetComponent<Animator>();
        var info = animator.GetCurrentAnimatorStateInfo(0);
        
        Debug.LogError("=======PlayAnimation======"+ info.IsName(name));
        animator.Play(name);
        GetComponent<AnimatorFinishEventTrigger>().OnFinishAnimation = (clipame) => {
            Debug.LogError("=======OnFinishAnimation======");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
