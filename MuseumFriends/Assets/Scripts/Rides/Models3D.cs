using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Models3D : MonoBehaviour
{
    public BuyRides buyrides;
    public GameObject child;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(buyrides.bought == true)
        {
            child.SetActive(true);
        }
        else
        {
            child.SetActive(false);
        }
    }
}
