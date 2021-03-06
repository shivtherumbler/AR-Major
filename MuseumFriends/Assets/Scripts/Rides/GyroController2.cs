using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GyroController2 : MonoBehaviour
{
    void Start()
    {
        Input.gyro.enabled = true;
    }

    void Update() 
    { 
        transform.Rotate(-Input.gyro.rotationRateUnbiased.x, -Input.gyro.rotationRateUnbiased.y, 0); 
    }
}