using System;

const string fileName = @"inputs\day5.txt";

var lines = File.ReadLines(fileName).ToList();

var splitIndex = lines.IndexOf("");

var rangesLines = lines.Take(splitIndex).ToList();
var ingridientsLines = lines.Skip(splitIndex + 1).ToList();

List<(long start, long end)> ranges = new List<(long start, long end)>();
long freshCount = 0;

foreach (var line in rangesLines)
{
    var parseLine = line.Split('-');
    var start = long.Parse(parseLine[0]);
    var end = long.Parse(parseLine[1]);

    (long start, long end)? startRange = null, endRange = null;
    foreach (var range in ranges)
    {
        if (start >= range.start && start <= range.end)
        {
            startRange = range;
        }
        if (end >= range.start && end <= range.end)
        {
            endRange = range;
        }
    }

    if (startRange == null && endRange == null)
    {
        freshCount += AddRange(ranges, start, end);
        continue;
    }
    if (startRange != null && endRange != null)
    {
        if (startRange == endRange)
        {
            continue;
        }

        var mergedRange = (startRange.Value.start, endRange.Value.end);
        freshCount += AddRange(ranges, mergedRange.start, mergedRange.end);
        continue;

    }
    if (startRange != null)
    {
        var extendedRange = (startRange.Value.start, end);
        freshCount += AddRange(ranges, extendedRange.start, extendedRange.end);
        continue;
    }

    if (endRange != null)
    {
        var extendedRange = (start, endRange.Value.end);
        freshCount += AddRange(ranges, extendedRange.start, extendedRange.end);
        continue;
    }
}

Console.WriteLine(freshCount);


static long AddRange(List<(long start, long end)> ranges, long start, long end)
{

    long countChange = end - start + 1;
    var rangesToRemove = ranges.Where(range => range.start >= start && range.start <= end || range.end >= start && range.end <= end).ToList();
    foreach (var r in rangesToRemove)
    {
        countChange -= r.end - r.start + 1;
        ranges.Remove(r);
    }
    ranges.Add((start, end));
    return countChange;
}

static void PrintRanges(List<(long start, long end)> ranges)
{
    Console.WriteLine("---");
    foreach (var range in ranges)
    {
        Console.WriteLine($"{range.start}-{range.end}");
    }
}