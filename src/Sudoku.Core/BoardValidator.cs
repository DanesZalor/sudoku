using System.Runtime.CompilerServices;

namespace Sudoku.Core;

public static class BoardValidator
{
    public static BoardStatus Validate(this Board board)
    {

        for (int i = 0; i < board.Size; i++)
        {
            var rowContent = new List<byte>(board.Size);
            var columnContent = new List<byte>(board.Size);

            for (int j = 0; j < board.Size; j++)
            {
                if(board[i, j] != 0)
                {
                    if (!rowContent.Contains(board[i, j]))
                        rowContent.Add(board[i, j]);
                    else
                        return BoardStatus.Invalid;
                }

                if (board[j, i] != 0) 
                {
                    if (!columnContent.Contains(board[j, i]))
                        columnContent.Add(board[j, i]);
                    else
                        return BoardStatus.Invalid;
                }
            }
        }

        return board.IsFilled() ? BoardStatus.Complete : BoardStatus.Valid;
    }

    private static bool IsFilled(this Board board) 
    {
        for (int i = 0; i < board.Size; i++) 
        {
            for (int j = 0; j < board.Size; j++) 
            {
                if (board[i, j] == 0) return false;
            }
        }

        return true;
    }
}
