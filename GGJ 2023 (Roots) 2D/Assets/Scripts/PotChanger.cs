using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotChanger : MonoBehaviour
{
    private int i = 0;
    public Sprite[] potSpriteArray;
    public Sprite equippedSprite;
    public GameObject buttonToBeToggled;
    
    private void Update()
    {
        if (i > 2)
        {
            i = 0;
        }
        if (i < 0)
        {
            i = 2;
        }
        gameObject.GetComponent<SpriteRenderer>().sprite = potSpriteArray[i];
        if (equippedSprite != potSpriteArray[i])
        {
            buttonToBeToggled.SetActive(true);
        }
        else
        {
            buttonToBeToggled.SetActive(false);
        }
    }

    public void EquipPot()
    {
        equippedSprite = potSpriteArray[i];
    }
    public void NextPot()
    {
        i++;
    }
    public void PreviousPot()
    {
        i--;
    }
}
