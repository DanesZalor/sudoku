namespace Sudoku.Core;

public class Board
{
    private byte[,] _matrix;
    public int Size => (Difficulty * Difficulty);
    public byte Difficulty { get; private init; }

    public byte this[int vertical, int horizontal]
    {
        get => _matrix[vertical, horizontal];
        set 
        {
            if(value < 1 || value > Size)
            {
                throw new ArgumentException("value out of range");
            }

            _matrix[vertical, horizontal] = value;
        }
    }

    public Board(int difficulty)
    {
        Difficulty = (byte)difficulty;

        _matrix = new byte[Size, Size];
    }

    public Board(byte[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new ArgumentException("matrix must be square length");

        var matrixLengthSqrt = Math.Sqrt(matrix.GetLength(0));
        if (matrixLengthSqrt % 1 != 0)
            throw new ArgumentException("matrix Length must be a perfect square");

        Difficulty = (byte)matrixLengthSqrt;

        _matrix = matrix;
    }

    public static implicit operator Board(byte[,] matrix) 
    {
        return new Board(matrix);
    }
    
    public void printBoard()
    {
        for(int i = 0; i < _matrix.GetLength(0); i++)
        {
            for(int j = 0; j < _matrix.GetLength(1); j++)
            {
                Console.Write($" {_matrix[i,j]}");
            }
            Console.WriteLine();
        }
    }
}
