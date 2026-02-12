using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Poker_console.Deck.Utils;
using TP_Poker_console.Deck;

namespace TP_Poker_console
{
    public static class PokerHandEvaluator
    {
        public static HandResult EvaluateHand(List<Card> playerCards, List<Card> communityCards)
        {
            var allCards = playerCards.Concat(communityCards).ToList();

            if (TryGetStraightFlush(allCards, out var sf))
                return new HandResult { Category = HandCategory.StraightFlush, RankedCards = sf };

            if (TryGetFourOfAKind(allCards, out var four))
                return new HandResult { Category = HandCategory.FourOfAKind, RankedCards = four };

            if (TryGetFullHouse(allCards, out var fullHouse))
                return new HandResult { Category = HandCategory.FullHouse, RankedCards = fullHouse };

            if (TryGetFlush(allCards, out var flush))
                return new HandResult
                {
                    Category = HandCategory.Flush,
                    RankedCards = flush.Select(c => c.Rank).ToList()
                };

            if (TryGetStraight(allCards, out var straight))
                return new HandResult { Category = HandCategory.Straight, RankedCards = straight };

            if (TryGetThreeOfAKind(allCards, out var three))
                return new HandResult { Category = HandCategory.ThreeOfAKind, RankedCards = three };

            if (TryGetTwoPair(allCards, out var twoPair))
                return new HandResult { Category = HandCategory.TwoPair, RankedCards = twoPair };

            if (TryGetOnePair(allCards, out var pair))
                return new HandResult { Category = HandCategory.OnePair, RankedCards = pair };

            var highCards = allCards
                .OrderByDescending(c => c.Rank)
                .Take(5)
                .Select(c => c.Rank)
                .ToList();

            return new HandResult { Category = HandCategory.HighCard, RankedCards = highCards };
        }

        #region Helper Methods

        private static bool TryGetFlush(List<Card> cards, out List<Card> result)
        {
            result = new List<Card>();
            var flush = cards.GroupBy(c => c.Suit)
                             .Where(g => g.Count() >= 5)
                             .OrderByDescending(g => g.Key)
                             .FirstOrDefault();
            if (flush != null)
            {
                result = flush.OrderByDescending(c => c.Rank).Take(5).ToList();
                return true;
            }
            return false;
        }

        private static bool TryGetStraightFlush(List<Card> cards, out List<Rank> result)
        {
            result = new List<Rank>();
            if (TryGetFlush(cards, out var flushCards) && TryGetStraight(flushCards, out var straight))
            {
                result = straight;
                return true;
            }
            return false;
        }

        private static bool TryGetFourOfAKind(List<Card> cards, out List<Rank> result)
        {
            result = new List<Rank>();
            var quad = cards.GroupBy(c => c.Rank)
                            .Where(g => g.Count() == 4)
                            .OrderByDescending(g => g.Key)
                            .FirstOrDefault();
            if (quad != null)
            {
                result.Add(quad.Key);
                var kicker = cards.Where(c => c.Rank != quad.Key).Max(c => c.Rank);
                result.Add(kicker);
                return true;
            }
            return false;
        }

        private static bool TryGetFullHouse(List<Card> cards, out List<Rank> result)
        {
            result = new List<Rank>();
            var groups = cards.GroupBy(c => c.Rank).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).ToList();
            var three = groups.FirstOrDefault(g => g.Count() >= 3);
            var pair = groups.FirstOrDefault(g => g.Count() >= 2 && g.Key != three?.Key);

            if (three != null && pair != null)
            {
                result.Add(three.Key);
                result.Add(pair.Key);
                return true;
            }

            return false;
        }

        private static bool TryGetStraight(List<Card> cards, out List<Rank> result)
        {
            result = new List<Rank>();

            // Distinct ranks, descending order
            var distinctRanks = cards.Select(c => c.Rank).Distinct().OrderByDescending(r => r).ToList();

            // Ace-low straight support: if Ace exists, treat it as 1
            if (distinctRanks.Contains(Rank.Ace))
            {
                distinctRanks.Add((Rank)1); // cast 1 as Rank
            }

            // Check for any 5 consecutive ranks
            for (int i = 0; i <= distinctRanks.Count - 5; i++)
            {
                bool isStraight = true;
                for (int j = 0; j < 4; j++)
                {
                    if ((int)distinctRanks[i + j] - 1 != (int)distinctRanks[i + j + 1])
                    {
                        isStraight = false;
                        break;
                    }
                }

                if (isStraight)
                {
                    result = distinctRanks.Skip(i).Take(5).Select(r => r == (Rank)1 ? Rank.Ace : r).ToList();
                    return true;
                }
            }

            return false;
        }

        private static bool TryGetThreeOfAKind(List<Card> cards, out List<Rank> result)
        {
            result = new List<Rank>();
            var three = cards.GroupBy(c => c.Rank)
                             .Where(g => g.Count() == 3)
                             .OrderByDescending(g => g.Key)
                             .FirstOrDefault();
            if (three != null)
            {
                result.Add(three.Key); // The triple
                                       // Kickers: 2 highest remaining cards
                var kickers = cards.Where(c => c.Rank != three.Key)
                                   .OrderByDescending(c => c.Rank)
                                   .Take(2)
                                   .Select(c => c.Rank)
                                   .ToList();
                result.AddRange(kickers);
                return true;
            }
            return false;
        }

        private static bool TryGetTwoPair(List<Card> cards, out List<Rank> result)
        {
            result = new List<Rank>();
            var pairs = cards.GroupBy(c => c.Rank)
                             .Where(g => g.Count() >= 2)
                             .OrderByDescending(g => g.Key)
                             .Take(2)
                             .Select(g => g.Key)
                             .ToList();
            if (pairs.Count == 2)
            {
                result.AddRange(pairs);
                var kicker = cards.Where(c => !pairs.Contains(c.Rank)).Max(c => c.Rank);
                result.Add(kicker);
                return true;
            }
            return false;
        }

        private static bool TryGetOnePair(List<Card> cards, out List<Rank> result)
        {
            result = new List<Rank>();
            var pair = cards.GroupBy(c => c.Rank).Where(g => g.Count() == 2).OrderByDescending(g => g.Key).FirstOrDefault();
            if (pair != null)
            {
                result.Add(pair.Key);
                var kickers = cards.Where(c => c.Rank != pair.Key).OrderByDescending(c => c.Rank).Take(3).Select(c => c.Rank);
                result.AddRange(kickers);
                return true;
            }
            return false;
        }

        #endregion Helper Methods
    }
}