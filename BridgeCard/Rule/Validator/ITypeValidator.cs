namespace BridgeCard.Rule.Validator
{
    public interface ITypeValidator
    {
        int Priority { get; set; }
        
        string TypeName { get; set; }

        bool IsSatisfied(HandCards handCards);

        ComparedResult CompareSameTypeCards(HandCards blackHandCards, HandCards whiteHandCards);
    }
}