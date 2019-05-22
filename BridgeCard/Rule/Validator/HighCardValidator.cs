using System.Collections.Generic;
using System.Linq;
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

        public int CalculatePoints(HandCards handCards)
        {
            return handCards.Cards.Sum(t => t.CardNumber.GetNumber());
        }
    }
}