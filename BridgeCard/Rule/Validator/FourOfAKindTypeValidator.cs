using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule.Validator
{
    public class FourOfAKindTypeValidator : ITypeValidator
    {
        public int Priority { get; set; } = 8;

        public string TypeName { get; set; } = "Four of a kind ";

        public bool IsSatisfied(HandCards handCards)
        {
            return handCards.Cards
                .Select(x => handCards.Cards.Count(t => x.CardNumber.Number.Equals(t.CardNumber.Number)))
                .Any(count => count == 4);
        }

        public bool IsBlackCardsBiggerThanWhiteCards(HandCards blackHandCards, HandCards whiteHandCards)
        {
            if (blackHandCards.GetCardNumberOfCount(4) == whiteHandCards.GetCardNumberOfCount(4))
            {
                return blackHandCards.GetCardNumberOfCount(1) > whiteHandCards.GetCardNumberOfCount(1);
            }

            return blackHandCards.GetCardNumberOfCount(4) > whiteHandCards.GetCardNumberOfCount(4);
        }
    }
}