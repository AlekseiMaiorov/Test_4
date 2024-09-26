using System;
using UnityEngine;

namespace Card
{
    [Serializable]
    public sealed class CardData
    {
        public CardValue CardValue => _cardValue;
        public Sprite BackSprite => _backSprite;
        public Sprite FrontSprite => _frontSprite;

        [SerializeField]
        private CardValue _cardValue;
        private Sprite _backSprite;
        private Sprite _frontSprite;

        public CardData(CardValue cardValue, Sprite backSprite, Sprite frontSprite)
        {
            _cardValue = cardValue;
            _backSprite = backSprite;
            _frontSprite = frontSprite;
        }
    }
}