using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class updateHighscore : MonoBehaviour
{

    public TextMeshProUGUI hightscoreText;
    public static int playerHighscore;

    void Start()
    {
        hightscoreText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    public void changeHighscore()
    {
        hightscoreText.text = "High score: " + PlayerPrefs.GetInt("highscore").ToString();
    }
    // Update is called once per frame
    void Update()
    {
        changeHighscore();
    }
}
