namespace Sudoku.CLI;

internal class GridPointer
{
    int _bound { get; init; }
    
    int _vertical, _horizontal;

    public sbyte Vertical 
    {
        get => (sbyte)_vertical;
        set => _vertical = Math.Clamp(value, 0, _bound);
    }

    public sbyte Horizontal
    {
        get => (sbyte)_horizontal;
        set => _horizontal = Math.Clamp(value, 0, _bound);
    }

    public GridPointer(int bound)
    {
        _bound = bound*bound - 1;
    }
}
