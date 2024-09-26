using Card;
using Services;
using UnityEngine;
using VContainer;

namespace Controllers
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField]
        private CardsContainer _bankCards;
        [SerializeField]
        private CardController _startCard;
        [SerializeField]
        private CardsContainer _gameFieldCards;

        private IBankCardsInitializer _bankCardsInitializer;
        private IGameFieldCardsInitializer _gameFieldCardsInitializer;
        private ICardsCombinationProvider _combinationProvider;
        private IGameFieldCardsController _gameFieldGameFieldCardsController;
        private IBankCardsController _bankCardsController;
        private IStartCardInitializer _startCardInitializer;
        private int _startCardsCount;

        [Inject]
        private void Init(
            IStartCardInitializer startCardInitializer,
            IBankCardsInitializer bankCardsInitializer,
            IGameFieldCardsInitializer gameFieldCardsInitializer,
            ICardsCombinationProvider combinationProvider,
            IGameFieldCardsController gameFieldCardsController,
            IBankCardsController bankCardsController)
        {
            _startCardInitializer = startCardInitializer;
            _bankCardsController = bankCardsController;
            _gameFieldGameFieldCardsController = gameFieldCardsController;
            _bankCardsInitializer = bankCardsInitializer;
            _gameFieldCardsInitializer = gameFieldCardsInitializer;
            _combinationProvider = combinationProvider;
            _startCardsCount = 1;
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            var totalCardsInScene = _gameFieldCards.Cards.Count + _bankCards.Cards.Count + _startCardsCount;
            var combinations = _combinationProvider.GetCardsCombinations(totalCardsInScene);
        
            _startCardInitializer.Initialize(_startCard, combinations);       
            _bankCardsInitializer.Initialize(_bankCards.Cards, combinations);
            _gameFieldCardsInitializer.Initialize(_gameFieldCards.Cards, combinations);
        
            _gameFieldGameFieldCardsController.Initialize(_startCard, _gameFieldCards.Cards);
            _bankCardsController.Initialize(_startCard, _bankCards.Cards);

        }
    }
}