using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARSession))]
public class ARSessionManager : MonoBehaviour
{

    //public UIManager uiManager;
    public ARTaptoPlaceObject manager;
    public ARSession _arSession;

    private void Awake()
    {
        _arSession = GetComponent<ARSession>();
        _arSession.enabled = false;
    }

    public bool StartAR()
    {
        if (ARSession.state == ARSessionState.Unsupported)
        {
            manager.ShowMessage("Device Not Supported");
        }
        else if (ARSession.state == ARSessionState.None || ARSession.state == ARSessionState.Ready || ARSession.state == ARSessionState.SessionTracking)
        {
            _arSession.enabled = true;
            return true;
        }
        return false;
    }

    public void StopAR()
    {
        _arSession.enabled = false;
    }    
}
