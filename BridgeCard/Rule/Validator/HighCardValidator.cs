using System.Collections.Generic;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule
{
    public class HighCardValidator : IValidator
    {
        public int Priority { get; set; } = 1;

        public string CardsType { get; set; } = "High Card";

        public bool IsSatisfied(HandCards cards)
        {
            return true;
        }

        public string CompareCards(HandCards blackCards, HandCards whiteCards)
        {
            return MaxCardExtension.GetCompareCardsResult(blackCards.Cards, whiteCards.Cards);
        }
    }
}