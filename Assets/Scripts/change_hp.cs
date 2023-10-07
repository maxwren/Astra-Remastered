using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_hp : MonoBehaviour
{
    public bool wasPlayerHit = false; //this variable takes global static wasPlayerHit from player script
    public float player_hp; //this variable takes global static player_hp from player script

    Animator animator;
    private string currentState;

    const string HEALTH5 = "Health5";
    const string HEALTH4 = "Health4";
    const string HEALTH3 = "Health3";
    const string HEALTH2 = "Health2";
    const string HEALTH1 = "Health1";
    const string HEALTH0 = "Health0";
    const string HEALTHTR = "HealthTR";
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

    private void Update()
    {
        wasPlayerHit = player_movement.wasPlayerHit;
        player_hp = player_movement.player_hp;
        /*
        if (wasPlayerHit)
        {
            ChangeAnimationState(HEALTHTR);
        }
        */
        if(player_hp == 5)
        {
            ChangeAnimationState(HEALTH5);
        }
        if(player_hp == 4)
        {
            ChangeAnimationState(HEALTH4);
        }
        if(player_hp == 3)
        {
            ChangeAnimationState(HEALTH3);
        }
        if(player_hp == 2)
        {
            ChangeAnimationState(HEALTH2);
        }
        if(player_hp == 1)
        {
            ChangeAnimationState(HEALTH1);
        }
        if(player_hp == 0)
        {
            ChangeAnimationState(HEALTH0);
        }
    }
}
