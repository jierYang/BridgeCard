using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class FullHouseTypeValidator : ITypeValidator
    {
        public int Priority { get; set; } = 7;

        public string TypeName { get; set; } = "Full House";

        public bool IsSatisfied(HandCards handCards)
        {
            var counts = handCards.Cards.GroupBy(x => x.CardNumber.Number)
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .OrderBy(x => x.Count);

            return counts.Count().Equals(2) && counts.First().Count == 2;
        }

        public bool IsBlackCardsBiggerThanWhiteCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            if (blackHandCards.GetCardNumberOfCount(3) == whiteHandCards.GetCardNumberOfCount(3))
            {
                return blackHandCards.GetCardNumberOfCount(2) > whiteHandCards.GetCardNumberOfCount(2);
            }

            return blackHandCards.GetCardNumberOfCount(3) > whiteHandCards.GetCardNumberOfCount(3);
        }

        
    }
}