using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_shake : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator camAnim;

    public void CamShake()
    {
        camAnim.SetTrigger("Shake");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
