using System.Linq;

namespace BridgeCard.Rule.Validator
{
    public class PairValidator : IValidator

    {
        public int Priority { get; set; } = 2;
        
        public string CardsType { get; set; } = "Pair";

        public bool IsSatisfied(HandCards handCards)
        {
            var count = handCards.Cards.GroupBy(x => x.CardNumber.Number)
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .Count(x => x.Count == 2);

            return count == 1;
        }

        public int CalculatePoints(HandCards handCards)
        {
            return handCards.Cards.GroupBy(x => x.CardNumber.GetNumber())
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .Sum(x => x.Number);
        }
    }
}