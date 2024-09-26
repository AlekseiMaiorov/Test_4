using System.Collections.Generic;
using Card;
using Controllers;

namespace Services
{
    public interface IStartCardInitializer
    {
        void Initialize(
            CardController startCard,
            List<List<CardValue>> cardsDataCombinations);
    }
}