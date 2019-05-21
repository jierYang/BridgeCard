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

        public bool IsSatisfied(IList<Card> cards)
        {
            var isSameColor = cards.All(x => x.CardColor.Equals(cards.First().CardColor));

            var list = cards.OrderBy(x => x.CardNumber.GetNumber()).ToList();

            var isStraight = StraightCardExtension.IsStraight(list);

            return isSameColor && isStraight;
        }


        public string CompareCards(IList<Card> blackCards, IList<Card> whiteCards)
        {
            return MaxCardExtension.GetCompareCardsResult(blackCards, whiteCards);
        }
    }
}