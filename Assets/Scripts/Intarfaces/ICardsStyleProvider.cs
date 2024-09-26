using Card;
using Enums;
using UnityEngine;

namespace Intarfaces
{
    public interface ICardsStyleProvider
    {
        public Sprite CardBack { get; }
        public Sprite GetFrontSprite(CardValue cardValue);
    }
}