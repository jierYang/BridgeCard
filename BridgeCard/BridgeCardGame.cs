using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BridgeCard
{
    public class BridgeCardGame
    {
        public readonly IList<Card> BlackCards;

        public readonly IList<Card> WhiteCards;

        public BridgeCardGame()
        {
            BlackCards = new List<Card>();

            WhiteCards = new List<Card>();
        }

        public string GetGameResult(string blackCards, string whiteCards)
        {
            blackCards.Split(" ").ToList().ForEach(x =>
                BlackCards.Add(new Card(x[0], ColorTypes.GetColorType(x[1]))));

            whiteCards.Split(" ").ToList().ForEach(x =>
                WhiteCards.Add(new Card(x[0], ColorTypes.GetColorType(x[1]))));

            return null;
        }
    }
}