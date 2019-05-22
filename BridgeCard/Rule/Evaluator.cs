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
                if (blackCards.Point == whiteCards.Point)
                {
                    return "Tie";
                }

                return blackCards.Point>whiteCards.Point
                    ? string.Format("{0} wins - {1}", blackCards.Role, blackCards.CardsType)
                    : string.Format("{0} wins - {1}", whiteCards.Role, blackCards.CardsType);
            }

            return blackCards.Priority > whiteCards.Priority
                ? string.Format("{0} wins - {1}", blackCards.Role, blackCards.CardsType)
                : string.Format("{0} wins - {1}", whiteCards.Role, whiteCards.CardsType);
        }
    }
}