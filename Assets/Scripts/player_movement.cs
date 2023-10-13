using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class player_movement : MonoBehaviour
{
    //THIS CODE DECLARES VARIABLES:
    //FLOATS:
    public static int player_hp = 5; // it used to be float for some reason, I've changed it so expect errors
    private float timer;
    private float rotationZ_value;
    private float rotationZ;
    private float sizeX;
    private float sizeY;
    private Vector2 screenBounds;
    private Vector2 mousePos;
    [SerializeField] Camera mainCam;
    [SerializeField] float spaceshipWidth;
    [SerializeField] float spaceshipHeight;
    [SerializeField] float explosion_timer = 1f;

    //INTEGERS:
    //public static int highscore = 0;

    //BOOLS:
    private bool isPlayerDead = false;
    private bool can_player_be_hit_again;
    public static bool isMousePressed; //Later make it touch
    public static bool noAbilities = true;
    public static bool wasPlayerHit = false;
    public static bool inMenu = true;
    [SerializeField] bool mouseControl = false;

    //VECTORS:
    public Vector2 externalForce;

    //OBJECTS:
    public CameraShake cameraShake;
    public static Rigidbody2D player_rb;
    public AudioSource explosion_sound = null;
    public Vector2 player_speed = new Vector2(10, 10);
    private Vector2 char_movement;
    private Vector3 char_movement_touch;
    [SerializeField] GameObject gravityField;
    [SerializeField] GameObject forceShield;
    [SerializeField] GameObject gunGameObject;
    [SerializeField] GameObject playerCursor;
    [SerializeField] GameObject player;

    [SerializeField] GameObject Player_skin01;
    [SerializeField] GameObject Player_skin02;
    [SerializeField] GameObject Player_skin03;
    [SerializeField] GameObject Player_skin04;
    [SerializeField] GameObject Player_skin05;

    [SerializeField] GameObject newCursor;

    [SerializeField] bool touchControls;
    [SerializeField] float joystick_offset;
    [SerializeField] Animator healthbar_anim;

    private bool search_stopper = false;

    Dictionary<string, int> ship_names = new Dictionary<string, int>();
    private string skin_name = "Player_skin01";

    [SerializeField] int Player_skin_choice;
    public static int Player_skin_active;
    //THIS SHOULD LATER CHANGE ACCODRING TO PLAYER'S CHOICE

    Animator animator;

    public Joystick joystick;

    //Find a game object by name or tag
    //If it exists within the given standard, add it to the list or dictionary

    //THIS PART OF CODE DECLARES FUNCTIONS:
    void Start()
    {
        Player_skin_active = 1 + PlayerPrefs.GetInt("player_skin");
        gravity_field_trigger.playerHasField = false;
        player.GetComponent<PolygonCollider2D>().enabled = true;
        player_rb = GetComponent<Rigidbody2D>();
        player_hp = 5;
        animator = GetComponent<Animator>();
        sizeX = transform.localScale.x;
        sizeY = transform.localScale.y;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        noAbilities = true;


        if (!search_stopper)
        {
            for (int i = 0; i < 10; i++)
            {
                skin_name = "Player_skin0" + i.ToString();
                if (GameObject.Find(skin_name) != null)
                {
                    ship_names.Add(skin_name, i);
                    //if (i != ShipSelection.currentShip-1)
                    if (i != Player_skin_active)
                    {
                        GameObject.Find(skin_name).SetActive(false);
                    }
                }
                else
                {
                    search_stopper = true;
                }
            }
        }
        else
        {
            Debug.Log("No such skin found");
        }
        GameObject.Find("Player_skin01");
    }
    private void substruct_hp()
    {
        if ((!force_shield_trigger.playerHasShield) && (!Boost.is_boost_applied))
        {
            player_hp -= 1;
        }
        if (force_shield_trigger.playerHasShield)
        {
            if (!force_shield_trigger.shieldDestruction)
            {
                return;
            }
            else
            {
                player_hp -= 1;
            }
        }
        explosion_sound.Play();
        StartCoroutine(cameraShake.Shake(0.5f, 1.5f));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            substruct_hp();
            wasPlayerHit = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        wasPlayerHit = false;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isMousePressed = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isMousePressed = false;
        }
        if (!inMenu)
        {
            //Cursor.visible = false;
        }
        Cursor.visible = false;
        //Cursor.visible = false; this shit isn't too good
        if (!isPlayerDead)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetKey(KeyCode.W))
            {
                rotationZ_value = 15f;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rotationZ_value = -15f;
            }
            //TOUCH CONTROLS
            if (touchControls)
            {
                char_movement = new Vector2(joystick.Horizontal, joystick.Vertical).normalized / joystick_offset;
            } else
            {
                char_movement = new Vector2(inputX, inputY);
            }

            if (gravity_field_trigger.playerHasField)
            {
                gravityField.SetActive(true);
                updateUpgrade.currentUpgradeText = "GRAVITY FIELD";
            }
            if (!gravity_field_trigger.playerHasField)
            {
                gravityField.SetActive(false);
            }
            
            if (force_shield_trigger.playerHasShield)
            {
                forceShield.SetActive(true);
                updateUpgrade.currentUpgradeText = "FORCE SHIELD";
            }
            if (!force_shield_trigger.playerHasShield)
            {
                forceShield.SetActive(false);
            }

            if (gun_trigger.playerHasGun)
            {
                gunGameObject.SetActive(true); //this object allows us to shoot
                if (isMousePressed)
                {
                    playerCursor.SetActive(true);
                }
                if (!isMousePressed)
                {
                    playerCursor.SetActive(false);
                }
                updateUpgrade.currentUpgradeText = "BLASTER";
            }
            if (!gun_trigger.playerHasGun)
            {
                gunGameObject.SetActive(false);
                playerCursor.SetActive(false);
            }
            if (Boost.is_boost_applied)
            {
                updateUpgrade.currentUpgradeText = "SPEED BOOST";
            }
            if (!gun_trigger.playerHasGun && !force_shield_trigger.playerHasShield && !gravity_field_trigger.playerHasField && !Boost.is_boost_applied)
            {
                updateUpgrade.currentUpgradeText = "NONE";
                noAbilities = true;
            }
            if (gun_trigger.playerHasGun || force_shield_trigger.playerHasShield || gravity_field_trigger.playerHasField || Boost.is_boost_applied)
            {
                noAbilities = false;
            }
        }
        if (enemy_movement.playMeteorSound)
        {
            explosion_sound.Play();
            enemy_movement.playMeteorSound = false;
        }
        if (player_hp <= 0)
        {
            isPlayerDead = true;
            player.GetComponent<PolygonCollider2D>().enabled = false;
            //Play death animation
            if (sizeX > 0.1f)
            {
                player_rb.transform.localScale = new Vector2(sizeX, sizeY);
                sizeX -= 0.001f / 2;
                sizeY -= 0.001f / 2;
            }
            timer += Time.deltaTime;
            if (timer > explosion_timer)
            {
                this.gameObject.SetActive(false);
                enemy_movement.enemy_speed.x = 1f; // these two are to reset speed from previous game
                enemy_movement.fake_enemy_speed.x = enemy_movement.enemy_speed.x;
                gun_trigger.playerHasGun = false;
                gravityField.SetActive(false);
                forceShield.SetActive(false);
                gunGameObject.SetActive(false);
                UnityEngine.SceneManagement.SceneManager.LoadScene("First level");
            }
        }
        healthbar_anim.SetInteger("player_hp", player_hp);
    }
    private void FixedUpdate()
    {
        if (char_movement.y > 0)
        {
            if (rotationZ < 10f)
            {
                rotationZ += 1f;
            }
        }
        else if (char_movement.y < 0)
        {
            if (rotationZ > -10f)
            {
                rotationZ -= 1f;
            }
        }
        else
        {
            if (rotationZ != 0)
            {
                if (rotationZ > 0)
                {
                    rotationZ -= 1f;
                }
                if (rotationZ < 0)
                {
                    rotationZ += 1f;
                }
            }
        }
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        //
        externalForce = mainScript.stormForce;
        transform.position = new Vector2(
            //Mathf.Clamp(transform.position.x, -1.25f, 1.25f),
            //Mathf.Clamp(transform.position.y, -0.55f, 0.55f)
            Mathf.Clamp(transform.position.x, -screenBounds.x + spaceshipWidth, screenBounds.x - spaceshipWidth),
            Mathf.Clamp(transform.position.y, -screenBounds.y + spaceshipHeight, screenBounds.y - spaceshipHeight)
        );
        player_rb.velocity = char_movement * player_speed * Time.deltaTime + externalForce;
    }
}
