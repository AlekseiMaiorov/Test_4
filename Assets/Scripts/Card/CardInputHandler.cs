using System;
using Controllers;
using Intarfaces;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Card
{
    public sealed class CardInputHandler : MonoBehaviour, IClickEvent<CardController>, IPointerClickHandler
    {
        public event Action<CardController> OnClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(GetComponent<CardController>());
        }
    }
}