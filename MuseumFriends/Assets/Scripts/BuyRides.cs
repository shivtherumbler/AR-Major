using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyRides : MonoBehaviour
{
    public GameObject rides;
    public GameObject prefab;
    public RidesScriptable[] rideData;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <rideData.Length; i++)
        {
            prefab = Instantiate(rides, transform);
            prefab.name = rideData[i].name;
            prefab.transform.GetChild(0).GetComponent<Image>().sprite = rideData[i].icon;
            prefab.transform.GetChild(1).GetComponent<Text>().text = rideData[i].name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
