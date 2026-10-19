using Combinatorics;
using Combinatorics.Collections;

namespace prilaganeKombinatorika
{
    internal class Program
    {
        static void Example()
        {
            char[] signs1 = new char[] { 'A', 'B', 'C', 'D' };
            char[] signs2 = new char[] { 'A', 'B', 'C', 'D' };

            //permutacii
            Console.WriteLine("Permutations:");
            Permutations<char> permutations1 = new Permutations<char>(signs1);
            foreach (var item in permutations1)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine("\nPermutations with repetitions:");
            Permutations<char> permutations2 = new Permutations<char>(signs2, GenerateOption.WithRepetition);
            foreach (var item in permutations2)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            //kombinacii
            Console.WriteLine("\nCombination 4 elements 2 class:");
            Combinations<char> combination1 = new Combinations<char>(signs1, 2);
            foreach (var item in combination1)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine("\nCombination 4 elements 2 class with repetitions:");
            Combinations<char> combination2 = new Combinations<char>(signs2, 2, GenerateOption.WithRepetition);
            foreach (var item in combination2)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            //variacii
            Console.WriteLine("\nVariations 4 elements 2 class:");
            Variations<char> variations1 = new Variations<char>(signs1, 2);
            foreach (var item in variations1)
            {
                Console.WriteLine(string.Join(" ", item));
            }

            Console.WriteLine("\nVariations 4 elements 2 class with repetitions:");
            Variations<char> variations2 = new Variations<char>(signs2, 2, GenerateOption.WithRepetition);
            foreach (var item in variations2)
            {
                Console.WriteLine(string.Join(" ", item));
            }
        }
        static void Main(string[] args)
        {
            Example();
            Console.ReadKey();
        }
    }
}
