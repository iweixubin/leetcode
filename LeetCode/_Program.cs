using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new PerfectSquares();

            if (subject == null)
            {
                Console.WriteLine($"请选择要演示的题目");
            }
            else
            {
                Console.WriteLine($"现在演示的是：{subject.GetType().Name}{Environment.NewLine}");

                subject.Play();
            }

            Console.ReadLine();
        }
    }
}
