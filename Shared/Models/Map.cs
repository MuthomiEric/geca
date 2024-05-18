namespace Shared.Models;
public class Map
{
    private readonly int _rows;
    private readonly int _columns;
    public Map(int rows, int columns)
    {
        _rows = rows;
        _columns = columns;
    }
    public char[,] InitializeMap()
    {
        // Create a random number generator
        Random random = new Random();

        // Define the characters that can be used in the pattern. More '*' than other characters to have more empty squares
        char[] characters = { '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '*', '#', '#', 'B' };

        var patternArray = new char[_rows, _columns];

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < _columns; j++)
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

    public static void Print(char[,] array)
    {
        Console.Clear();

        int rows = array.GetLength(0);

        int columns = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(array[i, j]);
            }
            Console.WriteLine();
        }
    }
}