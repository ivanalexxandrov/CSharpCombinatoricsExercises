using Combinatorics;

namespace RediciS0i1
{
    internal class Program
    {
        static int[] numbers;
        static int n;
        static void ManipulateOutput(int n) 
        {
            for (int i = 1; i <= n; i++) 
            {
                Console.Write(numbers[i]);
            }
            Console.WriteLine();
        }
        static void Go(int i) 
        {
            if (i == n + 1)
            {
                ManipulateOutput(n);
                return;
            }
            numbers[i] = 0;
            Go(i + 1);

            numbers[i] = 1;
            Go(i + 1);
        }
        static void Main(string[] args)
        {
            numbers = new int[10];
            n = 3;
            Go(1);

            Console.ReadKey();
        }
    }
}
