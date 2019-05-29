using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class FlushTypeValidator : ITypeValidator
    {
        public int Priority { get; set; } = 6;

        public string TypeName { get; set; } = "Flush";

        public bool IsSatisfied(HandCards handCards)
        {
            var counts = handCards.Cards.GroupBy(n => n.CardColor)
                .Select(c => new {Key = c.Key, total = c.Count()});

            return counts.Count() == 1;
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