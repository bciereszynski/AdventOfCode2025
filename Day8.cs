using System;

var lines = File.ReadLines(@"inputs/day8.txt");

record Coordinate(int x, int y, int z);
record Distance(int first, int second, double distance);

List<Coordinate> coordinates = new List<Coordinate>();
List<Distance> distances = new List<Distance>();

double CalcDistance(Coordinate A, Coordinate B)
{
    long dx = A.x - B.x;
    long dy = A.y - B.y;
    long dz = A.z - B.z;

    double sumOfSquares =
        Math.Pow(dx, 2) +
        Math.Pow(dy, 2) +
        Math.Pow(dz, 2);

    return Math.Sqrt(sumOfSquares);
}

foreach (var line in lines)
{
    var coorinatesStrings = line.Split(',');

    coordinates.Add(new Coordinate(int.Parse(coorinatesStrings[0]), int.Parse(coorinatesStrings[1]), int.Parse(coorinatesStrings[2])));
}

for (int i = 0; i < coordinates.Count; i++)
{
    for (int j = i + 1; j < coordinates.Count; j++)
    {
        distances.Add(new Distance(i, j, CalcDistance(coordinates[i], coordinates[j])));
    }
}

int Find(int idx, int[] groups)
{
    int result = idx;
    while (groups[result] != result)
    {
        result = groups[result];
    }
    return result;
}

bool Union(int idxA, int idxB, int[] groups, int[] groupsCount)
{
    int findA = Find(idxA, groups);
    int findB = Find(idxB, groups);

    if(findA != findB)
    {
        groupsCount[findB] += groupsCount[findA];
        groupsCount[findA] = -1;
        groups[findA] = findB;

        if (groupsCount[findB] == groupsCount.Length)
        {
            return true;
        }
    }
    return false;
}

var groups = new int[coordinates.Count()];
var groupsCount = new int[coordinates.Count()];

for (int i = 0; i < groups.Length; i++)
{
    groups[i] = i;
    groupsCount[i] = 1;
}

distances = distances.OrderBy(d => d.distance).ToList();

foreach (var distance in distances)
{
    if(Union(distance.first, distance.second, groups, groupsCount))
    {
        Console.WriteLine(checked((long)coordinates[distance.first].x * coordinates[distance.second].x));
        break;
    }
}
