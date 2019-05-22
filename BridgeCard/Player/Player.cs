namespace BridgeCard.Player
{
    public class Player
    {
        public HandCards HandCards;

        public Role Role;

        public Player(HandCards handCards, Role role)
        {
            HandCards = handCards;
            
            Role = role;
        }
    }
}