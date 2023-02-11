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

        for (int i = 0; i < _game.GridSize; i++)
        {
            for (int j = 0; j < _game.GridSize; j++)
            {
                var isPointed = _gridPointer.Vertical == i && _gridPointer.Horizontal == j;
                Console.BackgroundColor = isPointed ? ConsoleColor.White : ConsoleColor.Black;
                Console.ForegroundColor = !isPointed ? ConsoleColor.White : ConsoleColor.Black;

                var current = _game.Get(i, j);
                
                var cellOutput = current == null ? "_" : $"{current}";
                
                Console.Write($" {cellOutput} ");
            }

            Console.WriteLine();
        }
    }
}
