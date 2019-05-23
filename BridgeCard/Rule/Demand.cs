using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BridgeCard.Rule.Validator;

namespace BridgeCard.Rule
{
    public class Demand : IDemand
    {
        private readonly IList<IValidator> _validators;

        public Demand(IList<IValidator> validators)
        {
            _validators = validators.OrderByDescending(x => x.Priority).ToList();
        }

        public string EvaluateCardsWinner(Player.Player blackPlayer, Player.Player whitePlayer)
        {
            blackPlayer.HandCards.ValidateType(_validators);

            whitePlayer.HandCards.ValidateType(_validators);

            if (blackPlayer.HandCards.Priority.Equals(whitePlayer.HandCards.Priority))
            {
                if (blackPlayer.HandCards.Points == whitePlayer.HandCards.Points)
                {
                    return "Tie";
                }

                return blackPlayer.HandCards.Points > whitePlayer.HandCards.Points
                    ? string.Format("{0} wins - {1}", blackPlayer.Role, blackPlayer.HandCards.CardsType)
                    : string.Format("{0} wins - {1}", whitePlayer.Role, blackPlayer.HandCards.CardsType);
            }

            return blackPlayer.HandCards.Priority > whitePlayer.HandCards.Priority
                ? string.Format("{0} wins - {1}", blackPlayer.Role, blackPlayer.HandCards.CardsType)
                : string.Format("{0} wins - {1}", whitePlayer.Role, whitePlayer.HandCards.CardsType);
        }
    }
}