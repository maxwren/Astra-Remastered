using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class updateUpgrade : MonoBehaviour
{
    public static string currentUpgradeText;
    [SerializeField] TextMeshProUGUI upgradeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        upgradeText.text = "CURRENT UPGRADE: " + currentUpgradeText;
    }
}
