using System;

const string fileName = @"inputs\day1a.txt";
const int modulo = 100;

var state = 50;
var code = 0;

foreach (string line in File.ReadLines(fileName))
{
    var direction = line.Substring(0, 1);
    var value = int.Parse(line.Substring(1));

    if (direction == "R")
    {
        state = (state + value) % modulo;
    }
    else if (direction == "L")
    {
        state = (state - value + modulo) % modulo;
    }
    else
    {
        throw new Exception("Unknown direction");
    }

    if (state == 0)
    {
        code++;
    }

    // Console.WriteLine(state);
}

Console.WriteLine(code);