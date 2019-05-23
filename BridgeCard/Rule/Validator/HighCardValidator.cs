using System.Linq;

namespace BridgeCard.Rule.Validator
{
    public class HighCardValidator : IValidator
    {
        public int Priority { get; set; } = 1;

        public string CardsType { get; set; } = "High Card";

        public bool IsSatisfied(HandCards handCards)
        {
            return true;
        }

        public int CalculatePoints(HandCards handCards)
        {
            return handCards.Cards.Sum(t => t.CardNumber.GetNumber());
        }
    }
}