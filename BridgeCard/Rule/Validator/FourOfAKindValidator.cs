using System.Collections.Generic;
using System.Linq;

namespace BridgeCard.Rule
{
    public class FourOfAKindValidator : IValidator
    {
        public int Priority { get; set; } = 8;

        public string CardsType { get; set; } = "Four of a kind ";

        public bool IsSatisfied(IList<Card> cards)
        {
            return cards.Select(x => cards.Count(t => x.CardNumber.Number.Equals(t.CardNumber.Number)))
                .Any(count => count == 4);
        }

        public string CompareCards(IList<Card> blackCards, IList<Card> whiteCards)
        {
            var blackSameCard = GetSameCard(blackCards);

            var whiteSameCard = GetSameCard(whiteCards);

            if (blackSameCard.Equals(whiteSameCard))
            {
                return ComparedCardResult.Tie;
            }

            return blackSameCard > whiteSameCard ? ComparedCardResult.BlackWins : ComparedCardResult.WhiteWins;
        }

        private int GetSameCard(IList<Card> blackCards)
        {
            var sameCard = blackCards.First().CardNumber.GetNumber();

            foreach (var card in blackCards)
            {
                var count = blackCards.Count(t => card.CardNumber.Number.Equals(t.CardNumber.Number));

                if (count == 4)
                {
                    sameCard = card.CardNumber.GetNumber();
                }
            }

            return sameCard;
        }
    }
}