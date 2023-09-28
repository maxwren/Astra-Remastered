using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asteroid_moving_2 : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    [SerializeField] GameObject asteroid;
    [SerializeField] float bg2Speed;
    [SerializeField] public static float bgmeteorSpeed;

    private float rotationZ;
    private float rotationSpeed;
    private bool clockwise;
    private int isClockwise;

    private SpriteRenderer rb_sprite;

    [SerializeField] Sprite asteroid_sprite_1;
    [SerializeField] Sprite asteroid_sprite_2;
    [SerializeField] Sprite asteroid_sprite_3;
    private int randomSprite;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bgmeteorSpeed = bg2Speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Awake()
    {
        randomSprite = Random.Range(1, 4);
        rb_sprite = GetComponent<SpriteRenderer>();
        if (randomSprite == 1)
        {
            //rb_sprite.Sprite = asteroid_sprite_1;
            asteroid.GetComponent<SpriteRenderer>().sprite = asteroid_sprite_1;
        }
        if (randomSprite == 2)
        {
            //rb_sprite.GetComponent<Image>().sprite = asteroid_sprite_2;
            asteroid.GetComponent<SpriteRenderer>().sprite = asteroid_sprite_2;
        }
        if (randomSprite == 3)
        {
            //rb_sprite.GetComponent<Image>().sprite = asteroid_sprite_3;
            asteroid.GetComponent<SpriteRenderer>().sprite = asteroid_sprite_3;
        }
        isClockwise = Random.Range(0, 2);
        if (isClockwise <= 0)
        {
            clockwise = false;
        }
        if (isClockwise >= 1)
        {
            clockwise = true;
        }
        rotationSpeed = Random.Range(0.05f, 0.2f);
        rotationZ = 1;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-1 * bgmeteorSpeed * Time.deltaTime, 0);
        if (clockwise)
        {
            rotationZ += rotationSpeed;
        }
        if (!clockwise)
        {
            rotationZ -= rotationSpeed;
        }
        rb.transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        if (rb.position.x < -2)
        {
            //rb.position = new Vector2(2, 0);
            Destroy(this.gameObject);
        }
    }
}
