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
                Grid b = new byte[2, 3];
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
                Grid b = new byte[matrixLength, matrixLength];
            };

            var error = Assert.Throws<ArgumentException>(act);
            Assert.Equal("matrix Length must be a perfect square", error.Message);
        }

        [Fact]
        public void MapMatrix() 
        {
            Grid board = new byte[,]
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
                var board = new Grid(size);
                board[0, 0] = value;
            };

            var error = Assert.Throws<ArgumentException>(act);
            Assert.Equal("value out of range", error.Message);
        }

        [Theory]
        [InlineData(2, 2, 1)]
        [InlineData(0, 2, 4)]
        [InlineData(0, 3, 2)]
        public void AssignValuesCorrectly(int row, int column, byte value)
        {
            var board = new Grid(4);
            board[row, column] = value;
            Assert.Equal(board[row, column], value);
        }
    }

    public class Validate_Should 
    {
        [Fact]
        public void ReturnComplete_When_BoardHasNoCollisionAndIsFilled() 
        {
            Grid board = new byte[,]
            {
                { 1, 2, 3, 4 },
                { 3, 4, 2, 1 },
                { 4, 3, 1, 2 },
                { 2, 1, 4, 3 },
            };

            Assert.Equal(GridStatus.Complete, board.Validate());
        }

        [Fact]
        public void ReturnValid_When_BoardHasNoCollisions() 
        {
            Grid board = new byte[,]
            {
                { 1, 2, 0, 4 },
                { 3, 0, 2, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 4, 0 },
            };

            Assert.Equal(GridStatus.Valid, board.Validate());
        }

        [Fact]
        public void ReturnInvalid_When_BoardHasColumnCollisions() 
        {
            Grid board = new byte[,]
            {
                { 1, 2, 0, 0 },
                { 3, 0, 4, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 4, 0 },
            };

            Assert.Equal(GridStatus.Invalid, board.Validate());
        }

        [Fact]
        public void ReturnInvalid_When_BoardHasRowCollisions()
        {
            Grid board = new byte[,]
            {
                { 1, 2, 0, 0 },
                { 3, 0, 4, 0 },
                { 2, 0, 2, 0 },
                { 0, 0, 4, 0 },
            };

            Assert.Equal(GridStatus.Invalid, board.Validate());
        }

        [Fact]
        public void ReturnInvalid_When_BoardHasCellCollisions()
        {
            Grid board = new byte[,]
            {
                { 1, 2, 0, 4 },
                { 3, 1, 2, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 4, 0 },
            };

            Assert.Equal(GridStatus.Invalid, board.Validate());
        }
        [Fact]
        public void ReturnInvalid_When_BoardHasCellCollisions2()
        {
            Grid board = new byte[,]
            {
                { 1, 2, 0,  4, 0, 0,  0, 9, 0 },
                { 0, 0, 0,  0, 0, 0,  0, 0, 0 },
                { 0, 0, 2,  0, 0, 0,  0, 0, 0 },

                { 0, 0, 0,  0, 0, 0,  0, 0, 0 },
                { 0, 0, 0,  0, 0, 0,  0, 0, 0 },
                { 0, 0, 0,  0, 0, 0,  0, 0, 0 },
                
                { 0, 0, 0,  0, 0, 0,  0, 0, 0 },
                { 0, 0, 0,  0, 0, 0,  0, 0, 0 },
                { 0, 0, 0,  0, 0, 0,  0, 0, 0 },
            };

            Assert.Equal(GridStatus.Invalid, board.Validate());
        }
    }
}