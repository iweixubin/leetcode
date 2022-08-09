using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    public class T_200_NumberOfIslands_Test
    {
        [Fact]
        public void TestA()
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
            var expected = 1;

            var grid = ConvertFrom(data);
            var count = new NumberOfIslands().NumIslands(grid);

            Assert.Equal(expected, count);
        }

        [Fact]
        public void TestB()
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
            var expected = 3;

            var grid = ConvertFrom(data);
            var count = new NumberOfIslands().NumIslands(grid);

            Assert.Equal(expected, count);
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
