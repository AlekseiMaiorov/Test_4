using System.Collections.Generic;
using Card;
using Factories;

namespace Services
{
    public sealed class CardsDataProvider : ICardsDataProvider
    {
        public Dictionary<CardValue, CardData> CardsData => _cardsData;
        private readonly ICardDataFactory _cardDataFactory;
        private readonly Dictionary<CardValue, CardData> _cardsData;

        public CardsDataProvider(ICardDataFactory cardDataFactory)
        {
            _cardsData = new Dictionary<CardValue, CardData>();
            _cardDataFactory = cardDataFactory;
        }

        public CardData GetCardData(CardValue cardValue)
        {
            CardData cardData;
            if (_cardsData.TryGetValue(cardValue, out cardData))
            {
                return cardData;
            }

            cardData = _cardDataFactory.Create(cardValue);
            _cardsData.Add(cardValue, cardData);
            return cardData;
        }
    }
}