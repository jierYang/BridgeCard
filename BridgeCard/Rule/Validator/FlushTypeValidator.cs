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

        public bool IsBlackCardsBiggerThanWhiteCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            return blackHandCards.IsBiggerThanCards(whiteHandCards);
        }
    }
}