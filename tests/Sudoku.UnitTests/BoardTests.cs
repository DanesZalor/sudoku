using Sudoku.Core;

namespace Sudoku.UnitTests;

public class BoardTests
{
    public class Constructor_Should
    {
        [Fact]
        public void ThrowArgumentException_When_MatrixIsNotSquare() 
        {
            var act = () =>
            {
                Board b = new byte[2, 3];
            };

            var error = Assert.Throws<ArgumentException>(act);
            Assert.Equal("matrix must be square length", error.Message);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        public void ThrowArgumentException_When_MatrixLengthIsNotAPerfectSqrt(int matrixLength) 
        {
            var act = () =>
            {
                Board b = new byte[matrixLength, matrixLength];
            };

            var error = Assert.Throws<ArgumentException>(act);
            Assert.Equal("matrix Length must be a perfect square", error.Message);
        }

        [Fact]
        public void MapMatrix() 
        {
            Board board = new byte[,]
            {
                { 1, 2, 3, 4 },
                { 3, 4, 2, 1 },
                { 4, 3, 1, 2 },
                { 2, 1, 4, 3 },
            };

            Assert.Equal(1, board[0, 0]);
            Assert.Equal(2, board[0, 1]);
            Assert.Equal(3, board[0, 2]);
            Assert.Equal(4, board[0, 3]);

            Assert.Equal(3, board[1, 0]);
            Assert.Equal(4, board[1, 1]);
            Assert.Equal(2, board[1, 2]);
            Assert.Equal(1, board[1, 3]);
        }
    }

    public class Index_Should
    {
        [Theory]
        [InlineData(2, 5)]
        [InlineData(3, 11)]
        [InlineData(2, 0)]
        public void ThrowArgumentException_When_AssigningInvalidValue(
            int size, byte value)
        {
            var act = () =>
            {
                var board = new Board(size);
                board[0, 0] = value;
            };

            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(0, 2, 4)]
        [InlineData(0, 3, 2)]
        public void AssignValuesCorrectly(int row, int column, byte value)
        {
            var board = new Board(2);
            board[row, column] = value;
            Assert.Equal(board[row, column], value);
        }
    }

    public class Validate_Should 
    {
        
    }
}