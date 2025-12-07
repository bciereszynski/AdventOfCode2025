using System;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadLines(@"./inputs/day6.txt").ToList();

var operandsLine = lines.Last();

List<string> operandsArray = Regex.Replace(operandsLine.Trim(), "\\s+", " ").Split(" ").ToList();

var numbersGrid = new List<int>[operandsArray.Count];
string[] numberLines = lines.Take(lines.Count - 1).ToArray();
var currEquationNumber = -1;

for (int i = 0; i < numberLines[0].Length; i++)
{
    var number = 0;

    for (int j = 0; j < numberLines.Length; j++)
    {
        var currChar = numberLines[j][i];
        if (currChar == ' ')
        {
            continue;
        }
        var digit = Convert.ToInt32(currChar - '0');
        number = number * 10 + digit;

    }
    if (number == 0)
    {
        continue;
    }
    if (operandsLine.Length > i && operandsLine[i] != ' ')
    {
        currEquationNumber++;
        numbersGrid[currEquationNumber] = new List<int>();
    }
    numbersGrid[currEquationNumber].Add(number);
}

long result = 0;
for (int i = 0; i < operandsArray.Count; i++)
{
    long localResult;
    switch (operandsArray[i])
    {
        case "+":

            localResult = numbersGrid[i].Sum();
            break;

        case "*":
            localResult = numbersGrid[i].Aggregate(1L, (acc, x) => acc * x);
            break;
        default:
            throw new Exception("corrupted file:" + operandsArray[i]);
    }
    result += localResult;
}

Console.WriteLine(result);
