using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private string currentState;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    public void ChangeAnimationStates(string newState)
    {
        if (currentState == newState)
            return;
        
        animator.Play(newState);

        currentState = newState;
    }
}
