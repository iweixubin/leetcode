using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    public class T_752_OpenTheLock_Test
    {
        [Fact]
        public void TestA()
        {
            var deadends = new string[] { "0201", "0101", "0102", "1212", "2002" };
            var target = "0202";
            var expected = 6;

            var step = new OpenTheLock().OpenLock(deadends, target);

            Assert.Equal(expected, step);
        }

        [Fact]
        public void TestB()
        {
            var deadends = new string[] { "8888" };
            var target = "0009";
            var expected = 1;

            var step = new OpenTheLock().OpenLock(deadends, target);

            Assert.Equal(expected, step);
        }

        [Fact]
        public void TestC()
        {
            var deadends = new string[] { "8887", "8889", "8878", "8898", "8788", "8988", "7888", "9888" };
            var target = "8888";
            var expected = -1;

            var step = new OpenTheLock().OpenLock(deadends, target);

            Assert.Equal(expected, step);
        }

        [Fact]
        public void TestD()
        {
            var deadends = new string[] { "0000" };
            var target = "8888";
            var expected = -1;

            var step = new OpenTheLock().OpenLock(deadends, target);

            Assert.Equal(expected, step);
        }
    }
}
