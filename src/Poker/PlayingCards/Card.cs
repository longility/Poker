
namespace PlayingCards
{
    public class Card
    {
        private readonly CardSuit suit;
        private readonly CardValue value;

        public CardSuit Suit { get { return suit; } }
        public CardValue Value { get { return value; } }

        public Card(CardValue value, CardSuit suit)
        {
            this.suit = suit;
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            if(!(obj is Card))
                return false;
            Card otherCard = obj as Card;
            return this.Suit.Equals(otherCard.Suit) && this.Value.Equals(otherCard.Value);
        }

        public override int GetHashCode()
        {
            return (int)suit * 100 + (int)value * 10000;
        }
    }

    public enum CardSuit
    {
        Club,
        Diamond,
        Heart,
        Spade
    }

    public enum CardValue
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

}
