using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    public float old_enemy_speed;
    public float fake_enemy_speed;
    public static bool shall_we_boost = false;

    public AudioSource boost_sound = null;

    public static bool is_boost_applied = false;
    private float boostEnding = 0f;

    float currentTime = 0f;
    public static float boostDuration = 5f;

    bool boostStopper = false;
    bool noBoostStopper = false;

    public static bool shouldWeDisplayDoubleScore = false;

    private Rigidbody2D rb;
    [SerializeField] GameObject boostTrigger;
    [SerializeField] GameObject doubleScore;
    
    private void boost_em()
    {
        if (!boostStopper)
        {
            boostTrigger.GetComponent<SpriteRenderer>().enabled = false;
            is_boost_applied = true;
            old_enemy_speed = enemy_movement.enemy_speed.x;
            enemy_movement.enemy_speed.x *= 2;
            BG_moving_2.bg_moving_speed *= 2f;
            asteroid_moving.bgmeteorSpeed *= 2f;
            boost_sound.Play();
            shouldWeDisplayDoubleScore = true;
            boostStopper = true;
        }
        /*
        is_boost_applied = true;
        old_enemy_speed = enemy_movement.enemy_speed.x;
        enemy_movement.enemy_speed.x *= 2;
        BG_moving_2.bg_moving_speed *= 2f;
        asteroid_moving.bgmeteorSpeed *= 2f;
        boost_sound.Play();
        */
    }
    private void no_boost()
    {
        if (!noBoostStopper)
        {
            is_boost_applied = false;
            enemy_movement.enemy_speed.x = fake_enemy_speed;
            BG_moving_2.bg_moving_speed /= 2f;
            asteroid_moving.bgmeteorSpeed /= 2f;
            shall_we_boost = false;
            shouldWeDisplayDoubleScore = false;
            noBoostStopper = true;
        }
        /*
        is_boost_applied = false;
        enemy_movement.enemy_speed.x = fake_enemy_speed;
        BG_moving_2.bg_moving_speed /= 2f;
        asteroid_moving.bgmeteorSpeed /= 2f;
        shall_we_boost = false;
        */
    }

    public GameObject enemyPrefab;
    public GameObject boostPrefab;
    public float boost_duration = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            shall_we_boost = true;
            boostStopper = false;
            boost_em();
            //StartCoroutine(boost_regulator());
            //boostActive();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            boostTrigger.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        is_boost_applied = false;
        currentTime = boostDuration;
    }
    private void Awake()
    {
        shall_we_boost = false; //this is potential problem becase individual boosts can affect global static
        rb = GetComponent<Rigidbody2D>();
        boost_sound = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (shall_we_boost)
        {
            boost_em();
            currentTime -= 1 * Time.deltaTime;
            if ((currentTime <= 0) || (player_movement.wasPlayerHit))
            {
                no_boost();
            }
        }
    }
    /*
    IEnumerator boost_regulator()
    {
        boost_em();
        boostTrigger.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(boost_duration);
        no_boost();
    }
    */
    /*
    public void boostActive()
    {
        boost_em();
        boostTrigger.GetComponent<SpriteRenderer>().enabled = false;
        if (() || (player_movement.wasPlayerHit))
        {
            Debug.Log("Hurray");
            no_boost();
        }
    }
    */
    private void FixedUpdate()
    {
        fake_enemy_speed = enemy_movement.fake_enemy_speed.x;
        rb.velocity = new Vector2(-1f, 0f);
    }
}
