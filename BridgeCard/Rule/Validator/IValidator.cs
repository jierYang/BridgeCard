using System.Collections;
using System.Collections.Generic;

namespace BridgeCard.Rule
{
    public interface IValidator
    {
        int Priority { get; set; }
        
        string CardsType { get; set; }

        bool IsSatisfied(IList<Card> cards);

        string CompareCards(IList<Card> blackCards, IList<Card> whiteCards);
    }
}