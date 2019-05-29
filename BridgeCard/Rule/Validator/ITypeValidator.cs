namespace BridgeCard.Rule.Validator
{
    public interface ITypeValidator
    {
        int Priority { get; set; }
        
        string TypeName { get; set; }

        bool IsSatisfied(HandCards handCards);

        bool IsBlackCardsBiggerThanWhiteCards(HandCards blackHandCards, HandCards whiteHandCards);
    }
}