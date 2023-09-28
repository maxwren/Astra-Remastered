using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateGun : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    //[SerializeField] Rigidbody2D rb;
    Vector2 mousePos;
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        //Vector2 lookDir = mousePos - rb.position;
        //rb.rotation = angle;

        Vector2 lookDir = mousePos - new Vector2 (transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
