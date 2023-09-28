using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG_moving : MonoBehaviour
{
    // Start is called before the first frame update

    //public Vector2 bg2_position = new Vector2(2, 0);
    public Vector2 initialPosition;
    private float bg_moving_delta;
    public float bg_moving_speed = 0.5f;
    [SerializeField] float offset = -1f;

    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(bg_moving_speed * Time.deltaTime, 0);

        bg_moving_delta = Mathf.Abs(transform.position.x - initialPosition.x);

        if (transform.position.x <= -9)
        {
            transform.position = new Vector2(transform.position.x + bg_moving_delta + offset, initialPosition.y);
        }
       /* if (transform.position.x < initialPosition.x + initialPosition.x)
        {
            transform.position = (initialPosition);
        }
       */
    }
}
