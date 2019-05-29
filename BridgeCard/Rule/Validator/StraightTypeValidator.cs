using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class StraightTypeValidator : ITypeValidator
    {
        public int Priority { get; set; } = 5;
        public string TypeName { get; set; } = "Straight";

        public bool IsSatisfied(HandCards handCards)
        {
            return StraightCardExtension.IsStraight(handCards.Cards);
        }

        public bool IsBlackCardsBiggerThanWhiteCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            return blackHandCards.GetMaxCard().CardNumber.GetNumber() >
                   whiteHandCards.GetMaxCard().CardNumber.GetNumber();
        }
    }
}