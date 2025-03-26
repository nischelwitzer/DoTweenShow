using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=7PZGWNdH-t4
// https://github.com/Noixelfer/FadeInFadeOut/blob/main/Assets/Scripts/FadingPanel.cs

public class FadingPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    private Tween fadeTween;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TestFade());
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

    private IEnumerator TestFade()
    {
        yield return new WaitForSeconds(2.5f);
        FadeOut(2f);
        yield return new WaitForSeconds(2.5f);
        FadeIn(2f);
        StartCoroutine(TestFade());
    }
}