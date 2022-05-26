using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChangeImage : MonoBehaviour
{
    public GameObject objectToRotate;
    public Sprite[] monica;
    public int photono = 0;
    public bool imagechanged;
    public float pulseDuration = 8f;
    public float maxsize;
    public float minsize;
    //private Tween fadeTween;
    private Tween zoomTween;
    bool increase;

    // Start is called before the first frame update
    void Start()
    {
        //fadeTween = objectToRotate.GetComponent<Image>().material.DOFade(0, pulseDuration).SetLoops(-1, LoopType.Restart);
        zoomTween = objectToRotate.transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), pulseDuration).SetLoops(-1, LoopType.Restart);
    }

    // Update is called once per frame
    void Update()
    {
        //float tempScale = Mathf.Clamp(objectToRotate.transform.localScale.x, minsize, maxsize);

        //objectToRotate.transform.localScale = (Vector3.one) * tempScale;
        Monica();
    }

    public void Monica()
    {
        if (objectToRotate.transform.localScale == new Vector3(1.3f, 1.3f, 1.3f))
        {
            if (photono < monica.Length)
            {
                //photono = Random.Range(0, 3);
                if (!increase)
                {
                    increase = true;
                    StartCoroutine(NextImage());
                }
                objectToRotate.GetComponent<Image>().sprite = monica[photono];
                
            }
            else
            {
                photono = 0;
            }
        }
    }

    IEnumerator NextImage()
    {
        yield return new WaitForSeconds(1f);
        //photono = Random.Range(0, monica.Length);
        photono++;
        increase = false;
    }
}
