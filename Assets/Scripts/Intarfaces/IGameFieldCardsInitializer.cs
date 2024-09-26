using System.Collections.Generic;
using Card;
using Controllers;

namespace Services
{
    public interface IGameFieldCardsInitializer
    {
        void Initialize(
            List<CardController> gameFieldCards,
            List<List<CardValue>> cardsCombinations);
    }
}