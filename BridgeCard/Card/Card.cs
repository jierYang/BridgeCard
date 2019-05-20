namespace BridgeCard
{
    public class Card
    {
        public ColorType ColorType { get; set; }

        public char Number { get; set; }

        public Card(char number, ColorType colorType)
        {
            ColorType = colorType;

            Number = number;
        }
    }
}