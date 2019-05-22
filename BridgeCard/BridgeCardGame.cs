using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using BridgeCard.Rule;

namespace BridgeCard
{
    public class BridgeCardGame
    {
        public HandCards BlackCards;

        public HandCards WhiteCards;

        private IEvaluator _evaluator;

        public BridgeCardGame()
        {
            var dependency = new Dependency();
            
            _evaluator = dependency.Container.BeginLifetimeScope().Resolve<IEvaluator>();
        }

        public string GetGameResult(string blackCards, string whiteCards)
        {
            BlackCards = new HandCards(InitHandCards(blackCards));
            
            WhiteCards = new HandCards(InitHandCards(whiteCards));

            return _evaluator.EvaluateCardsWinner(BlackCards, WhiteCards);
        }

        private static List<Card> InitHandCards(string blackCards)
        {
            var bCards = new List<Card>();

            blackCards.Split(" ").ToList().ForEach(x =>
                bCards.Add(new Card(x[0], x[1])));
            return bCards;
        }
    }
}