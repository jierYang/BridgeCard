using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using BridgeCard.Player;
using BridgeCard.Rule;

namespace BridgeCard
{
    public class BridgeCardGame
    {
        public Player.Player BlackPlayer;

        public Player.Player WhitePlayer;

        private IDemand _demand;

        public BridgeCardGame()
        {
            var dependency = new Dependency();

            _demand = dependency.Container.BeginLifetimeScope().Resolve<IDemand>();
        }

        public string GetGameResult(string blackCards, string whiteCards)
        {
            BlackPlayer = new Player.Player(new HandCards(blackCards), Role.Black);

            WhitePlayer = new Player.Player(new HandCards(whiteCards), Role.White);

            return _demand.EvaluateCardsWinner(BlackPlayer, WhitePlayer);
        }

        
    }
}