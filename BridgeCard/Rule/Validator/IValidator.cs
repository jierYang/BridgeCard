using System.Collections;
using System.Collections.Generic;

namespace BridgeCard.Rule
{
    public interface IValidator
    {
        int Priority { get; set; }
        
        string CardsType { get; set; }

        bool IsSatisfied(HandCards cards);

        int CalculatePoints(HandCards handCards);
    }
}