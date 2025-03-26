using UnityEngine;
using DG.Tweening;
using UnityEngine.InputSystem;

public class DTSequence : MonoBehaviour
{
    private TweenParams tParms;

    private Sequence mySequence;
    private Tweener mySTweenerTransform;
    private Tweener mySTweenerRotate;
    private Tweener mySTweenerColor;

    private SpriteRenderer spriteRenderer;
    private int cnt = 0;

    void Start()
    {
        DOTween.Init();

        spriteRenderer = GetComponent<SpriteRenderer>();

        // LoopType Restart Yoyo Incremental
        // Ease https://easings.net/
        tParms = new TweenParams().SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InBounce).SetDelay(1);

        // Sequence Definition
        mySTweenerTransform = transform.DOScale(new Vector3(2, 2, 2), 1.75f)
            .SetEase(Ease.InBounce) // Animationseffekt setzen
            .OnStepComplete(() => Debug.Log("DMTEffect STween step complete! "))
            .OnComplete(() => Debug.Log("DMTEffect STween beendet! ")); 

        mySTweenerRotate = transform.DORotate(new Vector3(0, 0, 180), 1.75f)
           .SetEase(Ease.Linear);

        mySTweenerColor = spriteRenderer.DOFade(0.01f, 2.75f) // oder DOColor(Color.red, 0.5f)
           .SetEase(Ease.Linear);

        mySequence = DOTween.Sequence();
        mySequence.AppendInterval(1f);
        mySequence.Append(mySTweenerTransform);
        mySequence.Append(mySTweenerRotate);
        mySequence.Append(transform.DORotate(new Vector3(0, 180, 359), 1.75f).SetEase(Ease.Linear));
        mySequence.Append(mySTweenerColor);
        mySequence.PrependInterval(1.5f);
        mySequence.AppendInterval(2f);
        mySequence.OnStepComplete(() => Debug.Log("DMTEffect Sequence complete! " + cnt++));
        mySequence.SetLoops(-1, LoopType.Restart); // Endlos wiederholen
        mySequence.Pause();

        Debug.Log("##### Effect Start " + this.transform.position);
        Invoke("StartEffect", 1f);
    }

    void StartEffect()
    {
        mySequence.Play();
    }
}
