namespace Player
{
    public interface IEntityInputSource
    {
        float Direction { get; }
        bool Jump { get; } 
        void ResetOneTimeActions();
    }
}