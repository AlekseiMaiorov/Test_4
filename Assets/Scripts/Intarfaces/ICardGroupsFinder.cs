using System.Collections.Generic;
using Card;

namespace Services
{
    public interface ICardGroupsFinder
    {
        List<List<CardRelations>> FindGroups(List<CardRelations> cardsRelation);
    }
}