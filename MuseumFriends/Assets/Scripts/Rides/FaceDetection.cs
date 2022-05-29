using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;

public class FaceDetection : MonoBehaviour
{
    public ARFaceManager aRFaceManager;
    public Text proceed;
    public GameObject nextscene;

    public InputField usernameInput;
    public Text username;
    public GameObject name;

    // Start is called before the first frame update
    void Start()
    {
        aRFaceManager = GetComponent<ARFaceManager>();
        aRFaceManager.facesChanged += FaceDetected;

        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void FaceDetected(ARFacesChangedEventArgs aRFaces)
    {
        if(aRFaces.added.Count == 1)
        {
            proceed.text = "Face detected! Tap to move to next screen";
            nextscene.SetActive(true);
        }

        if(aRFaces.removed.Count == 1)
        {
            proceed.text = "Scan your face to proceed!";
            nextscene.SetActive(false);
        }
    }

    public void NextScene(string scene)
    {
        //nextscene.SetActive(false);
        //gameObject.SetActive(false);

        if (username.text == "")
        {
            name.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(scene);
            name.SetActive(false);
        }
    }

}
