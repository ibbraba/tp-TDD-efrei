using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Poker_console
{
    public class Deck
    {
        private readonly List<Card> _cards;

        public Deck()
        {
            _cards = CreateDeck();
        }

        private List<Card> CreateDeck()
        {
            return Enum.GetValues<Suit>()
                .SelectMany(suit =>
                    Enum.GetValues<Rank>()
                        .Select(rank => new Card(suit, rank)))
                .ToList();
        }

        public Card Draw()
        {
            if (!_cards.Any())
                throw new InvalidOperationException("Deck is empty.");

            var card = _cards.First();
            _cards.RemoveAt(0);

            return card;
        }

        public void ShuffleCards()
        {
            // NEED TO TEST THIS METHOD
            var rng = new Random();
            int n = _cards.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (_cards[k], _cards[n]) = (_cards[n], _cards[k]);
            }
        }

        public int Count => _cards.Count;
    }
}