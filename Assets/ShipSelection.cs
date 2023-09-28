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

    Dictionary<Sprite, int> skin_names = new Dictionary<Sprite, int>();

    public static int currentShip = 1; //this is a shitty fix because well you have to manually rewrite the number of skins here
    public static int previousShip = 1;
    public static int nextShip = 1;

    private int currentShipTest;
    private int nextShipTest;
    private int previousShipTest;

    [SerializeField] int numberOfSkins;

    [SerializeField] Sprite[] shipSkinSprites;

    private void Start()
    {
        currentShip = PlayerPrefs.GetInt("player_skin");
    }

    private void Update()
    {
        /*
        if ((currentShipTest >= 0) && (currentShipTest < numberOfSkins))
        {
            currentShip = currentShipTest;
        }

        if ((previousShipTest >= 0) && (previousShipTest < numberOfSkins) && (previousShipTest != currentShip))
        {
            previousShip = previousShipTest;
        }

        if ((nextShipTest >= 0) && (nextShipTest < numberOfSkins) && (nextShipTest != currentShip)) //this condition isn't always met so it stops at 3
        {
            nextShip = nextShipTest;
        }
        else
        {
            nextShipTest = 0;
        }

        previousShipTest = currentShipTest - 1;
        nextShipTest = currentShipTest + 1;

        if (shipSkinSprites[currentShip] != null)
        {
            ShipSprite.GetComponent<Image>().sprite = shipSkinSprites[currentShip];
        }
        if (shipSkinSprites[previousShip] != null)
        {
            ShipSpritePrev.GetComponent<Image>().sprite = shipSkinSprites[previousShip];
        }
        if (shipSkinSprites[nextShip] != null)
        {
            ShipSpriteNext.GetComponent<Image>().sprite = shipSkinSprites[nextShip];
        }
        */

        previousShip = currentShip--;
        nextShip = currentShip++;

        ShipSprite.GetComponent<Image>().sprite = shipSkinSprites[currentShip];
        ShipSpritePrev.GetComponent<Image>().sprite = shipSkinSprites[previousShip];
        ShipSpriteNext.GetComponent<Image>().sprite = shipSkinSprites[nextShip];

        if (previousShip < 0)
        {

        }
    }

    public void GoLeft()
    {
        currentShipTest--;
        if (currentShipTest < 0)
        {
            currentShipTest = numberOfSkins;
        }
    }
    public void GoRight()
    {
        currentShipTest++;
        if (currentShipTest > numberOfSkins)
        {
            currentShipTest = 0;
        }
    }
}
