using System.Linq;

namespace BridgeCard.Rule.Validator
{
    public class TwoPairsValidator : IValidator

    {
        public int Priority { get; set; } = 3;

        public string CardsType { get; set; } = "Two Pairs";

        public bool IsSatisfied(HandCards handCards)
        {
            var count = handCards.Cards.GroupBy(x => x.CardNumber.Number)
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .Count(x => x.Count == 2);

            return count == 2;
        }

        public int CalculatePoints(HandCards handCards)
        {
            return handCards.Cards.GroupBy(x => x.CardNumber.GetNumber())
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .Sum(x => x.Number);
        }
    }
}