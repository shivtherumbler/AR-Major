using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ReticleManager : MonoBehaviour
{
    public ARRaycastManager raymanager;
    public Camera ARCamera;
    public ARSessionManager manager;
    public GameObject reticle;
    public GameObject[] ObjectToSpawn;
    [SerializeField]
    List<GameObject> obj;
    public int models;

    // Start is called before the first frame update
    void Start()
    {
        raymanager = FindObjectOfType<ARRaycastManager>();
        reticle = this.transform.GetChild(0).gameObject;
        reticle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        List<ARRaycastHit> hitpoint = new List<ARRaycastHit>();
        raymanager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hitpoint, TrackableType.Planes);

        if (manager._arSession.enabled == true)
        {
            if (hitpoint.Count > 0)
            {
                transform.position = hitpoint[0].pose.position;
                transform.rotation = hitpoint[0].pose.rotation;
                if (!reticle.activeInHierarchy)
                {
                    reticle.SetActive(true);
                }
            }

            if (obj[0] == null)
                {
                    reticle.SetActive(true);
                    if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                    {
                        if (hitpoint.Count == 1)
                        {
                            obj[0] = ObjectToSpawn[models];
                            obj[0] = Instantiate(ObjectToSpawn[models], reticle.transform.position, reticle.transform.rotation);
                        }

                    }
                }
            else if (obj[0] != null)
            {
                //reticle.SetActive(false);
                if (Input.touchCount > 0 && (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(0).phase == TouchPhase.Stationary))
                {
                    obj[0].SetActive(true);
                    if (hitpoint.Count == 1)
                    {
                        
                        obj[0].transform.position = reticle.transform.position;

                    }
                }

                if(Vector3.Angle(ARCamera.transform.position + ARCamera.transform.forward, ARCamera.transform.position - obj[0].transform.position) < 90)
                {
                    if (!reticle.activeInHierarchy)
                    {
                        reticle.SetActive(true);
                    }
                }
                else
                {
                    if(reticle.activeInHierarchy)
                    {
                        reticle.SetActive(false);
                    }
                }
            }
        }
        else
        {
            reticle.SetActive(false); 
            
            if (obj[0] != null)
            {
                obj[0].SetActive(false);
                obj[0] = null;

            }
        }
    }

    public void Instantiate(int n)
    {
        models = n;
    }
}
