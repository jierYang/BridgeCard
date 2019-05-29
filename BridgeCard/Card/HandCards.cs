using System.Collections.Generic;
using System.Linq;
using BridgeCard.Rule.Validator;

namespace BridgeCard
{
    public class HandCards
    {
        public List<Card> Cards;

        public ITypeValidator CardsType { get; private set; }

        public HandCards(string cards)
        {
            var bCards = new List<Card>();

            cards.Split(" ").ToList().ForEach(x => bCards.Add(new Card(x[0], x[1])));
            
            Cards = bCards;
        }

        public ITypeValidator GetCardsType(IList<ITypeValidator> validators)
        {
            CardsType = validators.First(x => x.IsSatisfied(this));

            return CardsType;
        }
    }
}