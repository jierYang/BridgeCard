using System;
using System.ComponentModel;

namespace BridgeCard
{
    public enum CardColor
    {
        Diamond = 'D',
        Spade = 'S',
        Heart = 'H',
        Club = 'C'
    }

    public static class ColorTypeProvider
    {
        public static CardColor GetColorType(char colorType)
        {
            try
            {
                return (CardColor) Enum.ToObject(typeof(CardColor), colorType);
            }
            
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}