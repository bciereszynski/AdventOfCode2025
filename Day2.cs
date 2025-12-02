using System;

const string fileName = @"inputs\day2.txt";

bool isInvalid1(long value)
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


bool isInvalid2(long value)
{
    var size = value.ToString().Length;

    for (int number = 2; number <= size; ++number)
    {
        long tmpVal = value;
        if (size % number != 0)
        {
            continue;    
        }
        var division = Convert.ToInt64(Math.Pow(10, size / number));
        var previous = tmpVal % division;
        tmpVal /= division;
        for (long i = size / number; i <= size; i += size / number)
        {
            if (i == size)
            {
                return true;
            }
            var curr = tmpVal % division;
            tmpVal /= division;
            if (curr != previous)
            {
                break;
            }
            previous = curr;
        }
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
        if (isInvalid2(i))
        {
            count += i;
        }
    }

}

Console.WriteLine(count.ToString());
