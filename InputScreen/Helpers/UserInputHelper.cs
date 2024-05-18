
using Shared.Interfaces;

namespace InputScreen.Helpers
{
    internal static class UserInputHelper
    {
        public static ICommand GetInput(string? input)
        {
            bool isSuccess = false;

            var result = VerifyInput(input, ref isSuccess);

            while (!isSuccess)
            {
                Console.WriteLine($"Invalid !! please enter direction again:");

                VerifyInput(Console.ReadLine(), ref isSuccess);
            }

            return result!;
        }

        private static ICommand? VerifyInput(string? input, ref bool isSuccess)
        {
            if (string.IsNullOrEmpty(input))
            {
                isSuccess = false;

                return default;
            }

            var modifiedInput = input.Trim().Replace(" ", string.Empty).ToLower();

            switch (modifiedInput)
            {
                case "grow":
                case "shrink":
                case "undo":
                case "redo":
                    return GetAction(ref isSuccess, modifiedInput);
                default:
                    var otherDirections = new List<char> { 'u', 'd', 'l', 'r' };

                    var inputArr = modifiedInput.ToCharArray();

                    var direction = inputArr[0];

                    if (!otherDirections.Contains(direction))
                    {
                        isSuccess = false;

                        return default;
                    }

                    isSuccess = int.TryParse(inputArr[1].ToString(), out int steps);

                    if (isSuccess)
                    {
                        var directionResult = CommandBuilder.BuildDirection(direction, steps);

                        if (directionResult is null)
                        {
                            isSuccess = false;

                            return default;
                        }

                        isSuccess = true;

                        return directionResult;
                    }
                    break;
            }

            return default;
        }

        private static ICommand? GetAction(ref bool isSuccess, string modifiedInput)
        {
            var actionResult = CommandBuilder.BuildAction(modifiedInput);

            if (actionResult is null)
            {
                isSuccess = false;

                return default;
            }

            isSuccess = true;

            return actionResult;
        }
    }
}
