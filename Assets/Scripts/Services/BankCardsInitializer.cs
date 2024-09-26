using System.Collections.Generic;
using Card;
using Common.Extensions;
using Controllers;
using Factories;
using Intarfaces;
using UnityEngine;

namespace Services
{
    public sealed class BankCardsInitializer : IBankCardsInitializer
    {
        private readonly ICardDataFactory _cardDataFactory;
        private readonly IOverlapCardsFinder _overlapCardsFinder;
        private readonly ICardAnimations _cardAnimations;

        public BankCardsInitializer(
            IOverlapCardsFinder overlapCardsFinder,
            ICardDataFactory cardDataFactory,
            ICardAnimations cardAnimations)
        {
            _cardAnimations = cardAnimations;
            _overlapCardsFinder = overlapCardsFinder;
            _cardDataFactory = cardDataFactory;
        }

        public void Initialize(
            List<CardController> bankCards,
            List<List<CardValue>> cardsDataCombinations)
        {
            InitBankCards(bankCards, cardsDataCombinations);
        }

        private void FindRelations(List<CardController> bankCards)
        {
            _overlapCardsFinder.FindCardsRelations(CardExtensions.ConvertListToCardRelationsList(bankCards));
        }

        private void InitBankCards(
            List<CardController> bankCards,
            List<List<CardValue>> cardsValueCombinations)
        {
            FindRelations(bankCards);
            bankCards.Reverse();

            var combinationsCount = cardsValueCombinations.Count;
            var bankCardsCount = bankCards.Count;

            for (var i = 1; i < combinationsCount; i++)
            {
                var cardValue = cardsValueCombinations[i][0];
                var cardData = _cardDataFactory.Create(cardValue);
                bankCards[i - 1].InitCard(cardData, false);
                bankCards[i - 1].SetCardAnimations(_cardAnimations);
            }

            OffEmptyBankCards(bankCards, combinationsCount, bankCardsCount);

            if (combinationsCount > bankCardsCount)
            {
                Debug.LogError("В банке не хватает карт");
            }
        }

        private void OffEmptyBankCards(List<CardController> bankCards, int combinationsCount, int bankCardsCount)
        {
            if (combinationsCount < bankCardsCount)
            {
                for (var i = combinationsCount; i <= bankCardsCount; i++)
                {
                    bankCards[i - 1].gameObject.SetActive(false);
                }
            }
        }
    }
}