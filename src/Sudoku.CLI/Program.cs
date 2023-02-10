using System;
using Sudoku.Core;

class Program
{
    public static void Main()
    {
        var b = new Board(2);

        b[0, 0] = 1;        
        b[0, 1] = 2;        
        b[1, 0] = 3;        
        b[1, 1] = 4;        
        b[3, 2] = 1;
        b[2, 3] = 3;

        b.printBoard();
    }    
}