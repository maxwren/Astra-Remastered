using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG_moving_2 : MonoBehaviour
{
    [SerializeField] private float shift_bg = -2.6f; // this position is taken from Unity, it's constant (I hope)
    [SerializeField] private float shifted_position = 2.7f; // also taken from Unity
    private Vector2 initial_position; // just in case
    [SerializeField] private float offset = 0;
    public static float bg_moving_speed = 1f;
    private float fake_bg_moving_speed = 1f;

    private Rigidbody2D rb;

    //second BG 2.485, -1.556

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initial_position = rb.position;
        bg_moving_speed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }    
    private void FixedUpdate()
    {
        //bg_moving_speed = Boost.close_bg_moving_speed;
        rb.velocity = new Vector2(-bg_moving_speed * Time.deltaTime, 0);
        if (rb.position.x <= shift_bg)
        {
            rb.position = new Vector2(shifted_position + offset, initial_position.y);
        }
    }
}
