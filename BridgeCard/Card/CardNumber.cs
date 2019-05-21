using System.Collections.Generic;

namespace BridgeCard
{
    public class CardNumber
    {
        public CardNumber(char number)
        {
            Number = number;
        }

        public char Number { get; set; }
          
        public int GetNumber()
        {
            return NumbersProvider.Numbers[Number];
        }
    }

    public static class NumbersProvider
    {
        public static readonly IDictionary<char, int> Numbers = new Dictionary<char, int>
        {
            {'2', 2},
            {'3', 3},
            {'4', 4},
            {'5', 5},
            {'6', 6},
            {'7', 7},
            {'8', 8},
            {'9', 9},
            {'T', 10},
            {'J', 11},
            {'Q', 12},
            {'K', 13},
            {'A', 14}
        };
    }
}