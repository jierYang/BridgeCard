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

        public ComparedResult CompareSameTypeCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            if (blackHandCards.IsSameCardsNumber(whiteHandCards))
            {
                return ComparedResult.Tie;
            }

            return blackHandCards.GetMaxCard() > whiteHandCards.GetMaxCard()
                ? ComparedResult.BlackWin
                : ComparedResult.WhiteWin;
        }
    }
}