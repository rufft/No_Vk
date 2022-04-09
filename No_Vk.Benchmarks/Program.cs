using System;
using BenchmarkDotNet.Running;
using No_Vk.Test;

namespace No_Vk.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<BenchmarkDbTests>();

            Console.ReadLine();
        }
    }
}
