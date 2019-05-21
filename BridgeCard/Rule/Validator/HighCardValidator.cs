using System.Collections.Generic;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule
{
    public class HighCardValidator : IValidator
    {
        public int Priority { get; set; } = 1;

        public string CardsType { get; set; } = "High Card";

        public bool IsSatisfied(IList<Card> cards)
        {
            return true;
        }

        public string CompareCards(IList<Card> blackCards, IList<Card> whiteCards)
        {
            return MaxCardExtension.GetCompareCardsResult(blackCards, whiteCards);
        }
    }
}