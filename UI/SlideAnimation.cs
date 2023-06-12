using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideAnimation : MonoBehaviour
{

    Vector2 oldPosition;

    Vector2 targetPosition;


    [SerializeField]
    Vector2 startTarget = new Vector2(778, 0);
    [SerializeField]
    Vector2 middleTarget = Vector2.zero;
    [SerializeField]
    Vector2 endTarget = new Vector2(-786, 0);


    RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        oldPosition = rectTransform.localPosition;
        targetPosition = rectTransform.localPosition;
    }

    public void SlideIn()
    {
        progress = 0;
        oldPosition = targetPosition;
        targetPosition = middleTarget;
    }
    public void SlideOut()
    {
        progress = 0;

        oldPosition = targetPosition;
        targetPosition = endTarget;
    }

    public void SlideBackIn()
    {
        progress = 0;
        oldPosition = targetPosition;
        targetPosition = middleTarget;
    }
    public void SlideBackOut()
    {
        progress = 0;

        oldPosition = targetPosition;
        targetPosition = startTarget;
    }


    float progress = 0;

    // Update is called once per frame
    void FixedUpdate()
    {

        progress += 0.045f;
        rectTransform.localPosition = Vector2.Lerp(oldPosition, targetPosition, progress);

    }
}
