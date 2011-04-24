using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayingCards;

namespace Poker.Tests
{
    [TestClass]
    public class PokerHandInterpreterTest_Given_a_high_card_hand
    {
        [TestMethod]
        public void When_interpreted_Then_should_be_high_card()
        {
            IEnumerable<Card> cards = new List<Card>()
			{
				new Card(CardValue.Two, CardSuit.Heart),
                new Card(CardValue.Three, CardSuit.Spade),
                new Card(CardValue.Five, CardSuit.Spade),
                new Card(CardValue.Six, CardSuit.Spade),
                new Card(CardValue.Seven, CardSuit.Spade)
            };

            PokerHand pokerHand = PokerHandInterpreter.Interpret(cards);

            Assert.AreEqual(PokerHand.HighCard, pokerHand);
        }
    }

    [TestClass]
    public class PokerHandInterpreterTest_Given_a_pair_hand
    {
        [TestMethod]
        public void When_interpreted_Then_should_be_a_pair()
        {
            IEnumerable<Card> cards = new List<Card>()
			{
				new Card(CardValue.Two, CardSuit.Heart),
                new Card(CardValue.Two, CardSuit.Spade),
                new Card(CardValue.Five, CardSuit.Spade),
                new Card(CardValue.Six, CardSuit.Spade),
                new Card(CardValue.Seven, CardSuit.Spade)
            };

            PokerHand pokerHand = PokerHandInterpreter.Interpret(cards);

            Assert.AreEqual(PokerHand.Pair, pokerHand);
        }
    }

    [TestClass]
    public class PokerHandInterpreterTest_Given_a_two_pair_hand
    {
        [TestMethod]
        public void When_interpreted_Then_should_be_two_pair()
        {
            IEnumerable<Card> cards = new List<Card>()
			{
				new Card(CardValue.Two, CardSuit.Heart),
                new Card(CardValue.Two, CardSuit.Spade),
                new Card(CardValue.Five, CardSuit.Heart),
                new Card(CardValue.Five, CardSuit.Spade),
                new Card(CardValue.Seven, CardSuit.Spade)
            };

            PokerHand pokerHand = PokerHandInterpreter.Interpret(cards);

            Assert.AreEqual(PokerHand.TwoPair, pokerHand);
        }
    }

    [TestClass]
    public class PokerHandInterpreterTest_Given_a_three_of_a_kind_hand
    {
        [TestMethod]
        public void When_interpreted_Then_should_be_three_of_a_kind()
        {
            IEnumerable<Card> cards = new List<Card>()
			{
				new Card(CardValue.Two, CardSuit.Heart),
                new Card(CardValue.Two, CardSuit.Spade),
                new Card(CardValue.Two, CardSuit.Diamond),
                new Card(CardValue.Five, CardSuit.Spade),
                new Card(CardValue.Seven, CardSuit.Spade)
            };

            PokerHand pokerHand = PokerHandInterpreter.Interpret(cards);

            Assert.AreEqual(PokerHand.ThreeOfAKind, pokerHand);
        }
    }

    [TestClass]
    public class PokerHandInterpreterTest_Given_a_straight_hand
    {
        [TestMethod]
        public void When_interpreted_Then_should_be_a_straight()
        {
            IEnumerable<Card> cards = new List<Card>()
			{
				new Card(CardValue.Two, CardSuit.Heart),
                new Card(CardValue.Three, CardSuit.Spade),
                new Card(CardValue.Four, CardSuit.Diamond),
                new Card(CardValue.Five, CardSuit.Spade),
                new Card(CardValue.Six, CardSuit.Spade)
            };

            PokerHand pokerHand = PokerHandInterpreter.Interpret(cards);

            Assert.AreEqual(PokerHand.Straight, pokerHand);
        }
    }

    [TestClass]
    public class PokerHandInterpreterTest_Given_a_flush_hand
    {
        [TestMethod]
        public void When_interpreted_Then_should_be_a_flush()
        {
            IEnumerable<Card> cards = new List<Card>()
			{
				new Card(CardValue.Two, CardSuit.Spade),
                new Card(CardValue.Three, CardSuit.Spade),
                new Card(CardValue.Four, CardSuit.Spade),
                new Card(CardValue.Five, CardSuit.Spade),
                new Card(CardValue.Seven, CardSuit.Spade)
            };

            PokerHand pokerHand = PokerHandInterpreter.Interpret(cards);

            Assert.AreEqual(PokerHand.Flush, pokerHand);
        }
    }

    [TestClass]
    public class PokerHandInterpreterTest_Given_a_full_house_hand
    {
        [TestMethod]
        public void When_interpreted_Then_should_be_a_full_house()
        {
            IEnumerable<Card> cards = new List<Card>()
			{
				new Card(CardValue.Two, CardSuit.Spade),
                new Card(CardValue.Two, CardSuit.Heart),
                new Card(CardValue.Two, CardSuit.Diamond),
                new Card(CardValue.Three, CardSuit.Spade),
                new Card(CardValue.Three, CardSuit.Heart)
            };

            PokerHand pokerHand = PokerHandInterpreter.Interpret(cards);

            Assert.AreEqual(PokerHand.FullHouse, pokerHand);
        }
    }

    [TestClass]
    public class PokerHandInterpreterTest_Given_a_four_of_a_kind_hand
    {
        [TestMethod]
        public void When_interpreted_Then_should_be_a_full_house()
        {
            IEnumerable<Card> cards = new List<Card>()
			{
				new Card(CardValue.Two, CardSuit.Spade),
                new Card(CardValue.Two, CardSuit.Heart),
                new Card(CardValue.Two, CardSuit.Diamond),
                new Card(CardValue.Two, CardSuit.Club),
                new Card(CardValue.Three, CardSuit.Heart)
            };

            PokerHand pokerHand = PokerHandInterpreter.Interpret(cards);

            Assert.AreEqual(PokerHand.FourOfAKind, pokerHand);
        }
    }
}
