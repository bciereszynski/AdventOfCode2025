using System;

const string fileName = @"inputs\day5.txt";

var lines = File.ReadLines(fileName).ToList();

var splitIndex = lines.IndexOf("");

var rangesLines = lines.Take(splitIndex).ToList();
var ingridientsLines = lines.Skip(splitIndex + 1).ToList();

List<(long start, long end)> ranges = new List<(long start, long end)>();

foreach (var line in rangesLines)
{
    var parseLine = line.Split('-');
    var start = long.Parse(parseLine[0]);
    var end = long.Parse(parseLine[1]);

    ranges.Add((start, end));
}

var freshCount = 0;
foreach (var line in ingridientsLines)
{
    var ingridient = long.Parse(line);
    for (var i = 0; i < ranges.Count; i++)
    {
        var range = ranges[i];
        if (ingridient >= range.start && ingridient <= range.end)
        {
            freshCount++;
            break;
        }
    }
}

Console.WriteLine(freshCount);
