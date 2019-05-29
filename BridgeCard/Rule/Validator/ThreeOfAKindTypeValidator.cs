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

        public bool IsBlackCardsBiggerThanWhiteCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            if (blackHandCards.GetCardNumberOfCount(3) == whiteHandCards.GetCardNumberOfCount(3))
            {
                return blackHandCards.GetMaxSingleCard() > whiteHandCards.GetMaxSingleCard();
            }

            return blackHandCards.GetCardNumberOfCount(3) > whiteHandCards.GetCardNumberOfCount(3);
        }
    }
}