using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class TwoPairsTypeValidator : ITypeValidator

    {
        public int Priority { get; set; } = 3;

        public string TypeName { get; set; } = "Two Pairs";

        public bool IsSatisfied(HandCards handCards)
        {
            var count = handCards.Cards.GroupBy(x => x.CardNumber.Number)
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .Count(x => x.Count == 2);

            return count == 2;
        }

        public ComparedResult CompareSameTypeCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            if (blackHandCards.IsSameCardsNumber(whiteHandCards))
            {
                return ComparedResult.Tie;
            }

            var blackList = blackHandCards.Cards.GroupBy(x => x.CardNumber.GetNumber())
                .Select(g => new {Number = g.Key, Count = g.Count()}).OrderBy(x => x.Number).Select(x => x.Number)
                .ToList();

            var blackMaxPair = blackList[1];
            var blackMinPair = blackList[0];

            var whiteList = blackHandCards.Cards.GroupBy(x => x.CardNumber.GetNumber())
                .Select(g => new {Number = g.Key, Count = g.Count()}).OrderBy(x => x.Number).Select(x => x.Number)
                .ToList();

            var whiteMaxPair = whiteList[1];
            var whiteMinPair = whiteList[0];

            if (blackMaxPair == whiteMaxPair)
            {
                return blackMinPair > whiteMinPair ? ComparedResult.BlackWin : ComparedResult.WhiteWin;
            }

            return blackMaxPair > whiteMaxPair ? ComparedResult.BlackWin : ComparedResult.WhiteWin;
        }
    }
}