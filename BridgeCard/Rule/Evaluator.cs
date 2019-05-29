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

        public GameResult EvaluateCardsWinner(HandCards blackHandCards, HandCards whiteHandCards)
        {
            var blackCardsType = blackHandCards.GetCardsType(_validators);

            var whiteCardType = whiteHandCards.GetCardsType(_validators);

            if (blackCardsType.Priority.Equals(whiteCardType.Priority))
            {
                if (blackHandCards.IsSameCardsNumber(whiteHandCards))
                {
                    return GameResult.Tie;
                }

                return blackCardsType.IsBlackCardsBiggerThanWhiteCards(blackHandCards, whiteHandCards)
                    ? GameResult.BlackWin
                    : GameResult.WhiteWin;
            }

            return blackCardsType.Priority > whiteCardType.Priority
                ? GameResult.BlackWin
                : GameResult.WhiteWin;
        }
    }
}