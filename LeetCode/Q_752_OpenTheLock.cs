using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LeetCode
{
    /// <summary>
    /// 打开转盘锁
    /// </summary>
    public class OpenTheLock
    {
        // 解题思路请看《图解算法》中的 广度优先搜索

        public int OpenLock(string[] deadends, string target)
        {
            var deadNums = new Dictionary<int, int>(32);
            for (int i = 0; i < deadends.Length; i++)
            {
                if (deadends[i] == "0000")
                    return -1;

                // 把字符转成数字
                // 前面加上 10 是为了变成 10xyzw, 这样 xyzw 就可以是 0009
                var deadNum = int.Parse("10" + deadends[i]);

                // 要判断是否重复，LeetCode 的测试用例有重复的
                if (!deadNums.ContainsKey(deadNum))
                    deadNums.Add(deadNum, deadNum);
            }

            var targetNum = int.Parse("10" + target);

            var step = OpenLock(deadNums, targetNum);

            return step;
        }

        private int OpenLock(Dictionary<int, int> deadNums, int target)
        {
            // 广度优先搜索，记录搜索过的节点
            // 一开始用List，有些 LeetCode 的测试用例超时了
            // 所以改为查询时间为 O(1) 的 Hash，并一开始分配好空间
            var visitedNum = new Dictionary<int, int>(10000);

            var q = new Queue<int>();
            q.Enqueue(100000);

            int step = 0;

            while (q.Any())// 如果队列有数据
            {
                // 那么查看队列的长度
                var qCount = q.Count;

                // 用来记录本次查询如果没有的话，下一组要查询的数字
                var thisStepNeighbors = new Dictionary<int, int>(128);

                for (int i = 0; i < qCount; i++)
                {
                    var num = q.Dequeue();

                    // 到达了目标就返回
                    if (num == target) return step;

                    // 没有的话就记录访问过了
                    visitedNum.Add(num, num);

                    // 并且获取它的周围节点
                    var neighbors = GetNeighbors(num);

                    foreach (var item in neighbors)
                    {
                        if (deadNums.ContainsKey(item))
                            continue;

                        if (visitedNum.ContainsKey(item))
                            continue;

                        // 防止相同的数字重复添加到队列中
                        if (thisStepNeighbors.ContainsKey(item))
                            continue;

                        thisStepNeighbors.Add(item, item);
                    }
                }

                foreach (var item in thisStepNeighbors)
                    q.Enqueue(item.Key);

                step++;
            }

            return -1;
        }


        /// <summary>
        /// 广度优先搜索，获取每个节点所能到达其它节点。
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private int[] GetNeighbors(int num)
        {
            // 10xyzw 整理出 xyzw 4 个独立数字
            var lockNums = new int[4];
            lockNums[0] = num % 10000 / 1000;
            lockNums[1] = num % 1000 / 100;
            lockNums[2] = num % 100 / 10;
            lockNums[3] = num % 10;

            // 有 4 个拨轮，每个拨轮正向转 1 下，总共 2 * 4 = 8 个邻居
            var neighbors = new int[8];

            neighbors[0] = Roll(lockNums, 0, true);
            neighbors[1] = Roll(lockNums, 1, true);
            neighbors[2] = Roll(lockNums, 2, true);
            neighbors[3] = Roll(lockNums, 3, true);

            neighbors[4] = Roll(lockNums, 0, false);
            neighbors[5] = Roll(lockNums, 1, false);
            neighbors[6] = Roll(lockNums, 2, false);
            neighbors[7] = Roll(lockNums, 3, false);

            return neighbors;

        }

        /// <summary>
        /// 转动拨轮
        /// </summary>
        /// <param name="lockNums">当前锁的数字</param>
        /// <param name="index">转动哪个拨轮</param>
        /// <param name="forward">正向转动 还是 反向转动</param>
        /// <returns></returns>
        private int Roll(int[] lockNums, int index, bool forward)
        {
            var temp = new int[lockNums.Length];
            lockNums.CopyTo(temp, 0);

            var n = lockNums[index];


            if (forward)
                n = n == 9 ? 0 : n + 1;  // 正向转动 +1，9 的时候变 0
            else
                n = n == 0 ? 9 : n - 1; // 正向转动 -1，0 的时候变 9

            temp[index] = n;

            var result = 100000 + temp[0] * 1000 + temp[1] * 100 + temp[2] * 10 + temp[3];

            return result;

        }
    }
}
