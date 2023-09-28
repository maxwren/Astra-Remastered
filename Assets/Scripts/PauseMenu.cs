using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool is_game_paused = false;
    public GameObject pauseMenuUI;
    public GameObject mainUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (is_game_paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
        pauseMenuUI.SetActive(false);
        mainUI.SetActive(true);
        Time.timeScale = 1f;
        is_game_paused = false;
    }
    private void pause()
    {
        pauseMenuUI.SetActive(true);
        mainUI.SetActive(false);
        Time.timeScale = 0f;
        is_game_paused = true;
    }
    public void load_menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main menu");
    }
    public void quit_game()
    {
        Application.Quit();
    }
}
