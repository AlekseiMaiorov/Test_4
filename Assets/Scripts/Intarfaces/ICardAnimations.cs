using System;
using UnityEngine;

namespace Intarfaces
{
    public interface ICardAnimations
    {
        void Move(RectTransform currentRectTransform, RectTransform target, Action callback);
        void Shake(RectTransform rectTransform);
    }
}