using System.Collections.Generic;
using Card;
using Common.Extensions;
using Enums;
using Random = UnityEngine.Random;

namespace Services
{
    public sealed class CardsCombinationGenerator : ICardsCombinationGenerator
    {
        private const float CHANGE_DIRECTION_PROBABILITY = 0.15f;
        private const float UP_CARD_RANK_PROBABILITY = 0.65f;
        private const int MAX_CARDS_IN_COMBINATION = 7;
        private const int MIN_CARDS_IN_COMBINATION = 2;
        
        public List<CardValue> GenerateRandomRangeCombination()
        {
            var cardsInCombination = Random.Range(MIN_CARDS_IN_COMBINATION, MAX_CARDS_IN_COMBINATION);

            var combination = new List<CardValue>(cardsInCombination);

            var firstCard = CardExtensions.GetRandomCardValue();

            combination.Add(firstCard);

            bool isUpCardRank = Random.value <= UP_CARD_RANK_PROBABILITY;

            var nextCard = firstCard.Rank;

            for (var i = 1; i <= cardsInCombination + 1; i++)
            {
                if (Random.value <= CHANGE_DIRECTION_PROBABILITY)
                {
                    isUpCardRank = !isUpCardRank;
                }

                if (isUpCardRank)
                {
                    nextCard = CardExtensions.GetNextCardRank(nextCard);
                }
                else
                {
                    nextCard = CardExtensions.GetPreviousCardRank(nextCard);
                }

                combination.Add(new CardValue(CardExtensions.RandomSuit, nextCard));
            }

            return combination;
        }
    }
}