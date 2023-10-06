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
    [SerializeField] Sprite[] shipSkinSprites;
    [SerializeField] string[] shipSkinNames;

    public static int currentShip = 1;
    private int previousShip = 1;
    private int nextShip = 1;    
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
        ShipName.text = shipSkinNames[currentShip];
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