using System;

var lines = File.ReadLines(@"inputs/day7.txt");

enum TachyonElement
{
    None,
    Splitter
}

(int x, int y) startPoint = (-1, -1);

var tachyonGrid = new TachyonElement[lines.Count(), lines.First().Count()];
long[,] resultGrid = new long[lines.Count(), lines.First().Count()];

foreach (var line in lines.Select((value, idx) => new { value, idx }))
{

    for (int idx = 0; idx < line.value.Length; idx++)
    {
        var value = line.value[idx];
        switch (value)
        {
            case '.':
                tachyonGrid[line.idx, idx] = TachyonElement.None;
                break;
            case 'S':
                tachyonGrid[line.idx, idx] = TachyonElement.None;
                startPoint = (line.idx, idx);
                break;
            case '^':
                tachyonGrid[line.idx, idx] = TachyonElement.Splitter;
                break;
            default:
                throw new Exception("bad input");
        }
    }
}

Console.WriteLine(CalculateTimelines(startPoint));

long CalculateTimelines((int x, int y) point)
{
    if (point.y > tachyonGrid.GetLength(1) || point.y < 0)
    {
        return 0;
    }

    while (point.x < tachyonGrid.GetLength(0) && tachyonGrid[point.x, point.y] != TachyonElement.Splitter)
    {
        point.x++;
    }
    
    if (point.x < tachyonGrid.GetLength(0) && tachyonGrid[point.x, point.y] == TachyonElement.Splitter)
    {
        if (resultGrid[point.x, point.y] == 0)
        {
            resultGrid[point.x, point.y] = CalculateTimelines((point.x, point.y - 1)) + CalculateTimelines((point.x, point.y + 1));
        }
        return resultGrid[point.x, point.y];
    }

    return 1;
}