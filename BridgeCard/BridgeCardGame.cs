﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using BridgeCard.Rule;

namespace BridgeCard
{
    public class BridgeCardGame
    {
        public readonly IList<Card> BlackCards;

        public readonly IList<Card> WhiteCards;

        private IEvaluator _evaluator;

        public BridgeCardGame()
        {
            var dependency = new Dependency();
            
            _evaluator = dependency.Container.BeginLifetimeScope().Resolve<IEvaluator>();
            
            BlackCards = new List<Card>();

            WhiteCards = new List<Card>();
        }

        public string GetGameResult(string blackCards, string whiteCards)
        {
            blackCards.Split(" ").ToList().ForEach(x =>
                BlackCards.Add(new Card(x[0], x[1])));

            whiteCards.Split(" ").ToList().ForEach(x =>
                WhiteCards.Add(new Card(x[0], x[1])));

            return _evaluator.EvaluateCardsWinner(BlackCards, WhiteCards);
        }
    }
}