using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class StraightValidator : IValidator
    {
        public int Priority { get; set; } = 5;
        public string CardsType { get; set; } = "Straight";

        public bool IsSatisfied(HandCards handCards)
        {
            return StraightCardExtension.IsStraight(handCards.Cards);
        }

        public int CalculatePoints(HandCards handCards)
        {
            return handCards.Cards.Max(x => x.CardNumber.GetNumber());
        }
    }
}