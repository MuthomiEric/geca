using Shared.Commands.Action;
using Shared.Commands.Direction;
using Shared.Interfaces;

namespace InputScreen.Helpers
{
    internal static class CommandBuilder
    {
        public static ICommand? BuildAction(string input)
        {
            switch (input.Trim().Replace(" ", string.Empty).ToLower())
            {
                case "grow":
                    return new GrowCommand();
                case "shrink":
                    return new ShrinkCommand();
                case "undo":
                    return new UndoCommand();
                case "redo":
                    return new RedoCommand();
            }
            return null;
        }

        public static ICommand? BuildDirection(char direction, int steps)
        {
            switch (direction)
            {
                case 'u':
                    return new UpCommand(steps);
                case 'd':
                    return new DownCommand(steps);
                case 'l':
                    return new LeftCommand(steps);
                case 'r':
                    return new RightCommand(steps);
            }
            return default;
        }
    }
}
