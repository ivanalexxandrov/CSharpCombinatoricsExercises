
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Combinatorics.Collections;

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Permutacii");
        Console.WriteLine("2. Suma nula");
        Console.WriteLine("3. Razbivane na chislo");
        Console.WriteLine("4. Razbivane na chislo (kato proizvedenie)");
        Console.WriteLine("5. Razbivane na chisla (kato suma ot dadeni chisla)");
        Console.Write("Izberi zadacha (1-5): ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                PermutationsTask();
                break;
            case 2:
                ZeroSumTask();
                break;
            case 3:
                SumPartitionsTask();
                break;
            case 4:
                ProductPartitionsTask();
                break;
            case 5:
                GivenNumbersSumTask();
                break;
            default:
                Console.WriteLine("Невалиден избор!");
                break;
        }
    }

    // Zad 1
    static void PermutationsTask()
    {
        Console.Write("N (0-30): ");
        int n = int.Parse(Console.ReadLine());

        if (n < 0 || n > 30)
        {
            Console.WriteLine("N trqbva da e mejdu 0 i 30.");
            return;
        }

        BigInteger result = 1;

        for (int i = 2; i <= n; i++)
            result *= i;

        Console.WriteLine($"{n}! = {result}");
    }

    // Zad 2
    static void ZeroSumTask()
    {
        Console.Write("Broi chisla n: ");
        int n = int.Parse(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("n trqbva da e polojitelno");
            return;
        }

        Console.WriteLine($"Vuvedi {n} chisla, razdeleni s ' ':");
        int[] numbers = Console.ReadLine()
            .Split(new[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        if (numbers.Length != n)
        {
            Console.WriteLine("Trqbva da vuvedesh tochno n chisla");
            return;
        }

        int[] signs = { -1, 1 };

        var variations = new Variations<int>(
            signs, n, GenerateOption.WithRepetition);

        int count = 0;

        foreach (var v in variations)
        {
            long sum = 0;

            for (int i = 0; i < n; i++)
                sum += (long)v[i] * numbers[i];

            if (sum == 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if (v[i] == 1)
                        Console.Write("+");
                    else
                        Console.Write("-");

                    Console.Write(numbers[i] + " ");
                }

                Console.WriteLine("= 0");
                count++;
            }
        }

        Console.WriteLine("Broi resheniq: " + count);
    }

    // Zad 3
    static void SumPartitionsTask()
    {
        Console.Write("Vuvedi n: ");
        int n = int.Parse(Console.ReadLine());

        if (n <= 0)
        {
            Console.WriteLine("n trqbva da e polojitelno");
            return;
        }

        List<int> partition = new List<int>();

        GenerateSumPartitions(n, n, partition);
    }

    static void GenerateSumPartitions(
        int remaining, int maxPart, List<int> partition)
    {
        if (remaining == 0)
        {
            Console.WriteLine(string.Join(" + ", partition));
            return;
        }

        for (int k = Math.Min(remaining, maxPart); k >= 1; k--)
        {
            partition.Add(k);

            GenerateSumPartitions(
                remaining - k, k, partition);

            partition.RemoveAt(partition.Count - 1);
        }
    }

    // Zad 4
    static void ProductPartitionsTask()
    {
        Console.Write("Vuvedi n (da ne e prosto chislo obv): ");
        int n = int.Parse(Console.ReadLine());

        if (n < 2)
        {
            Console.WriteLine("Nqma netrivialno razbivane");
            return;
        }

        List<int> factors = new List<int>();
        GenerateProductPartitions(n, n, factors);
    }

    static void GenerateProductPartitions(
        int remaining, int maxFactor, List<int> factors)
    {
        if (remaining == 1)
        {
            if (factors.Count > 1)
                Console.WriteLine(string.Join(" * ", factors));

            return;
        }
        if (factors.Count > 0 && remaining <= maxFactor)
        {
            factors.Add(remaining);
            Console.WriteLine(string.Join(" * ", factors));
            factors.RemoveAt(factors.Count - 1);
        }

        for (int k = Math.Min(maxFactor, remaining / 2);
             k >= 2; k--)
        {
            if (remaining % k == 0)
            {
                factors.Add(k);

                GenerateProductPartitions(
                    remaining / k, k, factors);

                factors.RemoveAt(factors.Count - 1);
            }
        }
    }

    // Zad 5
    static void GivenNumbersSumTask()
    {
        Console.Write("Vuvedi celeva suma n: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Vuvedi broi na chislata m: ");
        int m = int.Parse(Console.ReadLine());

        if (n < 0 || m <= 0)
        {
            Console.WriteLine("Nevalidni vhodni danni");
            return;
        }

        Console.WriteLine($"Vuvedi {m} chisla, razdeleni s ' ':");
        int[] values = Console.ReadLine()
            .Split(new[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .Distinct()
            .OrderByDescending(x => x)
            .ToArray();

        if (values.Length != m ||
            values.Any(x => x <= 0))
        {
            Console.WriteLine("Vuvedi tochno m razlichni polojitelni chisla");
            return;
        }

        List<int> combination = new List<int>();

        GenerateGivenSum(n, values, 0, combination);
    }

    static void GenerateGivenSum(
        int remaining,
        int[] values,
        int startIndex,
        List<int> combination)
    {
        if (remaining == 0)
        {
            Console.WriteLine(string.Join(" + ", combination));
            return;
        }

        for (int i = startIndex; i < values.Length; i++)
        {
            int value = values[i];

            if (value > remaining)
                continue;

            combination.Add(value);

            GenerateGivenSum(
                remaining - value, values, i, combination);

            combination.RemoveAt(combination.Count - 1);
        }
    }
}

