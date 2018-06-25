using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimatorTest : MonoBehaviour {

    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = transform.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (animator != null)
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            Debug.Log(info.normalizedTime);
        }
	}
}
