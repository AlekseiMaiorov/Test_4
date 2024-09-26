using System;
using Enums;
using UnityEngine;

namespace Card
{
    [Serializable]
    public struct CardValue
    {
        public readonly CardRank Rank => _rank;
        public readonly CardSuit Suit => _suit;
        
        [SerializeReference]
        private CardRank _rank;
        [SerializeReference]
        private  CardSuit _suit;

        public CardValue(CardSuit suit, CardRank rank)
        {
            _suit = suit;
            _rank = rank;
        }
    }
}