using System.Collections.Generic;
using Card;

namespace Services
{
    public interface ICardsCombinationGenerator
    {
        List<CardValue> GenerateRandomRangeCombination();
    }
}