using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Diagnostics;

namespace LeetCode
{
    public class PerfectSquares
    {
        public int NumSquares(int n)
        {
            var count = DP(n);
            return count;
        }

        /// <summary>
        /// 递归 -- 通过 LeetCode 测试用例
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int Recursion(int n)
        {
            if (n < 1) return 0;

            if (n == 1) return 1;

            if (n == 2) return 2;

            if (n == 3) return 3;

            int nearest = (int)Math.Sqrt(n);

            if (nearest * nearest == n) return 1;

            int count = n;//最大步骤是 n 个 1 相加

            for (int i = nearest; i >= 1; i--)
            {
                int cur = 0, num = n;

                int pow = i * i; // 检测值是否大过连续几个平方数
                while (num - pow >= 0)
                {
                    num -= pow; // 如果大约平方数，那么直接减去
                    cur++;
                }


                if (cur < count)
                {
                    var subNumCount = Recursion(num);
                    count = Math.Min(subNumCount + cur, count);
                }
            }

            return count;
        }

        /// <summary>
        /// 递归 + 记忆化搜索
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int RecursionMS(int n)
        {
            // 在上面的递归例子中，重叠子问题。
            //https://blog.csdn.net/qq_20011607/article/details/82929611
            var ms = new Dictionary<int, int>();

            var count = RecursionMS(n, ms);
            return count;
        }

        private int RecursionMS(int n, Dictionary<int, int> ms)
        {
            if (n < 1) return 0;

            if (n == 1) return 1;

            if (n == 2) return 2;

            if (n == 3) return 3;

            int nearest = (int)Math.Sqrt(n);

            if (nearest * nearest == n) return 1;

            int count = n;//最大步骤是 n 个 1 相加

            if (ms.ContainsKey(n))
            {
                if (ms.TryGetValue(n, out count))
                    return count;
            }

            for (int i = nearest; i >= 1; i--)
            {
                int cur = 0, num = n;

                int pow = i * i; // 检测值是否大过连续几个平方数
                while (num - pow >= 0)
                {
                    num -= pow; // 如果大约平方数，那么直接减去
                    cur++;
                }


                if (cur < count)
                {
                    var subNumCount = RecursionMS(num, ms);
                    count = Math.Min(subNumCount + cur, count);
                }
            }

            ms.TryAdd(n, count);

            return count;
        }

        /// <summary>
        /// 动态规划(Dynamic Programming，DP)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private int DP(int n)
        {
            //  动态规划用 dp[i] 数组存储第 i 个数的完美平方数
            //  1    2       3     4      5       6       7       8     9    10      11             12           13   14   15   16 --数组索引
            //  1    2       3     1      2       3       4       2     1    2       3              
            //  * [1]+[1] [2]+[1]  *   [4]+[1] [4]+[2] [4]+[3] [4]+[4]  *  [9]+[1] [9]+[2]  [9]+[3] or [8]+[4]   ...[x] --索引

            // 12 的时候要考虑的子情况有：[1]+[11];[2]+[10];[3]+[9];[4]+[8];[5]+[7];[6]+[6];

            if (n < 1) return 0;

            if (n == 1) return 1;

            var nums = new int[n + 1];

            Array.Fill(nums, n);

            //for (int i = 1; i < n; i++)
            //{
            //    var pow = i * i;

            //    if (pow > n)
            //        break;

            //    nums[pow] = 1;
            //}

            for (int i = 1; i * i <= n; i++)
            {
                nums[i * i] = 1;
            }

            if (nums[n] == 1)
                return 1;

            // n = 5374 超时
            //for (int i = 1; i <= n; i++)
            //{
            //    if (nums[i] == 1)
            //        continue;//上面的for循环已经赋值过了

            //    var path = i / 2;//[5]+[7]=[7]+[5] 所以只要比较
            //    for (int j = 1; j <= path; j++)
            //    {
            //        var count = nums[j] + nums[i - j];

            //        if (count == 2)
            //        {
            //            nums[i] = 2;
            //            break;
            //        }

            //        nums[i] = Math.Min(count, nums[i]);//计算过的比较哪个小，取那个~
            //    }
            //}

            // 比上面的快20多倍，我去~
            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; i + j * j <= n; j++)
                {
                    nums[i + j * j] = Math.Min(nums[i] + 1, nums[i + j * j]);
                }
            }

            return nums[n];
        }


        //Lagrange 四平方定理： 任何一个正整数都可以表示成不超过四个整数的平方之和。



        public void Play()
        {
            // 8328 是 LeetCode 测试用例 530 / 588 
            // 7929 是 LeetCode 测试用例 553 / 588 
            // 5374 是 LeetCode 测试用例 554 / 588 
            const int TestNum = 5374;//34567;
            Stopwatch sw = new Stopwatch();

            TestRecursion(TestNum, sw);

            // 虽然慢过 Recursion()，但缓存的思想还是要的
            //TestRecursionMS(TestNum, sw);

            TestDP(TestNum, sw);
        }


        private void TestRecursion(int testNum, Stopwatch sw)
        {

            sw.Restart();

            var count = Recursion(testNum);

            long ms = sw.ElapsedMilliseconds;

            Console.WriteLine($"测试数值：{testNum},需要最少 {count} 个平方数,Recursion 方法使用了 {ms} 毫秒");

            sw.Stop();
        }

        private void TestRecursionMS(int testNum, Stopwatch sw)
        {
            sw.Restart();

            var count = Recursion(testNum);

            long ms = sw.ElapsedMilliseconds;

            Console.WriteLine($"测试数值：{testNum},需要最少 {count} 个平方数,RecursionMS 方法使用了 {ms} 毫秒");

            sw.Stop();
        }

        private void TestDP(int testNum, Stopwatch sw)
        {
            sw.Restart();

            var count = DP(testNum);

            long ms = sw.ElapsedMilliseconds;

            Console.WriteLine($"测试数值：{testNum},需要最少 {count} 个平方数,TestDP 方法使用了 {ms} 毫秒");

            sw.Stop();
        }
    }
}
