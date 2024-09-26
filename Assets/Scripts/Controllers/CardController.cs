using System;
using Card;
using Intarfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Controllers
{
    [DisallowMultipleComponent]
    public sealed class CardController : MonoBehaviour
    {
        public CardData CardData => _cardData;
        public bool IsOpen => _isOpen;
        
        [SerializeField]
        private CardData _cardData;
        private ICardAnimations _cardAnimations;
        private Image _image;
        private bool _isOpen;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void Close()
        {
            _isOpen = false;
            SetImage(_cardData.BackSprite);
        }

        public void InitCard(CardData cardData, bool isOpen)
        {
            _isOpen = isOpen;
            SetModel(cardData);

            if (isOpen)
            {
                SetImage(cardData.FrontSprite);
            }
            else
            {
                SetImage(cardData.BackSprite);
            }
        }

        public void Move(RectTransform target, Action callback)
        {
            _cardAnimations.Move((RectTransform) transform, target, callback);
        }

        public void Open()
        {
            _isOpen = true;
            SetImage(_cardData.FrontSprite);
        }

        public void SetCardAnimations(ICardAnimations cardAnimations)
        {
            _cardAnimations = cardAnimations;
        }

        public void Shake()
        {
            _cardAnimations.Shake((RectTransform) transform);
        }

        private void SetImage(Sprite sprite)
        {
            _image.sprite = sprite;
        }

        private void SetModel(CardData cardData)
        {
            _cardData = cardData;
        }
    }
}