using System.Collections.Generic;
using Card;
using Common.Extensions;
using Controllers;
using Factories;
using Intarfaces;
using UnityEngine;

namespace Services
{
    public sealed class GameFieldCardsInitializer : IGameFieldCardsInitializer
    {
        private readonly ICardDataFactory _cardDataFactory;
        private readonly IOverlapCardsFinder _overlapCardsFinder;
        private readonly ICardAnimations _cardAnimations;
        private readonly ICardGroupsFinder _cardGroupsFinder;

        public GameFieldCardsInitializer(
            IOverlapCardsFinder overlapCardsFinder,
            ICardDataFactory cardDataFactory,
            ICardGroupsFinder cardGroupsFinder,
            ICardAnimations cardAnimations)
        {
            _cardAnimations = cardAnimations;
            _overlapCardsFinder = overlapCardsFinder;
            _cardDataFactory = cardDataFactory;
            _cardGroupsFinder = cardGroupsFinder;
        }

        public void Initialize(
            List<CardController> gameFieldCards,
            List<List<CardValue>> cardsCombinations)
        {
            var cardRelationsList = CardExtensions.ConvertListToCardRelationsList(gameFieldCards);
            _overlapCardsFinder.FindCardsRelations(cardRelationsList);
            var cardsGroups = _cardGroupsFinder.FindGroups(cardRelationsList);

            var flattenCombinations = CardExtensions.RemoveFirstsCardsAndFlattenCombinations(cardsCombinations);
            var combinationsQueue = new Queue<CardValue>(flattenCombinations);

            var currentCardInGroup = new List<CardRelations>(cardsCombinations.Count);

            for (var i = 0; i < cardsGroups.Count; i++)
            {
                currentCardInGroup.Add(cardsGroups[i][0]);
            }

            Debug.Log("Выиграшная последовательность карт");

            while (cardsGroups.Count != 0)
            {
                var randomGroup = Random.Range(0, cardsGroups.Count);

                var cardRelations = currentCardInGroup[randomGroup];
                var cardController = cardRelations.GetComponent<CardController>();
                var cardValue = combinationsQueue.Dequeue();

                Debug.Log($"{cardValue.Rank} {cardValue.Suit}");

                var cardData = _cardDataFactory.Create(cardValue);
                cardController.InitCard(cardData, false);
                cardController.SetCardAnimations(_cardAnimations);
                
                if (currentCardInGroup[randomGroup].Ancestor == null)
                {
                    cardsGroups[randomGroup][0].GetComponent<CardController>().Open();

                    currentCardInGroup.Remove(currentCardInGroup[randomGroup]);
                    cardsGroups.Remove(cardsGroups[randomGroup]);
                    continue;
                }

                currentCardInGroup[randomGroup] = cardRelations.Ancestor;
            }
        }
    }
}