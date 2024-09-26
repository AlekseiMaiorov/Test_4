using System.Collections.Generic;
using Card;
using Controllers;

namespace Services
{
    public interface IBankCardsInitializer
    {
        void Initialize(
            List<CardController> bankCards,
            List<List<CardValue>> cardsDataCombinations);
    }
}