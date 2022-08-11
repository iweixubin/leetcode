using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;
namespace DotNet.Test
{
    public class TaskAsync_Test
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public TaskAsync_Test(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact(Timeout = 1000)]
        public async void Test_ThreadSleep()
        {
            Thread.Sleep(3000);// 没有超时
            await Task.CompletedTask;
        }

        [Fact]
        public async void Test_TaskCompleted()
        {
            _testOutputHelper.WriteLine("TaskCompleted before await, current thread id: {0}", Thread.CurrentThread.ManagedThreadId.ToString());

            await Task.CompletedTask;//执行到await Task.CompletedTask时，由于await的Task.CompletedTask已经处于完成状态，所以.NET Core判定await关键字后面的代码还是由调用TaskCompleted()方法的线程（主线程）来执行，所以实际上整个TaskCompleted()方法是单线程同步执行的

            _testOutputHelper.WriteLine("TaskCompleted after await, current thread id: {0}", Thread.CurrentThread.ManagedThreadId.ToString());

            Thread.Sleep(3000);//阻塞线程3秒钟，模拟耗时的操作

            _testOutputHelper.WriteLine("TaskCompleted finished!");
        }
    }
}