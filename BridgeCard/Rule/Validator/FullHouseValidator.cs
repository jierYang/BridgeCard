using System.Linq;

namespace BridgeCard.Rule.Validator
{
    public class FullHouseValidator : IValidator
    {
        public int Priority { get; set; } = 7;

        public string CardsType { get; set; } = "Full House";

        public bool IsSatisfied(HandCards handCards)
        {
            var counts = handCards.Cards.GroupBy(x => x.CardNumber.Number)
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .OrderBy(x => x.Count);

            return counts.Count().Equals(2) && counts.First().Count == 2;
        }

        public int CalculatePoints(HandCards handCards)
        {
            var counts = handCards.Cards.GroupBy(x => x.CardNumber.GetNumber())
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .OrderByDescending(x => x.Count);

            return counts.First().Number;
        }
    }
}