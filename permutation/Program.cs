using System;
using System.Collections.Generic;

Solution s = new();

var ans = s.Permute(new[] {1, 2, 3});

foreach (var item in ans)
{
    foreach (var i in item)
    {
        Console.Write(i + " ");
    }
    Console.WriteLine();
}



