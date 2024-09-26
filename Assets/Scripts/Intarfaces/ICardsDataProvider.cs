using System.Collections.Generic;
using Card;

namespace Services
{
    public interface ICardsDataProvider
    {
        Dictionary<CardValue, CardData> CardsData { get; }
        CardData GetCardData(CardValue cardValue);
    }
}