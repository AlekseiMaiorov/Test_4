using System.Collections.Generic;

namespace Controllers
{
    public interface IBankCardsController
    {
        void Initialize(CardController startCard, List<CardController> bankCards);
    }
}