using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SliderMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject target;
    public GameObject[] models;
    public GameObject stop;
    public GameObject[] uielements;
    private bool _isDragging = false;
    private float rotationRate = 0.15f;
    public Slider[] slider;
    public bool stoprotation;

    private Vector3 prevPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            stoprotation = true;
        }
        else
        {
            stoprotation = false;
        }

            if (stoprotation == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                prevPos = cam.ScreenToViewportPoint(Input.mousePosition);
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
                Vector3 direction = prevPos - newPosition;

                float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
                float rotationAroundXAxis = direction.y * 180; // camera moves vertically

                cam.transform.position = target.transform.position;

                cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

                cam.transform.Translate(new Vector3(0, 0, -1.2f));

                prevPos = newPosition;
            }

            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                _isDragging = true;
            }


            if (_isDragging && target != null)
            {
                if (Input.touchCount == 1)
                {
                    foreach (Touch touch in Input.touches)
                    {
                        // Debug.Log("Touching at: " + touch.position);

                        if (touch.phase == TouchPhase.Began)
                        {
                            // Debug.Log("Touch phase began at: " + touch.position);
                        }
                        else if (touch.phase == TouchPhase.Moved)
                        {
                            // Debug.Log("Touch phase Moved");
                            //cam.transform.Rotate(0,
                            // -touch.deltaPosition.x * rotationRate, 0, Space.World);

                            //cam.transform.Rotate(
                            //-touch.deltaPosition.y * rotationRate, 0, 0, Space.Self);
                            //
                            Vector3 newPosition = cam.ScreenToViewportPoint(Input.GetTouch(0).position);
                            Vector3 direction = prevPos - newPosition;

                            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
                            float rotationAroundXAxis = direction.y * 180; // camera moves vertically

                            cam.transform.position = target.transform.position;

                            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
                            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); // <— This is what makes it work!

                            cam.transform.Translate(new Vector3(0, 0, -1.2f));

                            prevPos = newPosition;
                        }


                        else if (touch.phase == TouchPhase.Ended)
                        {
                            // Debug.Log("Touch phase Ended");
                            _isDragging = false;
                        }
                    }
                }
            }
        }
       
    }

    public void TurnOnModels(int n)
    {
        target = models[n];
        target.SetActive(true);
        stop.SetActive(true);
        for(int i = 0; i < uielements.Length; i++)
        {
            uielements[i].SetActive(false);
        }
    }

    public void TurnOffModels(int n)
    { 
        target.SetActive(false);
        stop.SetActive(false);

        for (int i = 0; i < uielements.Length; i++)
        {
            uielements[i].SetActive(true);
        }
    }

    public void Rotate(float rotate)
    {
        target.transform.rotation = Quaternion.Euler(target.transform.rotation.eulerAngles.x, rotate, target.transform.rotation.eulerAngles.z); 
    }

    public void DontRotate(float value)
    {
        stoprotation = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
