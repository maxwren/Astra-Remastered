using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] float bulletForce = 1f;
    private float timer;

    [SerializeField] float timerSpeed = 1f; //Later this should be upgradable

    private void Start()
    {
        gun_trigger.playerHasGun = true;
        timer = timerSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        */
        if (player_movement.isMousePressed)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Shoot();
                timer = timerSpeed;
            }
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
} 
