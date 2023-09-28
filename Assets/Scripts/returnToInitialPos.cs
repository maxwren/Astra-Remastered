using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class returnToInitialPos : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Rigidbody2D rb;
    private Vector2 initialPos;

    void Start()
    {
        initialPos = rb.position;
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
        rb.position = initialPos;
    }
}
