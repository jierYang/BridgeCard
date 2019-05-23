namespace BridgeCard.Rule
{
    public interface IDemand
    {
        string EvaluateCardsWinner(Player.Player blackPlayer, Player.Player whitePlayer);
    }
}