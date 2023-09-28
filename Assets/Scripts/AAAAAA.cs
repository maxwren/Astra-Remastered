using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AAAAAA : MonoBehaviour
{
    [SerializeField] Sprite player_skin_01;
    [SerializeField] Sprite player_skin_02;
    [SerializeField] Sprite player_skin_03;
    [SerializeField] Sprite player_skin_04;
    [SerializeField] Sprite player_skin_05;

    [SerializeField] GameObject ShipSprite;
    [SerializeField] GameObject ShipSpritePrev;
    [SerializeField] GameObject ShipSpriteNext;

    [SerializeField] TextMeshProUGUI ShipName;

    Dictionary<Sprite, int> skin_names = new Dictionary<Sprite, int>();

    public static int currentShip = 1;
    public static int previousShip = 1;
    public static int nextShip = 1;

    int[] shipSkins = { 1, 2, 3, 4, 5 };

    private void Start()
    {
        currentShip = PlayerPrefs.GetInt("player_skin");
        skin_names.Add(player_skin_01, 1);
        skin_names.Add(player_skin_02, 2);
        skin_names.Add(player_skin_03, 3);
        skin_names.Add(player_skin_04, 4);
        skin_names.Add(player_skin_05, 5);
    }

    private void Update()
    {
        previousShip = currentShip--;
        nextShip = currentShip++;

        if (currentShip < 0)
        {
            currentShip = shipSkins.Length;
        }
        if (currentShip > shipSkins.Length)
        {
            currentShip = 0;
        }

        /* Some day finish this shit whatever it is, too lazy now
        for (int i = currentShip-1; i < shipSkins.Length; i++)
        {
            if (i == currentShip)
            {
                return;
            }
            else
            {
                skin_names
            }
        }
        */

        //------------------------------------------------------------------------

        if (currentShip == 0)
        {
            ShipSprite.GetComponent<Image>().sprite = player_skin_01;
            //player_movement.Player_skin_active = 1;
            ShipName.text = "SV Scout";
        }

        if (currentShip == 1)
        {
            ShipSprite.GetComponent<Image>().sprite = player_skin_02;
            ShipName.text = "Meteorcutter";
        }

        if (currentShip == 2)
        {
            ShipSprite.GetComponent<Image>().sprite = player_skin_03;
            ShipName.text = "Jupiter 30";
        }

        if (currentShip == 3)
        {
            ShipSprite.GetComponent<Image>().sprite = player_skin_04;
            ShipName.text = "Macinspace";
        }

        if (currentShip == 4)
        {
            ShipSprite.GetComponent<Image>().sprite = player_skin_05;
            ShipName.text = "UglyShipRemakeItLater";
        }

        //------------------------------------------------------------------------

        if (previousShip == 1)
        {
            ShipSpritePrev.GetComponent<Image>().sprite = player_skin_05;
            ShipSpriteNext.GetComponent<Image>().sprite = player_skin_02;
        }
        if (previousShip == 2)
        {
            ShipSpritePrev.GetComponent<Image>().sprite = player_skin_01;
            ShipSpriteNext.GetComponent<Image>().sprite = player_skin_03;
        }
        if (previousShip == 3)
        {
            ShipSpritePrev.GetComponent<Image>().sprite = player_skin_02;
            ShipSpriteNext.GetComponent<Image>().sprite = player_skin_04;
        }
        if (previousShip == 4)
        {
            ShipSpritePrev.GetComponent<Image>().sprite = player_skin_03;
            ShipSpriteNext.GetComponent<Image>().sprite = player_skin_05;
        }
        if (previousShip == 5)
        {
            ShipSpritePrev.GetComponent<Image>().sprite = player_skin_04;
            ShipSpriteNext.GetComponent<Image>().sprite = player_skin_01;
        }
    }

    public void GoLeft()
    {
        currentShip--;
    }
    public void GoRight()
    {
        currentShip++;
    }
}
