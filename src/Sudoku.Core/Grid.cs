namespace Sudoku.Core;

public class Grid
{
    private byte[,] _matrix;
    public byte GridSize => (byte)(BlockSize * BlockSize);
    public byte BlockSize { get; private init; }

    public byte this[int vertical, int horizontal]
    {
        get => _matrix[vertical, horizontal];
        set 
        {
            if(value < 0 || value > GridSize)
            {
                throw new ArgumentException("value out of range");
            }

            _matrix[vertical, horizontal] = value;
        }
    }

    public Grid(int difficulty)
    {
        BlockSize = (byte)difficulty;

        _matrix = new byte[GridSize, GridSize];
    }

    public Grid(byte[,] matrix)
    {
        if (matrix.GetLength(0) != matrix.GetLength(1))
            throw new ArgumentException("matrix must be square length");

        var matrixLengthSqrt = Math.Sqrt(matrix.GetLength(0));
        if (matrixLengthSqrt % 1 != 0)
            throw new ArgumentException("matrix Length must be a perfect square");

        BlockSize = (byte)matrixLengthSqrt;

        _matrix = matrix;
    }

    public static implicit operator Grid(byte[,] matrix) 
    {
        return new Grid(matrix);
    }
}
