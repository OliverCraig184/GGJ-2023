using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class InGamePotSpriteChanger : MonoBehaviour
{
    public GameObject customizablePlantObject;
    private void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = customizablePlantObject.GetComponent<PotChanger>().equippedSprite;
    }
    
}
