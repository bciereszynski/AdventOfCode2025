using System;

var lines = File.ReadLines(@"inputs/day7.txt");

var beemState = new char[lines.First().Length];

var splitCount = 0;

foreach (var line in lines)
{

    for (int idx = 0; idx < line.Length; idx++)
    {
        var value = line[idx];
        switch (value)
        {
            case '.':
                beemState[idx] = beemState[idx];
                break;
            case 'S':
                beemState[idx] = '|';
                break;
            case '^':
                if (beemState[idx] == '|')
                {
                    beemState[idx - 1] = '|';
                    beemState[idx] = ' ';
                    beemState[++idx] = '|';
                    splitCount++;
                }
                break;
            default:
                throw new Exception("bad input");
        }
    }
}

Console.WriteLine(splitCount);
