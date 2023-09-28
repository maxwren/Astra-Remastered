using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class updateSpeed : MonoBehaviour
{
    public float speed = enemy_movement.enemy_speed.x * 10000 / 2;
    [SerializeField] TextMeshProUGUI speedText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = enemy_movement.enemy_speed.x * 10000 / 2;
        speedText.text = "SPEED: " + speed.ToString() + " MPH";
    }
}
