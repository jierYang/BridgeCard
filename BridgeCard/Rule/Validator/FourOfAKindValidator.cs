using System.Collections.Generic;
using System.Linq;

namespace BridgeCard.Rule
{
    public class FourOfAKindValidator : IValidator
    {
        public int Priority { get; set; } = 8;

        public string CardsType { get; set; } = "Four of a kind ";

        public bool IsSatisfied(HandCards cards)
        {
            return cards.Cards.Select(x => cards.Cards.Count(t => x.CardNumber.Number.Equals(t.CardNumber.Number)))
                .Any(count => count == 4);
        }

        public int CalculatePoints(HandCards handCards)
        {
            var sameCard = handCards.Cards.First().CardNumber.GetNumber();

            foreach (var card in handCards.Cards)
            {
                var count = handCards.Cards.Count(t => card.CardNumber.Number.Equals(t.CardNumber.Number));

                if (count == 4)
                {
                    sameCard = card.CardNumber.GetNumber();
                }
            }

            return sameCard;
        }
    }
}