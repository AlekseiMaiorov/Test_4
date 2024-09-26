using System.Collections.Generic;
using Card;

namespace Services
{
    public sealed class CardsCombinationProvider : ICardsCombinationProvider
    {
        public int TotalCardsInCombinations => _totalCardsInCombinations;
        private readonly ICardsCombinationGenerator _cardsCombinationGenerator;
        private List<List<CardValue>> _cardsCombinations;
        private int _totalCardsInCombinations;

        public CardsCombinationProvider(ICardsCombinationGenerator cardsCombinationGenerator)
        {
            _cardsCombinationGenerator = cardsCombinationGenerator;
        }

        public List<List<CardValue>> GetCardsCombinations(int totalCardsInCombinations)
        {
            var cardsCombinations = new List<List<CardValue>>();

            if (_totalCardsInCombinations == totalCardsInCombinations)
            {
                return _cardsCombinations;
            }

            var totalCards = 0;
            List<CardValue> combination;
            while (totalCards < totalCardsInCombinations)
            {
                combination = _cardsCombinationGenerator.GenerateRandomRangeCombination();
                cardsCombinations.Add(combination);
                totalCards += combination.Count;
            }

            _totalCardsInCombinations = totalCards;
            _cardsCombinations = cardsCombinations;
            return _cardsCombinations;
        }
    }
}