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
            
            if (blackCards.Validator.Priority.Equals(whiteCards.Validator.Priority))
            {
                var compareCards = blackCards.Validator.CompareCards(blackCards, whiteCards);

                return compareCards.Equals("Tie")
                    ? "Tie"
                    : string.Format("{0} - {1}", compareCards, blackCards.Validator.CardsType);
            }

            return blackCards.Validator.Priority > whiteCards.Validator.Priority
                ? string.Format("Black wins - {0}", blackCards.Validator.CardsType)
                : string.Format("White wins - {0}", whiteCards.Validator.CardsType);
        }
    }
}