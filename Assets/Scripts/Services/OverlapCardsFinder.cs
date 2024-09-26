using System;
using System.Collections.Generic;
using System.Linq;
using Card;
using Common.Extensions;
using UnityEngine;

namespace Services
{
    public sealed class OverlapCardsFinder : IOverlapCardsFinder
    {
        public void FindCardsRelations(List<CardRelations> cardRelations)
        {
            cardRelations.SetParentForAllTransforms(cardRelations[0].transform.parent);
            
            for (int i = 0; i < cardRelations.Count - 1; i++)
            {
                var currentCard = cardRelations[i];
                var nextCard = cardRelations[i + 1];

                var currentCardRectTransform = (RectTransform) currentCard.transform;
                var nextCardRectTransform = (RectTransform) nextCard.transform;

                var isOverlapping =
                    RectTransformExtensions.AreRectTransformsOverlapping(currentCardRectTransform,
                                                                         nextCardRectTransform);

                if (isOverlapping)
                {
                    currentCard.SetDescendant(nextCard);
                    nextCard.SetAncestor(currentCard);
                }
            }
        }
    }
}