using System.Collections.Generic;
using Card;

namespace Services
{
    public interface IOverlapCardsFinder
    {
        void FindCardsRelations(List<CardRelations> cardRelations);
    }
}