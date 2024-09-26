using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Enums;
using Intarfaces;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "CardsStyle", menuName = "Configs/CardsStyle", order = 0)]
    public sealed class CardsStyle : ScriptableObject, ICardsStyle
    {
        public Sprite CardBack => _cardBack;
        public Dictionary<CardSuit, Dictionary<CardRank, Sprite>> CardsSprites => _cardsSprites;

        [SerializeField]
        private Sprite _cardBack;
        [SerializeField]
        [SerializedDictionary("Rank", "Sprite")]
        private SerializedDictionary<CardRank, Sprite> _clubs;

        [SerializeField]
        [SerializedDictionary("Rank", "Sprite")]
        private SerializedDictionary<CardRank, Sprite> _diamonds;

        [SerializeField]
        [SerializedDictionary("Rank", "Sprite")]
        private SerializedDictionary<CardRank, Sprite> _hearts;

        [SerializeField]
        [SerializedDictionary("Rank", "Sprite")]
        private SerializedDictionary<CardRank, Sprite> _spades;

        private Dictionary<CardSuit, Dictionary<CardRank, Sprite>> _cardsSprites =
            new Dictionary<CardSuit, Dictionary<CardRank, Sprite>>();

        private void OnEnable()
        {
            InitCardsStyleDictionary();
        }

        private void InitCardsStyleDictionary()
        {
            _cardsSprites.Add(CardSuit.Spades, _spades);
            _cardsSprites.Add(CardSuit.Clubs, _clubs);
            _cardsSprites.Add(CardSuit.Diamonds, _diamonds);
            _cardsSprites.Add(CardSuit.Hearts, _hearts);
        }
    }
}