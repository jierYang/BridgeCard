using System;
using System.ComponentModel;

namespace BridgeCard
{
    public enum ColorType
    {
        Diamond = 'D',
        Spade = 'S',
        Heart = 'H',
        Club = 'C'
    }

    public static class ColorTypes
    {
        public static ColorType GetColorType(char colorType)
        {
            try
            {
                return (ColorType) Enum.ToObject(typeof(ColorType), colorType);
            }
            
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}