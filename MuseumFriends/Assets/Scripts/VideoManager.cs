using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public SwipeMove swipeMove;
    public Animator anim;
    public bool size;
    public int num;
    public GameObject image;

    // Start is called before the first frame update
    void Start()
    {

    }

    [SerializeField]
    private VideoPlayer videoPlayer;

    [SerializeField]
    private Image progress;

    private void Awake()
    {
        progress = GetComponent<Image>();
    }

    private void Update()
    {
        if (swipeMove.swipelimit != num)
        {
            videoPlayer.Pause();
            
        }
        if (videoPlayer.frameCount > 0)
            progress.fillAmount = (float)videoPlayer.frame / (float)videoPlayer.frameCount;
    }

    public void OnDrag(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TrySkip(eventData);
    }

    private void TrySkip(PointerEventData eventData)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(progress.rectTransform, eventData.position, null, out localPoint))
        {
            float pct = Mathf.InverseLerp(progress.rectTransform.rect.xMin, progress.rectTransform.rect.xMax, localPoint.x);
            SkipToPercent(pct);
        }
    }

    private void SkipToPercent(float pct)
    {
        var frame = videoPlayer.frameCount * pct;
        videoPlayer.frame = (long)frame;
    }

    public void FullScreen()
    {

        size = !size;

        if (size)
        {
            anim.SetBool("Increase", true);
            anim.SetBool("Decrease", false);
            image.SetActive(false);
        }
        else
        {
            anim.SetBool("Decrease", true);
            anim.SetBool("Increase", false);
            image.SetActive(true);
        }
    }
}
