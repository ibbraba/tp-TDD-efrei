using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_Poker_console.Deck.Utils;
using TP_Poker_console.HandResults.Utils;

namespace TP_Poker_console.HandResults
{
    public class HandResult : IComparable<HandResult>
    {
        public HandCategory Category { get; set; }
        public List<Rank> RankedCards { get; set; } = new();

        // Compare two hands
        public int CompareTo(HandResult? other)
        {
            if (other == null) return 1;

            // Compare hand category first
            int categoryComparison = Category.CompareTo(other.Category);
            if (categoryComparison != 0) return categoryComparison;

            // Compare card ranks in order
            for (int i = 0; i < Math.Min(RankedCards.Count, other.RankedCards.Count); i++)
            {
                if (RankedCards[i] > other.RankedCards[i]) return 1;
                if (RankedCards[i] < other.RankedCards[i]) return -1;
            }

            return 0; // Tie
        }
    }
}