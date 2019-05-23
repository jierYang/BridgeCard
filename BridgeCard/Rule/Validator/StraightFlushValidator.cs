using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class StraightFlushValidator : IValidator
    {
        public int Priority { get; set; } = 9;
        
        public string CardsType { get; set; } = "Straight flush";

        public bool IsSatisfied(HandCards handCards)
        {
            var isSameColor = handCards.Cards.All(x => x.CardColor.Equals(handCards.Cards.First().CardColor));

            var list = handCards.Cards.OrderBy(x => x.CardNumber.GetNumber()).ToList();

            var isStraight = StraightCardExtension.IsStraight(list);

            return isSameColor && isStraight;
        }

        public int CalculatePoints(HandCards handCards)
        {
            return handCards.Cards.Max(x => x.CardNumber.GetNumber());
        }
    }
}