using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_field_trigger : MonoBehaviour
{    
    public AudioSource fieldSound = null;

    public static float fieldDuration = 10f;
    [SerializeField] float fieldIndicatorTimer = 1f;

    public static bool fieldIndicatorCheck = false;

    private Rigidbody2D rb;
    [SerializeField] GameObject gravyTrigger;
    public static bool playerHasField;

    private void giveField()
    {
        playerHasField = true;
    }
    private void noField()
    {
        playerHasField = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(fieldTime());
            IEnumerator fieldTime() {
                giveField();
                gravyTrigger.GetComponent<SpriteRenderer>().enabled = false;
                StartCoroutine(fieldIndicator());
                IEnumerator fieldIndicator()
                {
                    yield return new WaitForSeconds(fieldDuration - fieldIndicatorTimer);
                    fieldIndicatorCheck = true;
                }
                yield return new WaitForSeconds(fieldDuration);
                noField();
                fieldIndicatorCheck = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gravyTrigger.GetComponent<CircleCollider2D>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        playerHasField = false;
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        fieldSound = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-enemy_movement.enemy_speed.x, 0f);
    }
}
