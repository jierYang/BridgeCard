namespace BridgeCard.Rule.Validator
{
    public interface IValidator
    {
        int Priority { get; set; }
        
        string CardsType { get; set; }

        bool IsSatisfied(HandCards handCards);

        int CalculatePoints(HandCards handCards);
    }
}