using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BridgeCard.Rule.Common
{
    public static class CardExtension
    {
        public static int CardCount => 5;
        
        public static int GetMaxCard(this HandCards handCards)
        {
            return handCards.Cards.Max(x => x.CardNumber.GetNumber());
        }

        public static void OrderByDescending(this HandCards handCards)
        {
            handCards.Cards.OrderByDescending(x => x.CardNumber.GetNumber());
        }

        public static bool IsBiggerThan(this Card cardA, Card cardB)
        {
            return cardA.CardNumber.GetNumber() > cardB.CardNumber.GetNumber();
        }
        
        public static bool IsBiggerThanCards(this HandCards cardsA, HandCards cardsB)
        {
            cardsA.OrderByDescending();

            cardsB.OrderByDescending();

            return cardsA.Cards.Where((t, i) => t.IsBiggerThan(cardsB.Cards[i])).Any();
        }

        public static bool IsSameCardsNumber(this HandCards handCardsA, HandCards handCardsB)
        {
            handCardsA.OrderByDescending();

            handCardsB.OrderByDescending();

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
                .First(x=>x.Count==count);

            return counts.Number;
        }
        
        public static int GetMaxSingleCard(this HandCards handCards)
        {
            return handCards.Cards.GroupBy(x => x.CardNumber.GetNumber())
                .Select(g => new {Number = g.Key, Count = g.Count()}).Where(x => x.Count == 1).Max(x => x.Number);
        }
    }
}