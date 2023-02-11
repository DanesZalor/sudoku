using Sudoku.Core;

namespace Sudoku.CLI;

internal class GameController
{
	private Sudoku.Core.Game _game;
	private GridPointer _gridPointer;

	public GameController(Game game, GridPointer gridPointer)
	{
		_game = game ?? throw new ArgumentNullException(nameof(game));
		_gridPointer = gridPointer ?? throw new ArgumentNullException(nameof(gridPointer));
	}

	public void Input() 
	{
		var keyInput = Console.ReadKey();

		if (char.IsDigit(keyInput.KeyChar))
		{
			_game.Set(_gridPointer.Vertical, _gridPointer.Horizontal, Convert.ToByte($"{keyInput.KeyChar}"));
		}
		else 
		{
            switch (keyInput.Key)
            {
                case ConsoleKey.Backspace:
                    _game.Set(_gridPointer.Vertical, _gridPointer.Horizontal, null);
                    break;
                case ConsoleKey.UpArrow:
                    _gridPointer.Vertical--;
                    break;
                case ConsoleKey.DownArrow:
                    _gridPointer.Vertical++;
                    break;
                case ConsoleKey.LeftArrow:
                    _gridPointer.Horizontal--;
                    break;
                case ConsoleKey.RightArrow:
                    _gridPointer.Horizontal++;
                    break;
            }
        }
    }
}
