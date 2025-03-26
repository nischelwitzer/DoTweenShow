using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class DMTEffect : MonoBehaviour
{
    private TweenParams tParms;
    private Tweener myTweenerTransform;
    private Tweener myTweenerRotate;
    private Tweener myTweenerColor;

    private SpriteRenderer spriteRenderer;
    private int cnt = 0;

    void Start()
    {
        DOTween.Init();

        spriteRenderer = GetComponent<SpriteRenderer>();

        // LoopType Restart Yoyo Incremental
        // Ease https://easings.net/
        tParms = new TweenParams().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InBounce).SetDelay(1);

        myTweenerColor = spriteRenderer.DOFade(0.01f, 1.75f) // oder DOColor(Color.red, 0.5f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.Linear);

        myTweenerTransform = transform.DOScale(new Vector3(2, 2, 2), 1.75f)
            .SetEase(Ease.InBounce) // Animationseffekt setzen
            .SetLoops(-1, LoopType.Yoyo) // 2 Mal vor und zurück spielen
            .OnStepComplete(() => Debug.Log("DMTEffect Tween step complete! " + cnt++))
            .OnComplete(() => Debug.Log("DMTEffect Tween beendet! ")); // wird nie erreicht

        myTweenerRotate = transform.DORotate(new Vector3(0, 0, 180), 1.75f)
           .SetEase(Ease.Linear) // Animationseffekt setzen
           .SetLoops(-1, LoopType.Yoyo); // wird nie erreicht

        Debug.Log("##### Effect Start " + this.transform.position);
        Invoke("StartEffect", 5f);
    }

    void StartEffect()
    {
        // myTweenerTransform.Pause(); // .IsPlaying() Pause Play Kill
        myTweenerRotate.Pause();
        // myTweenerColor.Pause();

        // spriteRenderer.SetAs(sParams);
    }
}
