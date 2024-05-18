using Serilog;
using Shared.Interfaces;
#nullable disable

namespace DisplayScreen.CommandHandler
{
    public class RequestHandler
    {
        public void Handle(ICommand command)
        {
            command.Execute();

            Log.Information($"Command: {command.GetType().Name}");
        }
    }
}
