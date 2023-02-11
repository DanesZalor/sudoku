﻿using System.Runtime.CompilerServices;

namespace Sudoku.Core;

public static class BoardValidator
{
    public static BoardStatus Validate(this Board board)
    {
        // check horizontal and vertical collisions
        // O(nSize^2)
        for (int i = 0; i < board.GridSize; i++)
        {
            var rowContent = new List<byte>(board.GridSize);
            var columnContent = new List<byte>(board.GridSize);

            for (int j = 0; j < board.GridSize; j++)
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

        // check block collisions
        for(int blockY = 0; blockY < board.BlockSize; blockY+= board.GridSize)
        {
            for(int blockX = 0; blockX < board.BlockSize; blockX+= board.GridSize)
            {
                var blockContent = new List<int>(board.GridSize);

                for(int y = 0; y < board.BlockSize; y++)
                {
                    for(int x = 0; x < board.BlockSize; x++)
                    {
                        var current = board[blockY + y, blockX + x];

                        if(current == 0) continue;

                        if(!blockContent.Contains(current))
                            blockContent.Add(current);
                        else
                            return BoardStatus.Invalid;
                    }
                }
            }
        }

        return board.IsFilled() ? BoardStatus.Complete : BoardStatus.Valid;
    }

    private static bool IsFilled(this Board board) 
    {
        for (int i = 0; i < board.GridSize; i++) 
        {
            for (int j = 0; j < board.GridSize; j++) 
            {
                if (board[i, j] == 0) return false;
            }
        }

        return true;
    }
}
