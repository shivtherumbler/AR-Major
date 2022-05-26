using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnOnSurface : MonoBehaviour
{
    public ARRaycastManager RaycastManager;
    public GameObject objectPrefab;

    public int num;
    private GameObject _spawnedGameObject;
    public GameObject reticlePrefab;
    private GameObject reticle;
    public ARSessionManager manager;
    public GameObject[] ComponentPrefab;
    public GameObject[] SpawnedComponent;
    /*
    // Start is called before the first frame update
    void Start()
    {
        reticle = Instantiate(reticlePrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(_spawnedGameObject == null)
        {
            Vector2 screenPoint = Camera.main.ViewportToScreenPoint(new Vector2(0.5f, 0.5f));

            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            RaycastManager.Raycast(/*Input.GetTouch(index: 0).position*/ /*screenPoint, hits, TrackableType.Planes);

            if (hits.Count > 0)
            {
                reticle.gameObject.SetActive(true);
                reticle.transform.position = hits[0].pose.position;
                //hits[0].pose.up

                reticle.transform.rotation = hits[0].pose.rotation;
            }
            else
            {
                reticle.gameObject.SetActive(false);
            }    

            
        }

        if (Input.touchCount > 0 && Input.GetTouch(index: 0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();

            RaycastManager.Raycast(Input.GetTouch(index: 0).position, hits, TrackableType.Planes);

            if(hits.Count > 0)
            {
                if (_spawnedGameObject == null)
                {
                    _spawnedGameObject = Instantiate(original: objectPrefab, hits[0].pose.position, hits[0].pose.rotation);
                    reticle.SetActive(false);
                }
                else
                {
                    _spawnedGameObject.transform.position = hits[0].pose.position;
                }
            }
        }
    }*/
    /*public GameObject[] ComponentPrefab;
    public GameObject[] SpawnedComponent;
    public ARSessionManager manager;
    private ARPlaneManager PlaneManager;
    void Start()
    {
        PlaneManager = GetComponent<ARPlaneManager>();
        for(int i = 0; i < ComponentPrefab.Length; i++)
        {
            SpawnedComponent[i] = Instantiate(ComponentPrefab[i], transform);
        }
        //SpawnedComponent.transform.parent = transform;
    }
    void Update()
    {
        if(manager._arSession.enabled == false)
        {
            for (int i = 0; i < ComponentPrefab.Length; i++)
            {
                SpawnedComponent[i].SetActive(false);
            }

        }

        for (int i = 0; i < ComponentPrefab.Length; i++)
        {
            SpawnedComponent[i].transform.position = PlaneManager.planePrefab.transform.position;
        }
    }*/

    private void Start()
    {
        /*for (int i = 0; i < ComponentPrefab.Length; i++)
        {
            SpawnedComponent[i] = Instantiate(ComponentPrefab[i], transform);
        }*/
        reticle = Instantiate(reticlePrefab, transform);
    }

    private void Update()
    {
        /*if (manager._arSession.enabled == false)
        {
            for (int i = 0; i < ComponentPrefab.Length; i++)
            {
                objectPrefab.SetActive(false);
            }


        }*/
        //else
        //{
            TryPlaceObject();
        //}
    }
    private void TryPlaceObject()
    {
       
        if (_spawnedGameObject == null)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                //Instantiate(num);
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                RaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes);
                if (hits.Count == 1)
                {
                    _spawnedGameObject = Instantiate(objectPrefab, hits[0].pose.position /*+ (Vector3.forward * 500)*/, hits[0].pose.rotation);
                    Debug.Log("Object Created");
                    reticle.SetActive(false);
                }
                if (hits.Count > 0)
                {
                    reticle.gameObject.SetActive(true);
                    reticle.transform.position = hits[0].pose.position;
                    //hits[0].pose.up

                    reticle.transform.rotation = hits[0].pose.rotation;
                }
                else
                {
                    reticle.gameObject.SetActive(false);
                }

            }


        }
        else if (_spawnedGameObject != null)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                List<ARRaycastHit> hits = new List<ARRaycastHit>();
                RaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.Planes);
                if (hits.Count == 1)
                {
                    _spawnedGameObject.transform.position = hits[0].pose.position /*+ (Vector3.forward * 500)*/;
                }
            }
        }
    }

    public void Instantiate(int i)
    {
        /*if (manager._arSession.enabled == true)
        {
        
            SpawnedComponent[i].SetActive(true);

        }*/
        num = i;
        
    }
}
