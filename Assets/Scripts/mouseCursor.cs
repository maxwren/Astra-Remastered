using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] float rotation_speed_z;
    private Vector2 mouseWorldPosition; //idk im tired
    private void Start()
    {

    }
    void Update()
    {
        mouseWorldPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        transform.Rotate(0, 0, rotation_speed_z * Time.deltaTime);
    }
    private void FixedUpdate()
    {
        transform.position = mouseWorldPosition;
    }
}
