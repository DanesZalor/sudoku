using System;
using Sudoku.CLI;
using Sudoku.Core;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    public static void Main()
    {

        //var service = new ServiceCollection()
        //    .AddTransient<GameController>()
        //    .AddTransient<GameView>()
        //    .AddTransient<Game>(s => new(2))
        //    .AddTransient<GridPointer>(s => new (2))
        //    .BuildServiceProvider();

        //var view = service.GetRequiredService<GameView>();
        //var controller = service.GetRequiredService<GameController>();
        //var game = service.GetRequiredService<Game>();

        int difficulty = 3;
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
