using Controllers;
using UnityEngine;

namespace Card
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(CardController))]
    public sealed class CardRelations : MonoBehaviour
    {
        public CardRelations Ancestor => _ancestor;
        public CardRelations Descendant => _descendant;

        [SerializeField]
        private CardRelations _ancestor;
        [SerializeField]
        private CardRelations _descendant;

        public void SetAncestor(CardRelations ancestor)
        {
            _ancestor = ancestor;
        }

        public void SetDescendant(CardRelations descendant)
        {
            _descendant = descendant;
        }
    }
}