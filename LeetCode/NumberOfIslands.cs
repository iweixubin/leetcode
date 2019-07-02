using System;

namespace LeetCode
{
    // 题目(英文版)：https://leetcode.com/problems/number-of-islands/
    // 题目(中文版)：https://leetcode-cn.com/problems/number-of-islands/
    // 解题思路请看《图解算法》中的 广度优先搜索
    class NumberOfIslands : ITest
    {
        public int NumIslands(char[][] grid)
        {
            if (grid == null)
                return 0;

            var row = grid.GetLength(0);

            if (row == 0)
                return 0;

            var col = 0;
            // arr[,]只能声明等长的二维数组
            // arr[][] 可以声明为不等长二维数据
            // 找出第二维最长的长度
            for (int i = 0; i < row; i++)
            {
                if (col < grid[i].Length)
                    col = grid[i].Length;
            }

            // 用来标记那些已经检查过了
            var visited = new bool[row, col];

            var count = 0;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    // 如果是陆地，并且未访问过
                    if (grid[i][j] == '1' && !visited[i, j])
                    {
                        count++;
                        Goto(grid, i, j, visited);
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// 前往
        /// </summary>
        /// <param name="grid">整个地区</param>
        /// <param name="x">目的地x</param>
        /// <param name="y">目的地y</param>
        /// <param name="visited">去过了就标记一下</param>
        private void Goto(char[][] grid, int x, int y, bool[,] visited)
        {
            if (x < 0 || x >= grid.GetLength(0))
                return;

            if (y < 0 || y >= grid[x].Length)
                return;

            // 如果已经访问过 或者 是水
            if (visited[x, y] || grid[x][y] == '0')
                return;

            // 标记这个点已经检查过了
            visited[x, y] = true;

            // 接下来是检查 这个点的上下左右
            Goto(grid, x, y - 1, visited); // 上
            Goto(grid, x, y + 1, visited); // 下
            Goto(grid, x - 1, y, visited); // 左
            Goto(grid, x + 1, y, visited); // 右
        }


        //---------华丽分割线---------

        public void Play()
        {
            TestA();
            TestB();
        }

        private void TestA()
        {
            //  输入:
            //  11110
            //  11010
            //  11000
            //  00000

            //  输出: 1
            var data = new char[,]
            {
                {'1','1', '1', '1', '0' },
                {'1','1', '0', '1', '0' },
                {'1','1', '0', '0', '0' },
                {'0','0', '0', '0', '0' }
            };

            var grid = ConvertFrom(data);

            var count = new NumberOfIslands().NumIslands(grid);
            Console.WriteLine($"TestA 岛的数量是：{count}");
        }

        private void TestB()
        {
            //  输入:
            //  11000
            //  11000
            //  00100
            //  00011

            //  输出: 3
            var data = new char[,]
            {
                {'1','1', '0', '0', '0' },
                {'1','1', '0', '0', '0' },
                {'0','0', '1', '0', '0' },
                {'0','0', '0', '1', '1' },
            };

            var grid = ConvertFrom(data);

            var count = new NumberOfIslands().NumIslands(grid);

            Console.WriteLine($"TestB 岛的数量是：{count}");

        }

        private static char[][] ConvertFrom(char[,] data)
        {
            var row = data.GetLength(0);
            var col = data.GetLength(1);

            var grid = new char[row][];
            for (int i = 0; i < row; i++)
            {
                grid[i] = new char[col];
                for (int j = 0; j < col; j++)
                {
                    grid[i][j] = data[i, j];
                }
            }

            return grid;
        }

    }
}
