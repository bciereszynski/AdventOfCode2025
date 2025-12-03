using System;

const string fileName = @"inputs\day3.txt";
int sum = 0;

foreach (string line in File.ReadLines(fileName))
{   
    int first = 0;
    int second = 0;
    foreach (char c in line)
    {
        int curr = int.Parse(c.ToString());
        if(curr > first)
        {
            second = -first;
            first = curr;
        }
        else if(curr > second)
        {
            second = curr;
        }
    }
    if(second < 0)
    {
        (first, second) = (-second, first);
    }
    sum += first * 10 + second;
}    
Console.WriteLine(sum + "");