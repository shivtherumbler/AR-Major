using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenClose : MonoBehaviour
{
    public float moneyearned = 0;
    public Text money;
    public InputField usernameInput;
    public Text username;
    public GameObject name;
    public GameObject cam;

    public GameObject horizontalList;
    public GameObject verticalList;

    public GameObject[] horizontaltabs;
    public GameObject[] verticaltabs;

    public GameObject settingsvertical;
    public GameObject settingshorizontal;

    public bool deleteprefs;

    // Start is called before the first frame update
    void Start()
    {
        moneyearned = PlayerPrefs.GetFloat("amount", moneyearned);
        username.text = PlayerPrefs.GetString("name", username.text);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("amount", moneyearned);
        PlayerPrefs.SetString("name", username.text);
        money.text = "$" + moneyearned;

        /*if (Screen.orientation == ScreenOrientation.Landscape)
        {
            if(verticalList.activeInHierarchy)
            {
                verticalList.SetActive(false);
                horizontalList.SetActive(true);
            }
            for(int i=0; i< verticaltabs.Length;i++)
            {
                if(verticaltabs[i].activeInHierarchy)
                {
                    verticaltabs[i].SetActive(false);
                    horizontaltabs[i].SetActive(true);
                }
            }
            if(settingsvertical.activeInHierarchy)
            {
                settingsvertical.SetActive(false);
                settingshorizontal.SetActive(true);
            }
        }
        else if (Screen.orientation == ScreenOrientation.Portrait)
            {
                if (horizontalList.activeInHierarchy)
                {
                    horizontalList.SetActive(false);
                    verticalList.SetActive(true);
                }

            for (int i = 0; i < horizontaltabs.Length; i++)
            {
                if (horizontaltabs[i].activeInHierarchy)
                {
                    horizontaltabs[i].SetActive(false);
                    verticaltabs[i].SetActive(true);
                }
            }
            if (settingshorizontal.activeInHierarchy)
            {
                settingshorizontal.SetActive(false);
                settingsvertical.SetActive(true);
            }
        }*/

        if (deleteprefs == true)
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.DeleteKey("amount");
            PlayerPrefs.DeleteKey("name");
        }

        //username.text = usernameInput.text;

        /*if (username.text == "")
        {
            name.SetActive(true);
        }
        else
        {
            name.SetActive(false);
        }*/

    }

    public void Open(GameObject open)
    {
        open.SetActive(true);
    }

    public void Close(GameObject close)
    {
        close.SetActive(false);
    }

    public void SubmitName()
    {
        username.text = usernameInput.text;
        //PlayerPrefs.Save();
    }

    public void ResetProgress()
    {
        deleteprefs = true;
        SceneManager.LoadScene("RidesMenu");
    }

    public void CloseAll()
    {
        for(int i = 0; i < verticaltabs.Length; i++)
        {
            verticaltabs[i].SetActive(false);
        }
    }
}
