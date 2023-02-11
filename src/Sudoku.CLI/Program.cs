using System;
using Sudoku.CLI;
using Sudoku.Core;

public class Program
{
    public static void Main()
    {
        int difficulty = 2;
        var game = new Game(difficulty);
        var pointer = new GridPointer(difficulty);
        var view = new GameView(game, pointer);
        var controller = new GameController(game, pointer);

        while (game.Status != GridStatus.Complete) 
        {
            view.Show();
            controller.Input();
            Console.Clear();
        }
    }    
}
