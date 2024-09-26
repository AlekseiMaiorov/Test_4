using System.Collections.Generic;
using System.Linq;
using Card;
using Controllers;
using Enums;
using UnityEngine;

namespace Common.Extensions
{
    public static class CardExtensions
    {
        public const int TOTAL_CARDS_RANK = 13;
        public const int TOTAL_CARDS_SUITS = 4;

        public static CardRank RandomRank => (CardRank) Random.Range(1, TOTAL_CARDS_RANK);

        public static CardSuit RandomSuit => (CardSuit) Random.Range(1, TOTAL_CARDS_SUITS);

        public static void ChangeCard(CardController currentCard, CardController startCard)
        {
            currentCard.gameObject.SetActive(false);
            startCard.InitCard(currentCard.CardData, true);
        }

        public static List<CardRelations> ConvertListToCardRelationsList(List<CardController> cardControllers)
        {
            var list = new List<CardRelations>();

            foreach (CardController controller in cardControllers)
            {
                list.Add(controller.GetComponent<CardRelations>());
            }

            return list;
        }

        public static CardRank GetNextCardRank(CardRank cardRank)
        {
            CardRank nextRank;

            if (cardRank < CardRank.King)
            {
                nextRank = cardRank + 1;
            }
            else
            {
                nextRank = CardRank.Ace;
            }

            return nextRank;
        }

        public static CardRank GetPreviousCardRank(CardRank cardRank)
        {
            CardRank nextRank;

            if (cardRank > CardRank.Ace)
            {
                nextRank = cardRank - 1;
            }
            else
            {
                nextRank = CardRank.King;
            }

            return nextRank;
        }

        public static CardValue GetRandomCardValue()
        {
            var card = new CardValue(RandomSuit, RandomRank);
            return card;
        }

        public static CardValue[] RemoveFirstsCardsAndFlattenCombinations(List<List<CardValue>> cardsCombinations)
        {
            List<CardValue> result = new List<CardValue>();

            foreach (var cardsCombination in cardsCombinations)
            {
                result.AddRange(cardsCombination.Skip(1));
            }

            return result.ToArray();
        }
    }
}