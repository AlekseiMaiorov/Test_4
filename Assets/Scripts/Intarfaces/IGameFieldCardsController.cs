using System.Collections.Generic;

namespace Controllers
{
    public interface IGameFieldCardsController
    {
        void Initialize(CardController startCard, List<CardController> gameFieldCards);
    }
}