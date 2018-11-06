using System;

namespace MaxSumOfPath
{
    public class Program
    {
        static void Main(string[] args)
        {
            ITriangle triangle = new Triangle();
            triangle.CalculateMaxSumOfPath();
            Console.WriteLine(triangle.GetMaxSum());
            Console.WriteLine(triangle.GetMaxSumPath());
        }
    }
   
}
