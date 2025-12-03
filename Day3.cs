using System;

const string fileName = @"inputs\day3_small.txt";

foreach (string line in File.ReadLines(fileName))
{   

   foreach (char c in line)
   {
       int curr = int.Parse(c.ToString());
       Console.Write(curr + " ");
   }
   Console.WriteLine("");
}