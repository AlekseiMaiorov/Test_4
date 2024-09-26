using System.Collections.Generic;
using Card;
using Common.Extensions;
using Intarfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    public sealed class BankCardsController : IBankCardsController
    {
        private CardController _startCard;

        public void Initialize(CardController startCard, List<CardController> bankCards)
        {
            _startCard = startCard;

            foreach (var card in bankCards)
            {
                if (!card.gameObject.activeSelf)
                {
                    continue;
                }

                card.GetComponent<Image>().raycastTarget = false;
                var clickCardEvent = card.GetComponent<IClickEvent<CardController>>();
                clickCardEvent.OnClick += Open;
            }

            bankCards[0].GetComponent<Image>().raycastTarget = true;
        }

        private void Open(CardController cardController)
        {
            cardController.Open();
            cardController.Move((RectTransform) _startCard.transform,
                                () => CardExtensions.ChangeCard(cardController, _startCard));
            var nextCard = cardController.GetComponent<CardRelations>().Ancestor;
            if (nextCard != null)
            {
                nextCard.GetComponent<Image>().raycastTarget = true;
            }
        }
    }
}