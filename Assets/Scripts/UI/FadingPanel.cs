using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FadingPanel : MonoBehaviour
{

    [SerializeField] private CanvasGroup canvasGroup;
    private Tween fadeTween;


    private void Start()
    {
        StartCoroutine(DoAFadeOut());
    }

    public void FadeIn(float duration)
    {
        Fade(1f, duration, () =>
        {
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        });
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () =>
        {
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {

        if (fadeTween != null)
        {
            fadeTween.Kill(false);
        }

        fadeTween = canvasGroup.DOFade(endValue, duration);
        fadeTween.onComplete += onEnd;

    }

    public IEnumerator DoAFadeIn()
    {
        FadeIn(1f);
        yield return new WaitForSeconds(1f);
    }
    
    public IEnumerator DoAFadeOut()
    {
        yield return new WaitForSeconds(1f);
        FadeOut(1f);
    }
}
