using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCursor : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    private Vector2 mouseWorldPosition; //idk im tired
    private void Start()
    {

    }
    void Update()
    {
        mouseWorldPosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        transform.position = mouseWorldPosition;
    }
}
