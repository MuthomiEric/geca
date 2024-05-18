using Shared.Models;

namespace Geca.Tests.Setup
{
    internal static class MapExtension
    {
        public static char[,] InitializeMap(int row, int col)
        {
            // Create a random number generator
            Random random = new Random();

            // Define the characters that can be used in the pattern. More '*' than other characters to have more empty squares
            char[] characters = { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '#', '#', 'B' };

            var patternArray = new char[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    // Generate a random index to choose a character from the characters array
                    int randomIndex = random.Next(characters.Length);

                    // Assign the randomly chosen character to the array element
                    patternArray[i, j] = characters[randomIndex];
                }
            }

            patternArray[29, 0] = 'S';
            patternArray[29, 0] = 'T';
            patternArray[29, 0] = 'H';

            return patternArray;

        }
    }
}
