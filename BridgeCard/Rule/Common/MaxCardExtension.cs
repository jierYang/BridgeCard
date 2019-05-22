using System.Collections.Generic;
using System.Linq;

namespace BridgeCard.Rule.Common
{
    public static class MaxCardExtension
    {
        public static int GetMaxCard(HandCards handCards)
        {
            return handCards.Cards.Max(x => x.CardNumber.GetNumber());
        }
    }
}