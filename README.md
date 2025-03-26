# DoTweenShow

Easy and flexible Animation Framework for C#/Unity.

## DoTween Download

* Website: https://dotween.demigiant.com/
* Download: https://dotween.demigiant.com/download.php
* [Asset Store Download](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676?srsltid=AfmBOorXRxugKiRzbLOT3d9xsTfoTs6TSaum2Oz47m6NgQAi4IBZuX-_)

```
myTweenerTransform = transform.DOScale(new Vector3(2, 2, 2), 1.75f)
  .SetEase(Ease.InBounce) // Animationseffekt setzen
  .SetLoops(-1, LoopType.Yoyo) // 2 Mal vor und zurück spielen
  .OnStepComplete(() => Debug.Log("DMTEffect Tween step complete! " + cnt++))
  .OnComplete(() => Debug.Log("DMTEffect Tween beendet! ")); // wird nie erreicht
```

## C# Infos

![Working Image (Sprite)](pic/smiley.png)

* Change the PNG Image in a Sprite (2D, Single)
* Animation Curves: https://easings.net/
