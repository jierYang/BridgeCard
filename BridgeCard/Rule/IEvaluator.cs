using System.Collections.Generic;

namespace BridgeCard.Rule
{
    public interface IEvaluator
    {
        string EvaluateCardsWinner(IList<Card> blackCards, IList<Card> whiteCards);
    }
}