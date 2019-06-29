using System;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            ITest subject = null;

            //
            subject = new NumberOfIslands();

            if (subject == null)
            {
                Console.WriteLine($"请选择要演示的题目");
            }
            else
            {
                Console.WriteLine($"现在演示的是：{subject.GetType().Name}");

                subject.Play();
            }

            Console.ReadLine();
        }
    }

    // 用来实现多态，
    // 放在这里违反了编程约定，但真的不想创建多一个文件~
    interface ITest
    {
        void Play();
    }
}
