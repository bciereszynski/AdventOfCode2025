using System;

const string fileName = @"inputs\day4.txt";
var lines = File.ReadLines(fileName);

short[,] grid = new short[lines.Count(), lines.First().Length];

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
for (int i = 0; i<grid.GetLength(0); i++)
{
    for (int j=0; j < grid.GetLength(1); j++)
    {
        if(grid[i,j] == 0)
        {
            continue;
        }
        var sum = SumNeighbors(grid, i, j);
        if (sum < 4)
        {
            count++;
        }
    }
}


Console.WriteLine(count);

static int SumNeighbors(short[,] grid, int row, int col)
{
    int sum = 0;

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
                sum += grid[neighborR, neighborC];
            }
        }
    }
    
    return sum;
}