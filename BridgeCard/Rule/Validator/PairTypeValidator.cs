using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class PairTypeValidator : ITypeValidator

    {
        public int Priority { get; set; } = 2;

        public string TypeName { get; set; } = "Pair";

        public bool IsSatisfied(HandCards handCards)
        {
            var count = handCards.Cards.GroupBy(x => x.CardNumber.Number)
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .Count(x => x.Count == 2);

            return count == 1;
        }

        public bool IsBlackCardsBiggerThanWhiteCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            if (blackHandCards.GetCardNumberOfCount(2) == whiteHandCards.GetCardNumberOfCount(2))
            {
                var maxSingleBlack = blackHandCards.GetMaxSingleCard();

                var maxSingleWhite = whiteHandCards.GetMaxSingleCard();

                return maxSingleBlack > maxSingleWhite;
            }

            return blackHandCards.GetCardNumberOfCount(2) > whiteHandCards.GetCardNumberOfCount(2);
        }
    }
}