using System.Collections.Generic;
using Card;
using Controllers;
using Factories;
using Intarfaces;

namespace Services
{
    public sealed class StartCardInitializer : IStartCardInitializer
    {
        private readonly ICardAnimations _cardAnimations;
        private readonly ICardDataFactory _cardDataFactory;

        public StartCardInitializer(
            ICardDataFactory cardDataFactory,
            ICardAnimations cardAnimations)
        {
            _cardAnimations = cardAnimations;
            _cardDataFactory = cardDataFactory;
        }

        public void Initialize(
            CardController startCard,
            List<List<CardValue>> cardsDataCombinations)
        {
            var startCardData = _cardDataFactory.Create(cardsDataCombinations[0][0]);
            startCard.InitCard(startCardData, true);
            startCard.SetCardAnimations(_cardAnimations);
        }
    }
}