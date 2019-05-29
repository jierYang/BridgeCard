using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class StraightFlushTypeValidator : ITypeValidator
    {
        public int Priority { get; set; } = 9;
        
        public string TypeName { get; set; } = "Straight flush";

        public bool IsSatisfied(HandCards handCards)
        {
            var isSameColor = handCards.Cards.All(x => x.CardColor.Equals(handCards.Cards.First().CardColor));

            var isStraight = StraightCardExtension.IsStraight(handCards.Cards);

            return isSameColor && isStraight;
        }

        public bool IsBlackCardsBiggerThanWhiteCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            return blackHandCards.GetMaxCard().CardNumber.GetNumber() >
                   whiteHandCards.GetMaxCard().CardNumber.GetNumber();
        }
    }
}