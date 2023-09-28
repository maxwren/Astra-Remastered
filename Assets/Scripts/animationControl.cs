using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationControl : MonoBehaviour
{

    Animator animator;
    private string currentState;

    const string PLAYER_IDLE = "SpaceshipIdle";
    const string PLAYER_EXPLOSION = "player_explosion";

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }
        
        animator.Play(newState);

        currentState = newState;
    }
}
