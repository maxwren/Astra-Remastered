using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Rigidbody2D player_rb;

    [SerializeField] private float offset;

    void Start()
    {
        
    }
    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        rb.position = new Vector2(player_rb.position.x + offset, player_rb.position.y);
    }
}
