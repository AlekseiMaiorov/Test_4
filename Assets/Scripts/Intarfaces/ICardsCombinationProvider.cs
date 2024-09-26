using System.Collections.Generic;
using Card;

namespace Services
{
    public interface ICardsCombinationProvider
    {
        int TotalCardsInCombinations { get; }
        List<List<CardValue>> GetCardsCombinations(int totalCardsInCombinations);
    }
}