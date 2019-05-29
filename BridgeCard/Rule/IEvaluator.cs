namespace BridgeCard.Rule
{
    public interface IEvaluator
    {
        string EvaluateCardsWinner(Player.Player blackPlayer, Player.Player whitePlayer);
    }
}