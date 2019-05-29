using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BridgeCard.Rule.Common
{
    public static class CardExtension
    {
        private static int CardCount => 5;

        public static Card GetMaxCard(this HandCards handCards)
        {
            return handCards.Cards.OrderByDescending(item => item.CardNumber.GetNumber()).First();
        }

        private static bool IsBiggerThan(this Card cardA, Card cardB)
        {
            return cardA.CardNumber.GetNumber() > cardB.CardNumber.GetNumber();
        }

        public static bool IsBiggerThanCards(this HandCards cardsA, HandCards cardsB)
        {
            var a = cardsA.Cards.OrderByDescending(x => x.CardNumber.GetNumber()).ToList();

            var b = cardsB.Cards.OrderByDescending(x => x.CardNumber.GetNumber()).ToList();

            for (var i = 0; i < CardCount; i++)
            {
                if (a[i].IsBiggerThan(b[i]))
                {
                    return true;
                }

                if (b[i].IsBiggerThan(a[i]))
                {
                    return false;
                }
            }

            return false;
        }

        public static bool IsSameCardsNumber(this HandCards handCardsA, HandCards handCardsB)
        {
            var a = handCardsA.Cards.OrderByDescending(x => x.CardNumber.GetNumber()).ToList();

            var b = handCardsB.Cards.OrderByDescending(x => x.CardNumber.GetNumber()).ToList();

            for (var i = 0; i < CardCount; i++)
            {
                if (!handCardsA.Cards[i].CardNumber.Number.Equals(handCardsB.Cards[i].CardNumber.Number))
                {
                    return false;
                }
            }

            return true;
        }

        public static int GetCardNumberOfCount(this HandCards blackHandCards, int count)
        {
            var counts = blackHandCards.Cards.GroupBy(x => x.CardNumber.GetNumber())
                .Select(g => new {Number = g.Key, Count = g.Count()})
                .First(x => x.Count == count);

            return counts.Number;
        }

        public static int GetMaxSingleCard(this HandCards handCards)
        {
            return handCards.Cards.GroupBy(x => x.CardNumber.GetNumber())
                .Select(g => new {Number = g.Key, Count = g.Count()}).Where(x => x.Count == 1).Max(x => x.Number);
        }
    }
}