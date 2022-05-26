using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pulse : MonoBehaviour
{
    public MeshRenderer pulseMesh;
    public float pulseDuration = 1f;

    private Tween fadeTween;
    private Tween zoomTween;

    private void Awake()
    {
        pulseMesh.transform.localScale = Vector3.zero;
        pulseMesh.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        fadeTween = pulseMesh.material.DOFade(0, pulseDuration).SetLoops(-1, LoopType.Restart);
        zoomTween = pulseMesh.transform.DOScale(new Vector3(5f, 5f, 5f), pulseDuration).SetLoops(-1, LoopType.Restart);
        
    }

    public void StartPulse()
    {
        pulseMesh.enabled = true;
        //fadeTween = pulseMesh.transform.DOScale(0, 1).SetLoops(-1, LoopType.Yoyo);
        fadeTween.Restart();
        zoomTween.Restart();
    }

    public void StopPulse()
    {
        pulseMesh.enabled = false;
        fadeTween.Pause();
        zoomTween.Pause();
    }
}
