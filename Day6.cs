using System;
using System.Text.RegularExpressions;

var lines = File.ReadLines(@"./inputs/day6.txt").ToList();

var numberLines = lines.Take(lines.Count - 1).ToList();
List<string> operandsArray = Regex.Replace(lines.Last().Trim(), "\\s+", " ").Split(" ").ToList();

var numbersGrid = new int[numberLines.Count, operandsArray.Count];

foreach (var line in numberLines.Select((value, index) => new { value, index }))
{
    var trimmedLine = Regex.Replace(line.value.Trim(), "\\s+", " ");
    foreach (var numeberString in trimmedLine.Split(" ").Select((value, index) => new { value, index }))
    {
        var number = int.Parse(numeberString.value);
        numbersGrid[line.index, numeberString.index] = number;
    }
}

long result = 0;
for (int i = 0; i < operandsArray.Count; i++)
{
    long localResult;
    var column = Enumerable.Range(0, numbersGrid.GetLength(0))
                                       .Select(j => numbersGrid[j, i]);
    switch (operandsArray[i])
    {
        case "+":
            localResult = column.Sum();
            break;

        case "*":
            localResult = column.Aggregate(1L, (acc, x) => acc * x);
            break;
        default:
            throw new Exception("corrupted file");
    }
    result += localResult;
}

Console.WriteLine(result);
