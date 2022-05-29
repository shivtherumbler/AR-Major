using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;
using UnityEngine.XR.ARSubsystems;
using TMPro;

public class ARTaptoPlaceObject : MonoBehaviour
{
    public ARSessionManager _arSessionManager;
    public Pulse startScreenEffect;

    public RectTransform[] startARButton;
    public RectTransform stopARButton;
    public RectTransform messagePanel;
    public TMP_Text messageText;
    public GameObject[] uielements;
    public GameObject[] arelements;

    public GameObject[] cam;

    private void Start()
    {
        //Screen.orientation = ScreenOrientation.LandscapeRight;
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
            for (int i = 0; i < arelements.Length; i++)
            {
                arelements[i].SetActive(false);
            }
            stopARButton.gameObject.SetActive(true);
            startScreenEffect.StopPulse();
            ShowMessage("AR Started");
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }

    public void StartVR(int camno)
    {
        cam[camno].SetActive(true);
        cam[1].SetActive(false);
        for (int i = 0; i < uielements.Length; i++)
        {
            uielements[i].SetActive(false);
        }
        //stopARButton.gameObject.SetActive(true);
        startScreenEffect.StopPulse();
        ShowMessage("VR Started");
        Screen.orientation = ScreenOrientation.AutoRotation;
        
    }

    public void StopVR(int camno)
    {
        cam[1].SetActive(true);
        cam[camno].SetActive(false);
        for (int i = 0; i < uielements.Length; i++)
        {
            uielements[i].SetActive(true);
        }
        //stopARButton.gameObject.SetActive(false);
        startScreenEffect.StartPulse();
        ShowMessage("VR Stopped");
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
        for (int i = 0; i < arelements.Length; i++)
        {
            arelements[i].SetActive(true);
        }
        stopARButton.gameObject.SetActive(false);
        startScreenEffect.StartPulse();
        ShowMessage("AR Stopped");
        
    }

}