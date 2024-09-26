using System.Collections.Generic;
using Card;
using Common.Extensions;
using Intarfaces;
using UnityEngine;

namespace Controllers
{
    public sealed class GameFieldCardsController : IGameFieldCardsController
    {
        private CardController _startCard;
        private List<CardController> _gameFieldCards;

        public void Initialize(CardController startCard, List<CardController> gameFieldCards)
        {
            _startCard = startCard;
            foreach (var card in gameFieldCards)
            {
                var clickCardEvent = card.GetComponent<IClickEvent<CardController>>();
                clickCardEvent.OnClick += Collect;
            }
        }

        private void Collect(CardController cardController)
        {
            if (!cardController.IsOpen)
            {
                return;
            }

            var cardValue = cardController.CardData.CardValue;
            
            var nextCardRank = CardExtensions.GetNextCardRank(_startCard.CardData.CardValue.Rank);
            var previousCardRank = CardExtensions.GetPreviousCardRank(_startCard.CardData.CardValue.Rank);

            if (cardValue.Rank == nextCardRank ||
                cardValue.Rank == previousCardRank)
            {
                cardController.Move((RectTransform) _startCard.transform,
                                    () => CardExtensions.ChangeCard(cardController, _startCard));

                var nextCart = cardController.GetComponent<CardRelations>().Ancestor;
                
                if (nextCart)
                {
                    nextCart.GetComponent<CardController>().Open();
                }
            }
            else
            {
                cardController.Shake();
            }
        }
    }
}