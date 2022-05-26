using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageTrackingExample : MonoBehaviour
{
    public Camera worldCamera;
    public Texture defaultTexture;
    public ARTrackedImageManager aRTrackedImageManager;
    public GameObject ObjectToSpawn;

    private GameObject _instancedObject;

    private void Start()
    {
        worldCamera = Camera.main;
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();

    }

    private void OnEnable()
    {
        aRTrackedImageManager.trackedImagesChanged += OntrackedImagesChanged;
    }

    private void OnDisable()
    {
        aRTrackedImageManager.trackedImagesChanged -= OntrackedImagesChanged;
    }

    private void OntrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        if (eventArgs.added.Count > 0)
        {
            Debug.Log($"Images found {eventArgs.added.Count}");
        }
        else if (eventArgs.removed.Count > 0)
        {
            Debug.Log($"Images removed {eventArgs.removed.Count}");

        }
        else if (eventArgs.updated.Count > 0)
        {
            Debug.Log($"Images updated {eventArgs.updated.Count}");

        }
        else
        {
            Debug.Log("error nothing happened");
        }

        foreach(var trackedImage in eventArgs.added)
        {
            if(_instancedObject == null)
            {
                _instancedObject = Instantiate(ObjectToSpawn, trackedImage.transform);
            }
            
            trackedImage.transform.localScale = Vector3.one * 0.1f;
        }
    }
}
