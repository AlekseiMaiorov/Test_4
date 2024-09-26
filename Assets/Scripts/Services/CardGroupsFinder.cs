using System.Collections.Generic;
using Card;

namespace Services
{
    public sealed class CardGroupsFinder : ICardGroupsFinder
    {
        public List<List<CardRelations>> FindGroups(List<CardRelations> cardsRelation)
        {
            var visited = new HashSet<CardRelations>();
            var groups = new List<List<CardRelations>>();

            foreach (var cardRelations in cardsRelation)
            {
                if (visited.Contains(cardRelations))
                {
                    continue;
                }

                var currentGroup = new List<CardRelations>();
                var current = cardRelations;

                while (current.Descendant != null &&
                       !visited.Contains(current))
                {
                    current = current.Descendant;
                }

                while (current != null &&
                       !visited.Contains(current))
                {
                    currentGroup.Add(current);
                    visited.Add(current);
                    current = current.Ancestor;
                }

                groups.Add(currentGroup);
            }

            return groups;
        }
    }
}