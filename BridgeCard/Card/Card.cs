namespace BridgeCard
{
    public class Card
    {
        public CardColor CardColor { get; private set; }

        public CardNumber CardNumber { get; private set; }

        public Card(char cardNumber, char cardColor)
        {
            CardColor = ColorTypeProvider.GetColorType(cardColor);

            CardNumber = new CardNumber(cardNumber);
        }
    }
}