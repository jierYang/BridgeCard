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

        public ComparedResult CompareSameTypeCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            if (blackHandCards.IsSameCardsNumber(whiteHandCards))
            {
                return ComparedResult.Tie;
            }

            return blackHandCards.IsBiggerThanCards(whiteHandCards) ? ComparedResult.BlackWin : ComparedResult.WhiteWin;

        }
    }
}