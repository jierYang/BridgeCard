using System.Collections.Generic;
using System.Linq;
using BridgeCard.Player;
using BridgeCard.Rule;

namespace BridgeCard
{
    public class HandCards
    {
        public List<Card> Cards;

        public int Priority { get; private set; }

        public string CardsType { get; private set; }
        
        public int Point { get; private set; }

        public Role Role { get; set; }

        public HandCards(List<Card> cards, Role role)
        {
            Cards = cards;

            Role = role;
        }

        public void ValidateType(IList<IValidator> validators)
        {
            var validator = validators.First(x => x.IsSatisfied(this));
            Priority = validator.Priority;
            CardsType = validator.CardsType;
            Point = validator.CalculatePoints(this);
        }
    }
}