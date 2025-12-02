using System;

const string fileName = @"inputs\day2_small.txt";

bool isInvalid(string value)
{
    return false;
}

var line = File.ReadAllText(fileName);
long count = 0;

foreach (string range in line.Split(','))
{
    var separator = range.IndexOf('-');

    var begin = long.Parse(range.Substring(0, separator));
    var end = long.Parse(range.Substring(separator + 1));

    for (var i = begin; i <= end; i++)
    {
        if (isInvalid(i.ToString()))
        {
            count += i;
        }
    }

}

Console.WriteLine(count.ToString());
