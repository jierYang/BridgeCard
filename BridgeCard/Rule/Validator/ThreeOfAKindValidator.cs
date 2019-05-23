using System.Linq;

namespace BridgeCard.Rule.Validator
{
    public class ThreeOfAKindValidator : IValidator
    {
        public int Priority { get; set; } = 4;

        public string CardsType { get; set; } = "Three of a Kind";

        public bool IsSatisfied(HandCards handCards)
        {
            return handCards.Cards.GroupBy(x => x.CardNumber.Number)
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .Any(x => x.Count == 3);
        }

        public int CalculatePoints(HandCards handCards)
        {
            return handCards.Cards.GroupBy(x => x.CardNumber.GetNumber())
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .First(x => x.Count == 3)
                .Number;
        }
    }
}