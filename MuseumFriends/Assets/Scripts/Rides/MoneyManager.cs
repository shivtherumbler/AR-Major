using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float levelno;
    public OpenClose manager;

    public float Timer;
    public int DelayAmount = 1;
    public float earningamount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        earningamount = levelno;

        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            manager.moneyearned += earningamount;
        }
    }
}
