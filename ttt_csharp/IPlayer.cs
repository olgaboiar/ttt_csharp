namespace ttt_csharp
{
    public interface IPlayer
    {
        void Move(Board board);
        char GetMarker();
    }
}