using System.Data.Common;

namespace FemmeFataleCode;

public class TetrisGame
{
    private readonly int[,] grid;
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public int this[int r, int c]
    {
        get => grid[r, c];
        set => grid[r, c] = value;

    }

    public TetrisGame(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        grid = new int[Rows, Columns];
    }

    public bool IsInside(int r, int c)
    {
        return r >= 0 && r < Rows && c >= 0 && c < Columns;
    }

    public bool IsEmpty(int r, int c)
    {
        return IsInside(r, c) && grid[r, c] == 0;
    }

    public bool IsRowFull(int r)
    {
        for (int c = 0; c < Columns; c++)
        {
            if (grid[r, c] == 0)
            {
                return false;
            }
        }

        return true;

    }

    public bool IsRowEmpty(int r)
    {
        for (int c = 0; c < Columns; c++)
        {
            if (grid[r, c] != 0)
            {
                return false;
            }
        }

        return true;
    }


    private void ClearRow(int r)
    {
        for (int c = 0; c < Columns; c++)
        {
            grid[r, c] = 0;
        }
    }

    private void MoveRowDown(int r, int numRows)
    {
        for (int c = 0; c < Columns; c++)
        {
            grid[r + numRows, c] = grid[r, c];
        }
    }

    public int ClearFullRows()
    {
        int cleared = 0;
        for (int r = Rows - 1; r >= 0; r--)
        {
            if (IsRowFull(r))
            {
                ClearRow(r);
                cleared++;
            }
            else if (cleared > 0)
            {
                MoveRowDown(r, cleared);
            }
        }
        return cleared;
    }

   

}

