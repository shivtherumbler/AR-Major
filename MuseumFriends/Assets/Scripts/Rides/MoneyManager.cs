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
        levelno = PlayerPrefs.GetFloat("totalmoney", levelno);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("totalmoney", levelno);
        earningamount = levelno;

        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            manager.moneyearned += earningamount;
        }

        if (manager.deleteprefs == true)
        {
            PlayerPrefs.DeleteKey("totalmoney");
        }
    }
}
