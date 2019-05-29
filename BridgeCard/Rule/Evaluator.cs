using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BridgeCard.Rule.Common;
using BridgeCard.Rule.Validator;

namespace BridgeCard.Rule
{
    public class Evaluator : IEvaluator
    {
        private readonly IList<ITypeValidator> _validators;

        public Evaluator(IList<ITypeValidator> validators)
        {
            _validators = validators.OrderByDescending(x => x.Priority).ToList();
        }

        public string EvaluateCardsWinner(Player.Player blackPlayer, Player.Player whitePlayer)
        {
            var blackCardsType = blackPlayer.HandCards.GetCardsType(_validators);

            var whiteCardType = whitePlayer.HandCards.GetCardsType(_validators);

            if (blackCardsType.Priority.Equals(whiteCardType.Priority))
            {
                var comparedResult = blackCardsType.CompareSameTypeCards(blackPlayer.HandCards, whitePlayer.HandCards);

                if (comparedResult.Equals(ComparedResult.Tie))
                {
                    return "Tie";
                }

                var sameTypeWinner = comparedResult.Equals(ComparedResult.BlackWin)
                    ? blackPlayer
                    : whitePlayer;

                return GenerateWinResult(sameTypeWinner);
            }

            var winner = blackCardsType.Priority > whiteCardType.Priority ? blackPlayer : whitePlayer;

            return GenerateWinResult(winner);
        }


        private string GenerateWinResult(Player.Player winner)
        {
            if (winner.HandCards.CardsType.TypeName.Equals("High Card"))
            {
                return string.Format("{0} wins - {1}: {2}", winner.Role, winner.HandCards.CardsType.TypeName,
                    winner.HandCards.GetMaxCard());
            }

            return string.Format("{0} wins - {1}", winner.Role, winner.HandCards.CardsType.TypeName);
        }
    }
}