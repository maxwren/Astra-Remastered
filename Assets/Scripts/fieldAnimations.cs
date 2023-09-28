using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fieldAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;

    private string currentState;
    const string FIELD_IDLE = "GravityFieldIdle";
    const string FIELD_IND = "FieldIndicator";
    void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }
        animator.Play(newState);
        currentState = newState;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gravity_field_trigger.fieldIndicatorCheck)
        {
            ChangeAnimationState(FIELD_IDLE);
        }   
        if (gravity_field_trigger.fieldIndicatorCheck)
        {
            ChangeAnimationState(FIELD_IND);
        }
    }
}
