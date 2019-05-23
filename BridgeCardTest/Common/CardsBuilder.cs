using BridgeCard;

namespace BridgeCardTest.Common
{
    public static class CardsBuilder
    {
        public static HandCards CreateStraightFlushHandCards()
        {
            return new HandCards("2D 3D 6D 4D 5D");
        }

        public static HandCards CreateHighCardHandCards()
        {
            return new HandCards("2D 3D 7S 4H 5C");
        }

        public static HandCards CreateFourOfAKindHandCards()
        {
            return new HandCards("2A 3A 3D 3A 3A");
        }

        public static HandCards CreateFullHouseHandCards()
        {
            return new HandCards("2A 3H 3D 3A 2C");
        }

        public static HandCards CreateFlushHandCards()
        {
            return new HandCards("2A 3A 7A 8A TA");
        }
    }
}