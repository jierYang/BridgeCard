using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BridgeCard.Rule
{
    public class Evaluator : IEvaluator
    {
        private readonly IList<IValidator> _validators;

        public Evaluator(IList<IValidator> validators)
        {
            _validators = validators.OrderByDescending(x => x.Priority).ToList();
        }

        public string EvaluateCardsWinner(HandCards blackCards, HandCards whiteCards)
        {
            blackCards.ValidateType(_validators);
            
            whiteCards.ValidateType(_validators);
            
            if (blackCards.Priority.Equals(whiteCards.Priority))
            {
                var winnerMessage = blackCards.Validator.CompareCards(blackCards, whiteCards);

                return winnerMessage.Equals("Tie")
                    ? "Tie"
                    : string.Format("{0} - {1}", winnerMessage, blackCards.CardsType);
            }

            return blackCards.Priority > whiteCards.Priority
                ? string.Format("Black wins - {0}", blackCards.CardsType)
                : string.Format("White wins - {0}", whiteCards.CardsType);
        }
    }
}