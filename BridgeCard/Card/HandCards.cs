using System.Collections.Generic;
using System.Linq;
using BridgeCard.Rule;

namespace BridgeCard
{
    public class HandCards
    {
        public List<Card> Cards;

        public IValidator Validator;

        public HandCards(List<Card> cards)
        {
            Cards = cards;
        }

        public void ValidateType(IList<IValidator> _validators)
        {
            Validator = _validators.First(x => x.IsSatisfied(this));
        }
    }
}