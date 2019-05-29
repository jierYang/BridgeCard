using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using BridgeCard.Player;
using BridgeCard.Rule;
using BridgeCard.Rule.Common;

namespace BridgeCard
{
    public class BridgeCardGame
    {
        public Player.Player BlackPlayer;

        public HandCards BlackHandCards;

        public Player.Player WhitePlayer;

        public HandCards WhiteHandCards;

        private readonly IEvaluator _evaluator;

        public BridgeCardGame()
        {
            var dependency = new Dependency();

            _evaluator = dependency.Container.BeginLifetimeScope().Resolve<IEvaluator>();
        }

        public string GetGameResult(string blackCards, string whiteCards)
        {
            BlackHandCards = new HandCards(blackCards);

            WhiteHandCards = new HandCards(whiteCards);

            WhitePlayer = new Player.Player(Role.White);
            BlackPlayer = new Player.Player(Role.Black);


            var gameResult = _evaluator.EvaluateCardsWinner(BlackHandCards, WhiteHandCards);

            return GenerateWinResult(gameResult);
        }


        private string GenerateWinResult(GameResult gameResult)
        {
            if (gameResult.Equals(GameResult.Tie))
            {
                return "Tie";
            }

            var winner = gameResult.Equals(GameResult.BlackWin) ? BlackPlayer : WhitePlayer;

            var winnerCards = gameResult.Equals(GameResult.BlackWin) ? BlackHandCards : WhiteHandCards;

            if (winnerCards.CardsType.TypeName.Equals("High Card"))
            {
                var maxCard = winnerCards.GetMaxCard().CardNumber.Number == 'A'
                    ? "Ace"
                    : winnerCards.GetMaxCard().CardNumber.Number.ToString();

                return string.Format("{0} wins - {1}: {2}", winner.Role, winnerCards.CardsType.TypeName, maxCard);
            }

            return string.Format("{0} wins - {1}", winner.Role, winnerCards.CardsType.TypeName);
        }
    }
}