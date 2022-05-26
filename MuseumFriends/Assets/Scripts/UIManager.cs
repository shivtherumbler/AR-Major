using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class UIManager : MonoBehaviour
{
    public ARSessionManager _arSessionManager;
    public Pulse startScreenEffect;

    public RectTransform[] startARButton;
    public RectTransform stopARButton;
    public RectTransform messagePanel;
    public TMP_Text messageText;
    public GameObject[] uielements;

    public GameObject[] cam;
    public GameObject[] slider;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        for (int i = 0; i < startARButton.Length; i++)
        {
            startARButton[i].gameObject.SetActive(true);
        }
        stopARButton.gameObject.SetActive(false);
        messagePanel.gameObject.SetActive(false);
        startScreenEffect.StartPulse();
    }
    public void ShowMessage(string message)
    {
        messagePanel.gameObject.SetActive(true);
        messageText.text = message;
        Invoke(nameof(DisableMessage), 2f);
    }

    private void DisableMessage()
    {
        messagePanel.gameObject.SetActive(false);
    }

    public void StopAR()
    {
        cam[1].SetActive(true);
        cam[0].SetActive(false);
        _arSessionManager.StopAR();
        for (int i = 0; i < startARButton.Length; i++)
        {
            startARButton[i].gameObject.SetActive(true);

        }
        for (int i = 0; i < uielements.Length; i++)
        {
            uielements[i].SetActive(true);
        }
        stopARButton.gameObject.SetActive(false);
        startScreenEffect.StartPulse();
        ShowMessage("AR Stopped");
        Screen.orientation = ScreenOrientation.LandscapeRight;
    }

    public void StartAR()
    {
        cam[0].SetActive(true);
        cam[1].SetActive(false);
        if (_arSessionManager.StartAR())
        {
            for (int i = 0; i < startARButton.Length; i++)
            {
                startARButton[i].gameObject.SetActive(false);

            }
            for (int i = 0; i < uielements.Length; i++)
            {
                uielements[i].SetActive(false);
            }
            stopARButton.gameObject.SetActive(true);
            startScreenEffect.StopPulse();
            ShowMessage("AR Started");
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }

    public void Start3D()
    {

        cam[1].GetComponent<Camera>().clearFlags = CameraClearFlags.Skybox;
        for(int i = 0; i < slider.Length; i++)
        {
            slider[i].SetActive(true);
        }
    }

    public void Stop3D()
    {
        //Screen.orientation = ScreenOrientation.Landscape;
        cam[1].GetComponent<Camera>().clearFlags = CameraClearFlags.SolidColor;

        for (int i = 0; i < slider.Length; i++)
        {
            slider[i].SetActive(false);
        }
    }

    public void Zoom(float zoomvalue)
    {
        cam[1].GetComponent<Camera>().fieldOfView = zoomvalue; 
    }
}
