using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class updateScore : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public static int playerScore;
    public static int fakePlayerScore;

    private float normal_font_size;
    public bool is_boost_applied = false; // to recieve value from Boost script

    // Start is called before the first frame update
    void Start()
    {
        scoreText = gameObject.GetComponent<TextMeshProUGUI>();
        //playerScore = enemy_movement.score;
        playerScore = 0;
        fakePlayerScore = 0;
        normal_font_size = scoreText.fontSize;
    }
    public void changeText()
    {
        scoreText.text = "Score: " + playerScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if (playerScore > PlayerPrefs.GetInt("highscore"))
        {
            PlayerPrefs.SetInt("highscore", playerScore);
        }
        changeText();
    }
    private void FixedUpdate()
    {
        is_boost_applied = Boost.shall_we_boost;
        playerScore += (int)enemy_movement.enemy_speed.x;
        fakePlayerScore += 1;
    }
}
