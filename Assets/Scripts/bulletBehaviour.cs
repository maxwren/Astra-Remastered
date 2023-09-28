using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    [SerializeField] ParticleSystem particles;
    private bool enemyWasHit = false;

    private void Awake()
    {
        enemyWasHit = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (transform.position.x >= Mathf.Abs(2))
        {
            Destroy(gameObject);
        }
        if (transform.position.y >= Mathf.Abs(2))
        {
            Destroy(gameObject);
        }
    }
}
