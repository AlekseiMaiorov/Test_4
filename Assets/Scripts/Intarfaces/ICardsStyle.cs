using System.Collections.Generic;
using Enums;
using UnityEngine;

namespace Intarfaces
{
    public interface ICardsStyle
    {
        Sprite CardBack { get; }
        Dictionary<CardSuit, Dictionary<CardRank, Sprite>> CardsSprites { get; }
    }
}