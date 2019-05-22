using System.Collections.Generic;

namespace BridgeCard.Rule
{
    public interface IEvaluator
    {
        string EvaluateCardsWinner(HandCards blackCards, HandCards whiteCards);
    }
}