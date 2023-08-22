using RAPExpressions;

namespace Expressions_Playground
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<decimal> Weights = new() { 25, 25, 20, 30 };
            List<decimal> Values = new() { 10, 10, 20, 30 };
            List<decimal> Ratings = new() { 1, 1, 2, 3 };

            string expression = "((Weight / 100) * Rating).Average()";

            object result = Engine.Execute(expression, Weights, Values, Ratings);

            Console.WriteLine($"Result: {result}");
            Console.ReadLine();
        }
    }
}