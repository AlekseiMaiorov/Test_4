using Card;
using Intarfaces;

namespace Factories
{
    public sealed class CardDataFactory : ICardDataFactory
    {
        private readonly ICardsStyleProvider _cardsStyleProvider;

        public CardDataFactory(ICardsStyleProvider cardsStyleProvider)
        {
            _cardsStyleProvider = cardsStyleProvider;
        }

        public CardData Create(CardValue cardValue)
        {
            return new CardData(cardValue, _cardsStyleProvider.CardBack, _cardsStyleProvider.GetFrontSprite(cardValue));
        }
    }
}