using System;

const string fileName = @"inputs\day2.txt";

bool isInvalid(long value)
{
    var size = value.ToString().Length;

    if (size % 2 != 0)
    {
        return false;
    }

    long division = Convert.ToInt64(Math.Pow(10, size / 2));
    if (value / division == value % division)
    {
        return true;
    }

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
        if (isInvalid(i))
        {
            count += i;
        }
    }

}

Console.WriteLine(count.ToString());
