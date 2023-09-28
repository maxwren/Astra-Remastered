using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject gunTriggerGameObject;
    [SerializeField] CircleCollider2D triggerCollider;
    public static float gunDuration = 3f;
    public static bool playerHasGun;

    void Start()
    {
        playerHasGun = true;
    }
    private void Awake()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(gunTime());
            IEnumerator gunTime()
            {
                giveGun();
                gunTriggerGameObject.GetComponent<SpriteRenderer>().enabled = false;
                yield return new WaitForSeconds(gunDuration);
                noGun();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerCollider.enabled = false;
    }
    void giveGun()
    {
        playerHasGun = true;
    }
    void noGun()
    {
        playerHasGun = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-enemy_movement.enemy_speed.x, 0f);
    }
}
