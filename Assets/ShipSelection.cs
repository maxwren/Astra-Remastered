using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShipSelection : MonoBehaviour
{
    [SerializeField] GameObject ShipSprite;
    [SerializeField] GameObject ShipSpritePrev;
    [SerializeField] GameObject ShipSpriteNext;

    [SerializeField] TextMeshProUGUI ShipName;

    public static int currentShip = 1;
    private int previousShip = 1;
    private int nextShip = 1;

    [SerializeField] Sprite[] shipSkinSprites;

    private void Start()
    {
        //currentShip = PlayerPrefs.GetInt("player_skin");
    }

    private void Update()
    {
        if (currentShip <= 0)
        {
            previousShip = shipSkinSprites.Length - 1;
        }
        else
        {
            previousShip = currentShip - 1;
        }

        if (currentShip >= shipSkinSprites.Length - 1)
        {
            nextShip = 0;
        }
        else
        {
            nextShip = currentShip + 1;
        }
        ShipSprite.GetComponent<Image>().sprite = shipSkinSprites[currentShip];
        ShipSpritePrev.GetComponent<Image>().sprite = shipSkinSprites[previousShip];
        ShipSpriteNext.GetComponent<Image>().sprite = shipSkinSprites[nextShip];

        Debug.Log("Current ship: " + currentShip);
    }
    public void GoLeft()
    {

        if (currentShip <= 0) {
            currentShip = shipSkinSprites.Length;
        }
        if (currentShip > 0)
        {
            currentShip--;
        }
    }
    public void GoRight()
    {
        if (currentShip >= shipSkinSprites.Length - 1) {
            currentShip = 0;
        }
        else
        {
            currentShip++;
        }
    }
}
