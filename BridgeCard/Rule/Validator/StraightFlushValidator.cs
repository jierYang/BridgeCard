using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BridgeCard.Rule.Common;

namespace BridgeCard.Rule
{
    public class StraightFlushValidator : IValidator
    {
        public int Priority { get; set; } = 9;
        
        public string CardsType { get; set; } = "Straight flush";

        public bool IsSatisfied(HandCards cards)
        {
            var isSameColor = cards.Cards.All(x => x.CardColor.Equals(cards.Cards.First().CardColor));

            var list = cards.Cards.OrderBy(x => x.CardNumber.GetNumber()).ToList();

            var isStraight = StraightCardExtension.IsStraight(list);

            return isSameColor && isStraight;
        }

        public int CalculatePoints(HandCards handCards)
        {
            return handCards.Cards.Max(x => x.CardNumber.GetNumber());
        }
    }
}