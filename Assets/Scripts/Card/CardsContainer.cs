using System.Collections.Generic;
using System.Linq;
using Controllers;
using UnityEngine;

namespace Card
{
    public sealed class CardsContainer : MonoBehaviour
    {
        public List<CardController> Cards => _cards;
        
        [SerializeField]
        private List<CardController> _cards;

        private void Awake()
        {
            _cards = GetComponentsInChildren<CardController>().ToList();
        }
    }
}