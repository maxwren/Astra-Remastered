using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class updateUpgradeTimeLeft : MonoBehaviour
{
    private float fieldDuration = gravity_field_trigger.fieldDuration;
    private float shieldDuration = force_shield_trigger.shieldDuration + force_shield_trigger.indicatorDuration;
    private float gunDuration = gun_trigger.gunDuration;
    private float boostDuration = Boost.boostDuration;
    private float countdown;
    private float countdownTextValue;
    private bool updateBreak = false;
    private bool shieldFuckeryStopper = false;
    [SerializeField] TextMeshProUGUI upgradeCountdown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gravity_field_trigger.playerHasField)
        {
            if (!updateBreak)
            {
                countdown = fieldDuration;
                updateBreak = true;
            }            
            countdown -= 1f * Time.deltaTime;
            countdownTextValue = (int)countdown;
            upgradeCountdown.text = "UPGRADE TIMER: " + countdownTextValue.ToString();
            if (countdown <= 0) // || (the ability evaporated) but it seems that can only happen with Boost so I just won't bother here
            {
                updateUpgrade.currentUpgradeText = "NONE";
                updateBreak = false;
            }
        }
        if ((force_shield_trigger.playerHasShield) && (!shieldFuckeryStopper))
        {
            if (!updateBreak)
            {
                countdown = shieldDuration;
                updateBreak = true;
            }
            countdown -= 1f * Time.deltaTime;
            countdownTextValue = (int)countdown;
            if (countdown > 0)
            {
                upgradeCountdown.text = "UPGRADE TIMER: " + countdownTextValue.ToString();
            }
            if (countdown <= 0)
            {
                updateUpgrade.currentUpgradeText = "NONE";
                shieldFuckeryStopper = true;
                updateBreak = false;
            }
        }
        if (!force_shield_trigger.playerHasShield)
        {
            shieldFuckeryStopper = false; // should work now
        }
        if (gun_trigger.playerHasGun)
        {
            if (!updateBreak)
            {
                countdown = gunDuration;
                updateBreak = true;
            }
            countdown -= 1f * Time.deltaTime;
            countdownTextValue = (int)countdown;
            upgradeCountdown.text = "UPGRADE TIMER: " + countdownTextValue.ToString();
            if (countdown <= 0)
            {
                updateUpgrade.currentUpgradeText = "NONE";
                updateBreak = false;
            }
        }
        if (Boost.is_boost_applied)
        {
            if (!updateBreak)
            {
                countdown = boostDuration;
                updateBreak = true;
            }
            countdown -= 1f * Time.deltaTime;
            countdownTextValue = (int)countdown;
            upgradeCountdown.text = "UPGRADE TIMER: " + countdownTextValue.ToString();
            //if ((countdown <= 0) || (Boost.is_boost_applied))
            if (countdown <= 0)
            {
                updateUpgrade.currentUpgradeText = "NONE";
                //countdown = 0;
                updateBreak = false;
            }
        }
        if (player_movement.noAbilities)
        {
            countdown = 0;
            countdownTextValue = (int)countdown;
            upgradeCountdown.text = "UPGRADE TIMER: " + countdownTextValue.ToString();
        }
    }
}
