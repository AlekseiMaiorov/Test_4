using Card;

namespace Factories
{
    public interface ICardDataFactory
    {
        CardData Create(CardValue cardValue);
    }
}