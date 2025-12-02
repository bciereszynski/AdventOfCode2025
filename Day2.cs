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

static bool[] SieveOfEratosthenes(int size)
{
    if (size < 2)
    {
        return new bool[0];
    }

    bool[] isPrime = new bool[size + 1];
    for (int i = 0; i <= size; i++)
    {
        isPrime[i] = true;
    }

    isPrime[0] = false;
    isPrime[1] = false;

    for (int p = 2; p * p <= size; p++)
    {
        if (isPrime[p])
        {
            for (int i = p * p; i <= size; i += p)
            {
                isPrime[i] = false;
            }
        }
    }

    return isPrime;
}



bool isInvalid2(long value, bool[] isPrime)
{
    long getBatch(ref long value, long division)
    {
        var batch = value % division;
        value /= division;
        return batch;
    }

    int numberOfDigits = value != 0 ? (int)Math.Floor(Math.Log10(Math.Abs(value))) + 1 : 1;

    for (int batchCount = 2; batchCount <= numberOfDigits; ++batchCount)
    {
        long localValue = value;
        if (numberOfDigits % batchCount != 0)
        {
            continue;
        }
        if (!isPrime[batchCount])
        {
            continue;
        }
        int batchSize = numberOfDigits / batchCount;
        long division = Convert.ToInt64(Math.Pow(10, batchSize));
        long previousBatch = getBatch(ref localValue, division);
        for (int processedCharacters = batchSize; processedCharacters <= numberOfDigits; processedCharacters += batchSize)
        {
            if (processedCharacters == numberOfDigits)
            {
                return true;
            }

            long currBatch = getBatch(ref localValue, division);

            if (currBatch != previousBatch)
            {
                break;
            }
            previousBatch = currBatch;
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

    bool[] isPrime = SieveOfEratosthenes(1000);

    for (var i = begin; i <= end; i++)
    {
        if (isInvalid2(i, isPrime))
        {
            count += i;
        }
    }

}

Console.WriteLine(count.ToString());
