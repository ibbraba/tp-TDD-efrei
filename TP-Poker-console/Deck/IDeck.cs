namespace TP_Poker_console.Deck
{
    public interface IDeck
    {
        int Count { get; }

        Card Draw();

        void ShuffleCards();
    }
}