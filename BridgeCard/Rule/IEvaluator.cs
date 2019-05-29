namespace BridgeCard.Rule
{
    public interface IEvaluator
    {
        GameResult EvaluateCardsWinner(HandCards BlackHandCards, HandCards whiteHandCards);
    }
}