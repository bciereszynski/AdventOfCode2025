using System;

const string fileName = @"inputs\day3.txt";
long sum = 0;
List<(int idx, int value)> pairs;

foreach (string line in File.ReadLines(fileName))
{   
    pairs = new List<(int idx, int value)>();
    int itemCount = 12;
    int idx = 0;
    int lineSize = line.Length;
    foreach (char c in line)
    {
        pairs.Add((idx, c - '0'));
        idx++;
    }

    pairs = pairs.OrderByDescending(p => p.value).ToList();
    
    long joltage = 0;
    for (int i = itemCount; i >0; i--)
    {
       var biggestPossibleElement = pairs.FirstOrDefault(p => lineSize - p.idx >= i);
       joltage = joltage *10 + biggestPossibleElement.value;
       pairs.RemoveAll(p => p.idx <= biggestPossibleElement.idx);
    }
    sum += joltage;
  
}    
Console.WriteLine(sum + "");