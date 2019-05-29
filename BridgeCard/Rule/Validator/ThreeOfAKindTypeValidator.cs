using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class ThreeOfAKindTypeValidator : ITypeValidator
    {
        public int Priority { get; set; } = 4;

        public string TypeName { get; set; } = "Three of a Kind";

        public bool IsSatisfied(HandCards handCards)
        {
            return handCards.Cards.GroupBy(x => x.CardNumber.Number)
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .Any(x => x.Count == 3);
        }

        public ComparedResult CompareSameTypeCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            if (blackHandCards.IsSameCardsNumber(whiteHandCards))
            {
                return ComparedResult.Tie;
            }

            if (blackHandCards.GetCardNumberOfCount(3) == whiteHandCards.GetCardNumberOfCount(3))
            {
                return blackHandCards.GetMaxSingleCard() > whiteHandCards.GetMaxSingleCard()
                    ? ComparedResult.BlackWin
                    : ComparedResult.WhiteWin;
            }

            return blackHandCards.GetCardNumberOfCount(3) > whiteHandCards.GetCardNumberOfCount(3)
                ? ComparedResult.BlackWin
                : ComparedResult.WhiteWin;
        }
    }
}