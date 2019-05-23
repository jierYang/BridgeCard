using System.Linq;

namespace BridgeCard.Rule.Validator
{
    public class FlushValidator : IValidator
    {
        public int Priority { get; set; } = 6;

        public string CardsType { get; set; } = "Flush";

        public bool IsSatisfied(HandCards handCards)
        {
            var counts = handCards.Cards.GroupBy(n => n.CardColor)
                .Select(c => new {Key = c.Key, total = c.Count()});

            return counts.Count() == 1;
        }

        public int CalculatePoints(HandCards handCards)
        {
            return handCards.Cards.OrderByDescending(x => x.CardNumber.GetNumber()).First().CardNumber.GetNumber();
        }
    }
}