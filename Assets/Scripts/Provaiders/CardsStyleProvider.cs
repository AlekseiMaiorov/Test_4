using Card;
using Common.Extensions;
using Enums;
using Intarfaces;
using UnityEngine;

namespace Services
{
    public class CardsStyleProvider : ICardsStyleProvider
    {
        public Sprite CardBack => _cardsStyle.CardBack;
        private readonly ICardsStyle _cardsStyle;

        public CardsStyleProvider(ICardsStyle cardsStyle)
        {
            _cardsStyle = cardsStyle;
        }

        public Sprite GetFrontSprite(CardValue cardValue)
        {
            var isRankFound = _cardsStyle.CardsSprites[cardValue.Suit].TryGetValue(cardValue.Rank, out Sprite sprite);

            if (!isRankFound)
            {
                Debug.LogError($"Спрайт {cardValue.Suit}:{cardValue.Rank} не найден. Проверьте конфиг со стилями.");
                return CardBack;
            }

            return sprite;
        }
    }
}