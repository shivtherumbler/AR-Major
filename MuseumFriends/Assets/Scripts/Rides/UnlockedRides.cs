using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedRides : MonoBehaviour
{
    public GameObject[] rides;
    public GameObject[] ridemodels;
    public List<GameObject> gameObjects;
    [Range(0, 10)]
    public int currenttab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       for(int j = 0; j <rides.Length; j++)
        {
            if(rides[j].GetComponent<BuyRides>().bought == true)
            {
                if(!gameObjects.Contains(ridemodels[j]))
                {
                    gameObjects.Add(ridemodels[j]);

                }
            }
        }
        gameObjects[currenttab].SetActive(true);
        for(int i = 0; i < gameObjects.Count; i++)
        {
            if(i != currenttab)
            {
                gameObjects[i].SetActive(false);
            }
        }
    }

    public void Left()
    {
        if(currenttab > 0)
        {
            currenttab--;
        }
        gameObjects[currenttab + 1].SetActive(false);
        gameObjects[currenttab].SetActive(true);
        

    }

    public void Right()
    {
        if(currenttab < 10)
        {
            currenttab++;

        }
        gameObjects[currenttab - 1].SetActive(false);
        gameObjects[currenttab].SetActive(true);
        
    }
}
