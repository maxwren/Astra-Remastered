using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMeteorBg : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject enemy;
    private SpriteRenderer sprite_renderer;

    [SerializeField] float meteorMainBgMovingSpeed;

    private float rotationZ;
    private float rotationSpeed;
    private bool clockwise;
    private int isClockwise;

    [SerializeField] Sprite meteor_sprite_1;
    [SerializeField] Sprite meteor_sprite_2;
    [SerializeField] Sprite meteor_sprite_3;
    [SerializeField] Sprite meteor_sprite_4;
    [SerializeField] Sprite meteor_sprite_5;
    private int randomSprite;

    private float speedY = 0;
    // Start is called before the first frame update
    private void Awake()
    {
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

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(-meteorMainBgMovingSpeed, 0);

        if (clockwise)
        {
            rotationZ += rotationSpeed;
        }
        if (!clockwise)
        {
            rotationZ -= rotationSpeed;
        }
        rb.transform.rotation = Quaternion.Euler(0, 0, rotationZ);

        if (rb.position.x <= -2)
        {
            Destroy(gameObject);
        }
    }
}
