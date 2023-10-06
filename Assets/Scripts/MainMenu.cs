using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject HangarUI;
    [SerializeField] GameObject MainMenuUI;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void EnterHangar()
    {
        DrawHangarUI();
        ShipSelection.currentShip = PlayerPrefs.GetInt("player_skin");
    }
    private void DrawHangarUI()
    {
        HangarUI.SetActive(true);
        MainMenuUI.SetActive(false);
    }
    public void HideHangarUI()
    {
        HangarUI.SetActive(false);
        MainMenuUI.SetActive(true);
    }
    public void ConfirmShipSelection()
    {
        PlayerPrefs.SetInt("player_skin", ShipSelection.currentShip);
    }
} 
