using System;

const string fileName = @"inputs\day1b.txt";
const int modulo = 100;

var state = 50;
var code = 0;
var prevState = 50;

foreach (string line in File.ReadLines(fileName))
{
    var direction = line.Substring(0, 1);
    var value = int.Parse(line.Substring(1));

    code += value / 100;
    value %= 100;

    if (direction == "R")
    {
        state = (state + value) % modulo;
        if (state < prevState)
        {
            code++;
        }
    }
    else if (direction == "L")
    {
        state = (state - value + modulo) % modulo;
        if (state > prevState && prevState != 0)
        {
            code++;
        }
        else if (state == 0)
        {
            code++;
        }
    }
    else
    {
        throw new Exception("Unknown direction");
    }

    prevState = state;

    // Console.WriteLine(state + " " + code);
}

Console.WriteLine(code);