using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BridgeCard.Rule
{
    public class Evaluator : IEvaluator
    {
        private readonly IList<IValidator> _validators;

        public Evaluator(IList<IValidator> validators)
        {
            _validators = validators.OrderByDescending(x => x.Priority).ToList();
        }

        public string EvaluateCardsWinner(IList<Card> blackCards, IList<Card> whiteCards)
        {
            var blackValidator = _validators.First(x => x.IsSatisfied(blackCards));

            var whiteValidator = _validators.First(x => x.IsSatisfied(whiteCards));

            if (blackValidator.Priority.Equals(whiteValidator.Priority))
            {
                var compareCards = blackValidator.CompareCards(blackCards, whiteCards);

                return compareCards.Equals("Tie")
                    ? "Tie"
                    : string.Format("{0} - {1}", compareCards, blackValidator.CardsType);
            }

            return blackValidator.Priority > whiteValidator.Priority
                ? string.Format("Black wins - {0}", blackValidator.CardsType)
                : string.Format("Black wins - {0}", whiteValidator.CardsType);
        }
    }
}