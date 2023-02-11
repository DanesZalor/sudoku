namespace Sudoku.Core;

public class Game
{
    private Grid _grid;

    public GridStatus Status => _grid.Validate();
    public byte Difficulty => _grid.BlockSize;
    public byte GridSize => _grid.GridSize;

    public Game(int difficulty)
    {
        _grid = new Grid(difficulty);
    }

    public byte? Get(int vertical, int horizontal) 
    {
        var val = _grid[vertical, horizontal];
        return val != 0 ? val : null;
    }

    public void Set(int vertical, int horizontal, byte? value) 
    {
        _grid[vertical, horizontal] = value ?? 0;
    }
}
