using System;
using System.Linq;
using Combinatorics.Collections;

class Program
{
    static void Main()
    {
        // задача 1 /Пермутация/
        int[] digits = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

        var permutations = new Permutations<int>(digits);

        int count = 0;

        foreach (var permutation in permutations)
        {
            if (permutation.First() != 0)
            {
                count++;
            }
        }

        Console.WriteLine("Zadacha 1 (1):\nBroi desetcifreni chisla: " + count);

        // задача 20 /Вариация/

        int[] digits2 = { 1, 3, 4, 6 };
        var permutations2 = new Permutations<int>(
            digits2, GenerateOption.WithoutRepetition);

        int count2 = 0;

        Console.WriteLine("\nZadacha 2 (20):");
        foreach (var p in permutations2)
        {
            int number = p.Take(3)
                          .Aggregate(0, (a, b) => a * 10 + b);

            if (p.Count >= 3)
            {
                Console.WriteLine(number);
                count2++;
            }
        }

        Console.WriteLine("Total: " + count2);


        // Zadacha 53:
        int[] points = { 1, 2, 3, 4, 5, 6, 7 };

        var combinations = new Combinations<int>(points, 4);
        int count3 = 0;

        foreach (var c in combinations)
        {
            count3++;
        }

        Console.WriteLine("\nZadacha 3 (53): " + count3);
    }
}
