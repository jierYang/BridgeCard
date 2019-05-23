using System.Collections.Generic;
using System.Linq;

namespace BridgeCard.Rule.Common
{
    public static class StraightCardExtension
    {
        public static bool IsStraight(IList<Card> cards)
        {
            var list = cards.OrderBy(x => x.CardNumber.GetNumber()).ToList();

            var isStraight = true;

            for (var i = 0; i < list.Count - 1; i++)
            {
                if (!(list[i].CardNumber.GetNumber() + 1).Equals(list[i + 1].CardNumber.GetNumber()))
                {
                    isStraight = false;

                    break;
                }
            }

            return isStraight;
        }
    }
}