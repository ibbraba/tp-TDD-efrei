namespace TP_Poker_console
{
    public interface IDeck
    {
        int Count { get; }

        Card Draw();
        void ShuffleCards();
    }
}