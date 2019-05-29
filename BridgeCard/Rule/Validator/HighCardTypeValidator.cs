using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class HighCardTypeValidator : ITypeValidator
    {
        public int Priority { get; set; } = 1;

        public string TypeName { get; set; } = "High Card";

        public bool IsSatisfied(HandCards handCards)
        {
            return true;
        }

        public bool IsBlackCardsBiggerThanWhiteCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            return blackHandCards.IsBiggerThanCards(whiteHandCards);

        }
    }
}