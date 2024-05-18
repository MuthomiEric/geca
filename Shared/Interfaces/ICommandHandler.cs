namespace Shared.Interfaces
{
    public interface ICommandHandler
    {
        void Handle(ICommand command);
    }
}
