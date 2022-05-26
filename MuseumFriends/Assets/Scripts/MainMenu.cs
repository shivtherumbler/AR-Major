using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour
{
    public GameObject[] icons;
    public float pulseDuration = 2f;
    private Tween zoomTween;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <icons.Length; i++)
        {
            zoomTween = icons[i].transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), pulseDuration).SetLoops(-1, LoopType.Yoyo);

        }
    }

    // Update is called once per frame
    void Update()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void NextScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    
    public void AlphaIncrease(Image image)
    {
        var tempColor = image.color;
        tempColor.a = 255f;
        image.color = tempColor;
        
    }

}
