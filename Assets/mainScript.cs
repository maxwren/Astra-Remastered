using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mainScript : MonoBehaviour
{
    [SerializeField] GameObject particles;
    [SerializeField] Rigidbody2D player;
    [SerializeField] AudioSource stormSoundEffects;
    [SerializeField] AudioSource stormSoundEffectsWind;
    [SerializeField] float cosmicStormDuration;

    [SerializeField] Slider volumeSlider;
    public static float volumeSliderValue = 1;
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource impactSound;
    [SerializeField] AudioSource shieldPickUpSound;

    private float cosmicStormFrequency;
    private bool isStormActive = false;

    public static Vector2 stormForce;
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume_value", volumeSliderValue);
        //volumeSliderValue = volumeSlider.value;
        stormForce = new Vector2(0, 0);
        particles.SetActive(false);
        cosmicStormFrequency = Random.Range(30f, 120f);
        StartCoroutine(CosmicStormPeriod());
    }

    void StartCosmicStorm()
    {
        isStormActive = true;
        StartStormParticles();
        StartStormSoundEffect();
        ApplyStormForces();
    }

    void StartStormParticles()
    {
        particles.SetActive(true);
    }
    void StartStormSoundEffect()
    {
        stormSoundEffects.Play();
        stormSoundEffectsWind.Play();
    }
    void ApplyStormForces()
    {
        stormForce = new Vector2(-1, 0);
    }

    //DISABLING THE COSMIC STORM
    void StopCosmicStorm()
    {
        isStormActive = false;
        cosmicStormFrequency = Random.Range(30f, 120f);
        StopStormParticles();
        StopStormSoundEffect();
        DisableStormForces();
    }
    void StopStormParticles()
    {
        particles.SetActive(false);
    }
    void StopStormSoundEffect()
    {

    }
    void DisableStormForces()
    {
        stormForce.Set(0, 0);
    }
    IEnumerator CosmicStormPeriod()
    {
        while (true)
        {
            yield return new WaitForSeconds(cosmicStormFrequency);
            StartCoroutine(CosmicStormEvent());
            IEnumerator CosmicStormEvent()
            {
                if (!isStormActive)
                {
                    StartCosmicStorm();
                    yield return new WaitForSeconds(cosmicStormDuration);
                    if (isStormActive)
                    {
                        StopCosmicStorm();
                    }

                    //StopCosmicStorm();
                }

            }
        }
    }

    void Update()
    {
        volumeSliderValue = volumeSlider.value;
        PlayerPrefs.SetFloat("volume_value", volumeSliderValue);
        stormSoundEffects.volume = volumeSliderValue;
        stormSoundEffectsWind.volume = volumeSliderValue;
        backgroundMusic.volume = volumeSliderValue / 5;

        /*stormSoundEffects.volume = volumeSlider.value;
        stormSoundEffectsWind.volume = volumeSlider.value;
        backgroundMusic.volume = volumeSlider.value / 5;
        */
        impactSound.volume = volumeSlider.value; //it has to be louder than other sound effects. also I should probs make a variable for this
        shieldPickUpSound.volume = volumeSlider.value;
    }
}
