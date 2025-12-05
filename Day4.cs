using System;

const string fileName = @"inputs\day4.txt";
var lines = File.ReadLines(fileName);

int[,] grid = new int[lines.Count(), lines.First().Length];

foreach (var line in lines.Select((value, index) => new { value, index }))
{
    for (int i = 0; i < line.value.Length; i++)
    {
        if (line.value[i] == '.')
        {
            grid[line.index, i] = 0;
        }
        else
        {
            grid[line.index, i] = 1;
        }
    }
}
var count = 0;
for (int i = 0; i < grid.GetLength(0); i++)
{
    for (int j = 0; j < grid.GetLength(1); j++)
    {
        if (grid[i, j] == 0)
        {
            continue;
        }
        var neighboringCount = CountNeighbors(grid, i, j);
        if (neighboringCount < 4)
        {
            grid[i, j] = 0;
            count++;
            count += UpdateNeighbors(grid, i, j);
        }
        else
        {
            grid[i, j] = -neighboringCount;
        }
    }
}


Console.WriteLine(count);

static int CountNeighbors(int[,] grid, int row, int col)
{
    int count = 0;

    int rows = grid.GetLength(0);
    int cols = grid.GetLength(1);

    for (int dy = -1; dy <= 1; dy++)
    {
        for (int dx = -1; dx <= 1; dx++)
        {
            if (dy == 0 && dx == 0)
            {
                continue;
            }

            int neighborR = row + dy;
            int neighborC = col + dx;
            if (neighborR >= 0 && neighborR < rows &&
                neighborC >= 0 && neighborC < cols)
            {
                if (grid[neighborR, neighborC] != 0)
                    count++;
            }
        }
    }

    return count;
}

static int UpdateNeighbors(int[,] grid, int row, int col)
{
    int count = 0;

    int rows = grid.GetLength(0);
    int cols = grid.GetLength(1);

    for (int dy = -1; dy <= 1; dy++)
    {
        for (int dx = -1; dx <= 1; dx++)
        {
            if (dy == 0 && dx == 0)
            {
                continue;
            }

            int neighborR = row + dy;
            int neighborC = col + dx;
            if (neighborR >= 0 && neighborR < rows &&
                neighborC >= 0 && neighborC < cols)
            {
                if (grid[neighborR, neighborC] >= 0)
                {
                    continue;
                }

                grid[neighborR, neighborC]++;
                if (grid[neighborR, neighborC] > -4)
                {
                    grid[neighborR, neighborC] = 0;
                    count++;
                    count += UpdateNeighbors(grid, neighborR, neighborC);
                }
            }
        }
    }

    return count;
}

static void PrintGrid(int[,] grid)
{
    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
            Console.Write(grid[i, j] < 0 ? grid[i, j].ToString() + " " : " " + grid[i, j].ToString() + " ");
        }
        Console.WriteLine();
    }
}