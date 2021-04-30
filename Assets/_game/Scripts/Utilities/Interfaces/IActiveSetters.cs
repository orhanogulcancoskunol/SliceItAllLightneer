namespace _game.Scripts.Utilities.Interfaces
{
    public interface IActiveSetters
    {
        bool IsActive { get; set; }

        void SetEnabled();

        void SetDisabled();
    }
}
