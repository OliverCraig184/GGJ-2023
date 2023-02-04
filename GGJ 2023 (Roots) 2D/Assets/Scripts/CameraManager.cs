using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject gameCamera;
    public GameObject customizerCamera;
    public GameObject canvas;
    public void SwitchToGameplay()
    {
        gameCamera.SetActive(true);
        customizerCamera.SetActive(false);
        canvas.SetActive(true);
    }
}
