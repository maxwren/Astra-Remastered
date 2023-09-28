using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_movement : MonoBehaviour
{
    //THIS CODE DECLARES VARIABLES:
    //FLOATS:
    [SerializeField] float explosion_timer = 0.5f;
    private float timer;
    private float rotationZ;
    private float rotationSpeed;
    private float speedY = 0;

    //INTEGERS:
    public static int playerScore;
    public static int enemy_hp;
    public int remainder;
    private int isClockwise;
    private int randomSprite;

    //STRINGS:

    //OBJECTS:
    public GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] CircleCollider2D enemyCollider;
    private Rigidbody2D rb;
    private ParticleSystem particles;
    private SpriteRenderer sprite_renderer;

    public player_movement script;
    Animator animator;
    private string currentState;
    const string METEOR_EXPLOSION = "MeteorExplosion";
    const string METEOR_IDLE = "MeteorIdle";

    private bool was_meteor_hit = false;

    [SerializeField] public static Vector2 enemy_speed = new Vector2(1, 0);
    [SerializeField] public static Vector2 fake_enemy_speed = new Vector2(1, 0);

    private bool clockwise;

    public bool is_boost_applied = false;
    private float old_enemy_speed;

    public static bool playMeteorSound;

    [SerializeField] int meteor_hp = 6;

    [SerializeField] Sprite meteor_sprite_1;
    [SerializeField] Sprite meteor_sprite_2;
    [SerializeField] Sprite meteor_sprite_3;
    [SerializeField] Sprite meteor_sprite_4;
    [SerializeField] Sprite meteor_sprite_5;

    public AudioSource explosion_sound = null;

    // Start is called before the first frame update
    void Start()
    {
        playMeteorSound = false;
        playerScore = 0;
        //enemy = GetComponent<GameObject>();
        script = player.GetComponent<player_movement>();
        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        enemy_hp = 3;

        rb = GetComponent<Rigidbody2D>();
        particles = GetComponent<ParticleSystem>();
        sprite_renderer = GetComponent<SpriteRenderer>();
        isClockwise = Random.Range(0, 2);
        if (isClockwise <= 0)
        {
            clockwise = false;
        }
        if (isClockwise >= 1)
        {
            clockwise = true;
        }
        rotationSpeed = Random.Range(0.1f, 0.5f);
        rotationZ = 1;
        speedY = Random.Range(0.1f, -0.1f);

        randomSprite = Random.Range(1, 6); // choosing random sprite for our meteor
        if (randomSprite == 1)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = meteor_sprite_1;
        }
        if (randomSprite == 2)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = meteor_sprite_2;
        }
        if (randomSprite == 3)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = meteor_sprite_3;
        }
        if (randomSprite == 4)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = meteor_sprite_4;
        }
        if (randomSprite == 5)
        {
            enemy.GetComponent<SpriteRenderer>().sprite = meteor_sprite_5;
        }
    }

    void TakeBulletDamage()
    {
        meteor_hp--;
        if (meteor_hp <= 0)
        {
            was_meteor_hit = true;
            playMeteorSound = true;
        }
    }

    void ChangeAnimationState(string newState)
    {
        if (currentState == newState)
        {
            return;
        }
        animator.Play(newState);
        currentState = newState;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //ChangeAnimationState(METEOR_EXPLOSION);
            was_meteor_hit = true;
            playMeteorSound = true;
            //Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Shield")
        {
            //Destroy(this.gameObject);
            was_meteor_hit = true;
            playMeteorSound = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeBulletDamage();
            //was_meteor_hit = true;
            //playMeteorSound = true;
        }
    }
    void Update()
    {
        if (was_meteor_hit)
        {             
            enemyCollider.GetComponent<CircleCollider2D>().enabled = false;
            particles.Emit(1);
            this.sprite_renderer.enabled = false; //hides the meteor until it's destroyed
            timer += Time.deltaTime;
            if (timer > explosion_timer)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void FixedUpdate()
    {
        if (clockwise)
        {
            rotationZ += rotationSpeed;
        }
        if (!clockwise)
        {
            rotationZ -= rotationSpeed;
        }
        playerScore = updateScore.playerScore;
        rb.velocity = new Vector2(-enemy_speed.x, speedY);
        rb.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        is_boost_applied = Boost.shall_we_boost;

        if ((playerScore >= 10000) && (!is_boost_applied))
        {
            if (playerScore <= 15000)
            {
                enemy_speed.x = playerScore / 10000f;
                fake_enemy_speed.x = playerScore / 10000f;
            }
        }
        if (rb.position.x < -2)
        {
            Destroy(this.gameObject);
        }
        if (enemy_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
