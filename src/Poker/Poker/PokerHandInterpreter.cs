using System.Collections.Generic;
using System.Linq;
using PlayingCards;

namespace Poker
{
    public static class PokerHandInterpreter
    {
        public static PokerHand Interpret(IEnumerable<Card> cards)
        {
            if(IsARoyalFlush(cards))
                return PokerHand.RoyalFlush;
            else if(IsAFlush(cards) && IsAStraight(cards))
                return PokerHand.StraightFlush;
            else if(HasAFourOfAKind(cards))
                return PokerHand.FourOfAKind;
            else if(IsFullHouse(cards))
                return PokerHand.FullHouse;
            else if(IsAFlush(cards))
                return PokerHand.Flush;
            else if(IsAStraight(cards))
                return PokerHand.Straight;
            else if(HasAThreeOfAKind(cards))
                return PokerHand.ThreeOfAKind;
            else if(HasTwoPairs(cards))
                return PokerHand.TwoPair;
            else if(HasAPair(cards))
                return PokerHand.Pair;
            else
                return PokerHand.HighCard;
        }

        private static bool IsARoyalFlush(IEnumerable<Card> cards)
        {
            return IsAFlush(cards) && IsAStraight(cards) && cards.Count(c => c.Value.Equals(CardValue.Ten)) == 1 && cards.Count(c => c.Value.Equals(CardValue.Ace)) == 1;
        }

        private static bool HasAFourOfAKind(IEnumerable<Card> cards)
        {
            return GetSameCardValues(4, cards).Count() > 0;
        }

        private static bool IsFullHouse(IEnumerable<Card> cards)
        {
            return GetSameCardValues(3, cards).Count() > 0 && GetSameCardValues(2, cards).Count() > 0;
        }

        private static bool IsAFlush(IEnumerable<Card> cards)
        {
            CardSuit referenceSuit = cards.First().Suit;

            foreach(var card in cards)
            {
                if(!referenceSuit.Equals(card.Suit))
                    return false;
            }
            return true;
        }

        private static bool IsAStraight(IEnumerable<Card> cards)
        {
            int consecutiveCount = 0;

            if(cards.Count(c => c.Value.Equals(CardValue.Ace)) == 1 &&
                cards.Count(c => c.Value.Equals(CardValue.Two)) == 1)
                consecutiveCount++;
            for(int i = (int)CardValue.Two; i <= (int)CardValue.King; i++)
            {
                if(cards.Count(c => (int)c.Value == i) > 1)
                    return false;
                else if(cards.Count(c => (int)c.Value == i) == 1)
                    consecutiveCount++;
                else if(consecutiveCount > 1)
                    break;
            }

            if(cards.Count(c => c.Value.Equals(CardValue.King)) == 1 &&
                cards.Count(c => c.Value.Equals(CardValue.Ace)) == 1)
                consecutiveCount++;

            return consecutiveCount == cards.Count();
        }

        private static bool HasAThreeOfAKind(IEnumerable<Card> cards)
        {
            return GetSameCardValues(3, cards).Count() > 0;
        }

        private static CardValue[] GetSameCardValues(int numberOfSameCardValue, IEnumerable<Card> cards)
        {
            List<CardValue> cardValues = new List<CardValue>();

            foreach(var cardValueCountItem in GetCardValueCount(cards))
            {
                if(cardValueCountItem.Value == numberOfSameCardValue)
                    cardValues.Add(cardValueCountItem.Key);
            }

            return cardValues.ToArray();
        }

        private static bool HasTwoPairs(IEnumerable<Card> cards)
        {
            return GetSameCardValues(2, cards).Count() == 2;
        }

        private static Dictionary<CardValue, int> GetCardValueCount(IEnumerable<Card> cards)
        {
            Dictionary<CardValue, int> valueCount = new Dictionary<CardValue, int>();

            foreach(var card in cards)
            {
                valueCount[card.Value] = valueCount.ContainsKey(card.Value) ? valueCount[card.Value] + 1 : 1;
            }

            return valueCount;
        }

        private static bool HasAPair(IEnumerable<Card> cards)
        {
            return GetSameCardValues(2, cards).Count() > 0;
        }

    }
}
