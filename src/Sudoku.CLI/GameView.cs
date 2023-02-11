using Sudoku.Core;

namespace Sudoku.CLI;

internal class GameView
{
    private Sudoku.Core.Game _game;
    private GridPointer _gridPointer;

    public GameView(Game game, GridPointer gridPointer)
    {
        _game = game ?? throw new ArgumentNullException(nameof(game));
        _gridPointer = gridPointer ?? throw new ArgumentNullException(nameof(gridPointer));
    }

    public void Show() 
    {
        Console.WriteLine($"┌{new string('─', _game.GridSize*3)}┐");
        for (int i = 0; i < _game.GridSize; i++)
        {
            Console.Write("│");
            for (int j = 0; j < _game.GridSize; j++)
            {
                var isPointed = _gridPointer.Vertical == i && _gridPointer.Horizontal == j;

                Console.BackgroundColor = isPointed ? ConsoleColor.White : ConsoleColor.Black;
                Console.ForegroundColor = !isPointed ? ConsoleColor.White : ConsoleColor.Black;

                var current = _game.Get(i, j);
                
                Console.Write(current == null ? " . " : $" {current} ");
            }

            Console.WriteLine("│ ");
        }
        Console.WriteLine($"└{new string('─', _game.GridSize * 3)}┘");
        Console.WriteLine($"Status:{_game.Status}");
    }
}
