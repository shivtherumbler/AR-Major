using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMove : MonoBehaviour {

    //inside class
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    public GameObject[] tabs;
    public int swipelimit;
    public bool change;
    public Text category;

    private void Update()
    {
        TouchSwipe();
        MouseSwipe();

        //Screen.orientation = ScreenOrientation.Landscape;

        if (swipelimit < 4)
        {
            category.text = "The One where they hang out";
        }
        else if (swipelimit >= 4 && swipelimit < 9)
        {
            category.text = "The One with the memories";
        }
        else
        {
            category.text = "The One with the Moments";
        }
    }

    public void TouchSwipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    if(swipelimit < 21)
                    {
                        for (int i = 0; i < tabs.Length; i++)
                        {
                            tabs[i].transform.position = new Vector3(tabs[i].transform.position.x - 1120, tabs[i].transform.position.y, tabs[i].transform.position.z);
                            //tabs[i].transform.position = Vector3.Lerp(new Vector3(tabs[i].transform.position.x, tabs[i].transform.position.y, tabs[i].transform.position.z), new Vector3(tabs[i].transform.position.x - 1125, tabs[i].transform.position.y, tabs[i].transform.position.z), 1f);
                            if (!change)
                            {
                                change = true;
                                StartCoroutine(NextImage());
                            }

                        }
                    }
                    
                    Debug.Log("left swipe");
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    if (swipelimit > 0)
                    {
                        for (int i = 0; i < tabs.Length; i++)
                        {
                            tabs[i].transform.position = new Vector3(tabs[i].transform.position.x + 1120, tabs[i].transform.position.y, tabs[i].transform.position.z);
                            //tabs[i].transform.position = Vector3.Lerp(new Vector3(tabs[i].transform.position.x, tabs[i].transform.position.y, tabs[i].transform.position.z), new Vector3(tabs[i].transform.position.x + 1125, tabs[i].transform.position.y, tabs[i].transform.position.z), 1f);
                            if (!change)
                            {
                                change = true;
                                StartCoroutine(PrevImage());
                            }

                        }
                    }
                        
                    Debug.Log("right swipe");
                }
            }
        }

    }

    public void MouseSwipe()
    {


        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
                Debug.Log("up swipe");
            }
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
        {
                Debug.Log("down swipe");
            }
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
                if (swipelimit < 21)
                {
                    for (int i = 0; i < tabs.Length; i++)
                    {
                        tabs[i].transform.position = new Vector3(tabs[i].transform.position.x - 1120, tabs[i].transform.position.y, tabs[i].transform.position.z);
                        //tabs[i].transform.position = Vector3.Lerp(new Vector3(tabs[i].transform.position.x, tabs[i].transform.position.y, tabs[i].transform.position.z), new Vector3(tabs[i].transform.position.x - 1125, tabs[i].transform.position.y, tabs[i].transform.position.z), 1f);
                        if (!change)
                        {
                            change = true;
                            StartCoroutine(NextImage());
                        }
                        
                    }
                }
                    
                Debug.Log("left swipe");
                
            }
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
        {
                if(swipelimit > 0)
                {
                    for (int i = 0; i < tabs.Length; i++)
                    {
                        tabs[i].transform.position = new Vector3(tabs[i].transform.position.x + 1120, tabs[i].transform.position.y, tabs[i].transform.position.z);
                        //tabs[i].transform.position = Vector3.Lerp(new Vector3(tabs[i].transform.position.x, tabs[i].transform.position.y, tabs[i].transform.position.z), new Vector3(tabs[i].transform.position.x + 1125, tabs[i].transform.position.y, tabs[i].transform.position.z), 1f);
                        if (!change)
                        {
                            change = true;
                            StartCoroutine(PrevImage());
                        }
                            
                    }
                }
                
                Debug.Log("right swipe");
            }
        }
    }

    IEnumerator NextImage()
    {
        yield return new WaitForSeconds(0.1f);
        //photono = Random.Range(0, monica.Length);
        swipelimit++;
        change = false;
    }

    IEnumerator PrevImage()
    {
        yield return new WaitForSeconds(0.1f);
        swipelimit--;
        change = false;
    }
}

