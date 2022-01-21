using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHider : MonoBehaviour
{
    [SerializeField]
    GameObject targetPanel;
    [SerializeField]
    GameObject targetPosition;

    [SerializeField]
    float animationDuration = 1f;
    [SerializeField]
    Ease easeIn = Ease.Linear;
    [SerializeField]
    Ease easeOut = Ease.Linear;

    bool toggled = false;

    Tween myTween;

    Vector3 targetOrigin;
    private void Awake()
    {
        if(targetPanel!=null)
        {
            targetOrigin = targetPanel.transform.localPosition;
        }
        else
        {
            Debug.LogWarning("No target panel identified for panel hider!");
        }
    }
    public void Toggle()
    {
        Debug.Log("Toggling panel");
        if (myTween != null)
        {
            myTween.Kill();
        }
        if (!toggled)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    void Open()
    {
        Debug.Log("Opening panel");
        toggled = true;
        targetPanel.SetActive(true);
        myTween = targetPanel.transform.DOLocalMoveX(targetPosition.transform.localPosition.x, animationDuration);
        myTween.SetEase(easeIn);
        myTween.Play();
    }

    void Close()
    {
        Debug.Log("Closing panel");
        toggled = false;
        myTween = targetPanel.transform.DOLocalMoveX(targetOrigin.x, animationDuration);
        myTween.SetEase(easeOut);
        myTween.OnComplete(() => targetPanel.SetActive(false));
        myTween.Play();
    }
}
