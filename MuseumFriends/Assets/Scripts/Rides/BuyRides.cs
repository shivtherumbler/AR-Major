using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyRides : MonoBehaviour
{
    //public GameObject[] rides;
    public float money;
    public float ridecost;
    public bool bought;
    public Text moneytext;
    public GameObject enoughmoney;
    public OpenClose moneybank;
    public float upgradeamount;
    public MoneyManager level;
    public string objectname;

    public bool increaselevel;
    

    //public GameObject prefab;
    //public RidesScriptable[] rideData;
    // Start is called before the first frame update
    void Start()
    {
        /*for(int i = 0; i <rideData.Length; i++)
        {
            prefab = Instantiate(rides, transform);
            prefab.name = rideData[i].name;
            prefab.transform.GetChild(0).GetComponent<Image>().sprite = rideData[i].icon;
            prefab.transform.GetChild(1).GetComponent<Text>().text = rideData[i].name;
        }*/
        objectname = gameObject.transform.parent.name;
        bought = PlayerPrefs.GetInt(objectname) != 0;
    }

    // Update is called once per frame
    void Update()
    {
        objectname = gameObject.transform.parent.name;
        money = moneybank.moneyearned;
        moneytext.text = "$" + ridecost;
        if (bought == true)
        {
            GetComponent<Button>().interactable = false;
            moneytext.text = "Owned";
            if(increaselevel == false)
            {
                level.levelno += upgradeamount;
                increaselevel = true;
            }

        }
        if(enoughmoney.activeInHierarchy)
        {
            if(money > ridecost)
            {
                enoughmoney.SetActive(false);
            }
        }

        if(moneybank.deleteprefs == true)
        {
            PlayerPrefs.DeleteKey(objectname);
        }

        int value;

        value = bought ? 1 : 0;

        if(bought == true)
        {
            value = 1;
        }
        else
        {
            value = 0;
        }

        PlayerPrefs.SetInt(objectname, (bought ? 1 : 0));
    }

    public void Buy()
    {
        if(money >= ridecost)
        {
            bought = true;
            moneybank.moneyearned = moneybank.moneyearned - ridecost;
            enoughmoney.SetActive(false);
        }
        else
        {
            enoughmoney.SetActive(true);
        }
    }

}
