using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force_shield_trigger : MonoBehaviour
{
    public AudioSource shieldSound = null;

    public static float shieldDuration = 5f;
    public static float indicatorDuration = 1f;
    [SerializeField] float shieldDestructionAnimTimer = 3f;
    [SerializeField] GameObject shieldObject;
    [SerializeField] AudioSource shieldPickUpSound;
    private Rigidbody2D rb;
    public static bool playerHasShield;
    public static bool shieldDestruction = false;
    public static bool indicator = false;

    private void giveShield()
    {
        playerHasShield = true;
        shieldPickUpSound.Play();
    }
    private void noShield()
    {
        StartCoroutine(ShieldDestructionAnimation());
        IEnumerator ShieldDestructionAnimation()
        {
            shieldDestruction = true;
            yield return new WaitForSeconds(shieldDestructionAnimTimer);
            shieldDestruction = false;
            playerHasShield = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            giveShield();
            shieldObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(shieldTime());
            IEnumerator shieldTime()
            {
                StartCoroutine(indicatorTimer());
                IEnumerator indicatorTimer()
                {
                    yield return new WaitForSeconds(shieldDuration - indicatorDuration);
                    indicator = true;
                }
                yield return new WaitForSeconds(shieldDuration);
                noShield();
                indicator = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shieldObject.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHasShield = false;
        shieldDestruction = false;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        shieldSound = GetComponent<AudioSource>();
        shieldObject.GetComponent<CircleCollider2D>().enabled = true;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-enemy_movement.enemy_speed.x, 0f);
    }
}
