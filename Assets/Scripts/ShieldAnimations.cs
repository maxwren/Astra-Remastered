using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAnimations : MonoBehaviour
{
    [SerializeField] Animator shieldAnim;

    private float timer = 1f;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            shieldAnim.SetBool("ifWave", true);
            timer = Random.Range(0.5f, 1f);
        }
        else
        {
            shieldAnim.SetBool("ifWave", false);
        }
        if (force_shield_trigger.shieldDestruction)
        {
            shieldAnim.SetBool("isFading", true);
        }
        if (!force_shield_trigger.shieldDestruction)
        {
            shieldAnim.SetBool("isFading", false);
        }
    }

    /*
    const string SHIELD_IDLE = "ShieldIdle";
    const string SHIELD_IND = "ShieldFading";
    const string SHIELD_DESTRUCTION = "ShieldDestruction";
    private string currentState;
    Animator animator;

    [SerializeField] float shieldDuration;
    [SerializeField] float shieldFadingTimer;

    public bool doesPlayerHaveShield = false;

    private float timer;
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
        doesPlayerHaveShield = false;
        animator = GetComponent<Animator>();
        ChangeAnimationState(SHIELD_IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        if ((force_shield_trigger.indicator) && (!force_shield_trigger.shieldDestruction))
        {
            ChangeAnimationState(SHIELD_IND);           
        }
        if ((!force_shield_trigger.indicator) && (!force_shield_trigger.shieldDestruction))
        {
            ChangeAnimationState(SHIELD_IDLE);
        }
        if (force_shield_trigger.shieldDestruction)
        {
            ChangeAnimationState(SHIELD_DESTRUCTION);
        }
    }
    */
}
