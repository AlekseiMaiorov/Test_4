using System;
using DG.Tweening;
using Intarfaces;
using UnityEngine;

namespace Card
{
    public sealed class CardAnimations: ICardAnimations
    {
        public void Move(RectTransform currentRectTransform, RectTransform target, Action callback)
        {
            currentRectTransform.DOAnchorPos(target.anchoredPosition, 0.3f)
                                .SetEase(Ease.InOutQuad)
                                .OnComplete(() => callback?.Invoke());
        }

        public void Shake(RectTransform rectTransform)
        {
            rectTransform.DOShakeAnchorPos(0.5f, new Vector2(10f, 10f))
                         .SetEase(Ease.InOutQuad);
        }
    }
}