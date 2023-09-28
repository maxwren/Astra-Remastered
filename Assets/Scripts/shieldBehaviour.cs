using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldBehaviour : MonoBehaviour
{
    public static GameObject shield_gameObject;
    [SerializeField] float shieldRenewTime;
    public static int shieldHp;
    public static int shieldHpBaseline;
    // Start is called before the first frame update
    void Start()
    {        
        shieldHp = 1;
        shieldHpBaseline = 1;
    }
    private void Awake()
    {
        //StartCoroutine(renewShield());
        shield_gameObject = GetComponent<GameObject>();
    }
    /*
    IEnumerator renewShield()
    {
        while (true)
        {
            yield return new WaitForSeconds(shieldRenewTime);
            if (!gameObj.activeSelf)
            {
                gameObj.SetActive(true);
                Debug.Log("Making a shield!");
            }
        }
    }
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            shieldHp -= 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shieldHp <= 0)
        {
            shield_gameObject.SetActive(false);
        }
    }
}
