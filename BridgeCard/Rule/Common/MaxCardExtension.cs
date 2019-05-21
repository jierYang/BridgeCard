using System.Collections.Generic;
using System.Linq;

namespace BridgeCard.Rule.Common
{
    public static class MaxCardExtension
    {
        public static string GetCompareCardsResult(IList<Card> blackCards, IList<Card> whiteCards)
        {
            var maxBlackCardNumber = blackCards.Max(x => x.CardNumber.GetNumber());

            var maxWhiteCardNumber = whiteCards.Max(x => x.CardNumber.GetNumber());

            if (maxBlackCardNumber == maxWhiteCardNumber)
            {
                return ComparedCardResult.Tie;
            }

            return maxBlackCardNumber > maxWhiteCardNumber ? ComparedCardResult.BlackWins : ComparedCardResult.WhiteWins;
        }
    }
}