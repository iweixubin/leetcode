using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace SortingAlgorithm
{
    /// <summary>
    /// 堆排序
    /// </summary>
    public static class HeapSort
    {
        // https://zh.wikipedia.org/wiki/%E5%A0%86%E6%8E%92%E5%BA%8F
        // https://www.runoob.com/w3cnote/heap-sort.html

        // 算法过程：
        // 堆的基本存储：https://m.runoob.com/data-structures/heap-storage.html
        // 堆的 shift up：https://m.runoob.com/data-structures/heap-shift-up.html
        // 堆的 shift down：https://m.runoob.com/data-structures/heap-shift-down.html
        // 基础堆排序：https://m.runoob.com/data-structures/heap-sort.html
        // 优化堆排序：https://m.runoob.com/data-structures/heap-sort-optimization.html
        // 索引堆及其优化：https://m.runoob.com/data-structures/heap-index.html

        // 算法过程：https://www.geeksforgeeks.org/heap-sort/

        // 数据结构是：完全二叉树 + 最大堆
        // 算法是：让 父节点 大于 子节点
        // 结果是：根节点 为最大值。
            
        /*

              100
            /     \
          19        36
        /    \     /  \
      17      3   25   1
     / \ 
    2   7
            
            完全二叉树只是定义了树的节点应该是怎么分布的，但对树节点上的值，没有做任何规定。
            完全二叉树 + 最大堆 定义了，根节点为最大值。其它节点保持父节点大于子节点就可以了。 看看 25 的位置
            用一维数组来构造 完全二叉树 + 最大堆，那么 [0]，就是根节点，也是最大值
            有点像 选择排序 —— 每次在剩下的中选择最大值。但比选择排序好的是，不用比较全部！！！
            我们将 最大值 100，拿走，将 7 放上去，要先去掉右边 - 完全二叉树的规定
            然后 7 和 19，36 比较，得 7 与 36 调换，
            然后 7 和 25，1  比较，得 7 与 25 调换，
            此时，又满足 完全二叉树 + 最大堆 的定义了，所以又得到一个最大值

              36
            /     \
          19        25
        /    \     /  \
      17      3   7   1
     /  
    2   

        */

        // 最大堆：根结点的键值是所有堆结点键值中最大者的堆。

        // 通常堆是通过一维数组来实现的。在数组起始位置为 0 的情形中：
        // 父节点i 的左子节点在位置 (2i+1);
        // 父节点i 的右子节点在位置 (2i+2);
        // 子节点i 的父节点在位置 (i-1)/2;

        // 堆是一个近似 完全二叉树的结构，并同时满足堆积的性质：即子结点的键值或索引总是小于（或者大于）它的父节点。

        public static void Sort(int[] nums)
        {
            var endIndex = nums.Length - 1;// 数组的最大索引值

            var mid = nums.Length / 2; // 取数组中间位置的值作为根节点，开始构造整个堆
            for (var i = mid; i > -1; i--)
            {
                // 这一步只是调整局部3个点能构成的堆
                // 也就是局部的三个点中，父节点最大。但根节点还可能不是最大。
                MaxHeapify(nums, i, endIndex);
            }

            // 定义上 一维数组实现的堆，nums[0] 就是根节点
            // 上面运行后，nums[0] 就是最大值

            for (var i = endIndex; i > 0; i--)
            {
                Swap(ref nums[0], ref nums[i]);// 将本次得到的最大值（nums[0]）放到适合的位置（从后往前）
                MaxHeapify(nums, 0, i - 1);// 尾部渐渐有序起来了（小 ← 大），再比较剩下的~
            }

            // 不好理解的话，看下面总结
            
            /*

              100
            /     \
          19        36
        /    \     /  \
      17      3   25   1
     / \ 
    2   7
            
            完全二叉树只是定义了树的节点应该是怎么分布的，但对树节点上的值，没有做任何规定。
            完全二叉树 + 最大堆 定义了，根节点为最大值。其它节点保持父节点大于子节点就可以了。 看看 25 的位置
            用一维数组来构造 完全二叉树 + 最大堆，那么 [0]，就是根节点，也是最大值
            有点像 选择排序 —— 每次在剩下的中选择最大值。但比选择排序好的是，不用比较全部！！！
            我们将 最大值 100，拿走，将 7 放上去，要先去掉右边 - 完全二叉树的规定
            然后 7 和 19，36 比较，得 7 与 36 调换，
            然后 7 和 25，1  比较，得 7 与 25 调换，
            此时，又满足 完全二叉树 + 最大堆 的定义了，所以又得到一个最大值
              36
            /     \
          19        25
        /    \     /  \
      17      3   7   1
     /  
    2   

            */
        }

        private static void MaxHeapify(int[] nums, int pIndex, int end)
        {
            // i 是 父节点
            var lIndex = 2 * pIndex + 1;// 左子节点在位置 (2i+1)
            if (lIndex > end) // 超出索引，也就是不存在左子节点
                return;// 为什么能直接 return 了呢，因为完全二叉树规定父节点有子节点的话，一定要在左边。

            // 下面代码违法完全二叉树的定义
            // pNode.Left = null;
            // pNode.Right = new Node();

            var localMax = lIndex;// 先假设左子节点上的数字为局部最大值

            var rIndex = 2 * pIndex + 2;// 右子节点在位置 (2i+2)
            // rNode <= end 表示存在右子节点
            // 如果 右子节点 比 左子节点 大，那么记录最大值的位置
            if (rIndex <= end && nums[rIndex] > nums[lIndex])
            {
                localMax = rIndex;
            }

            // 如果父节点 大于 
            if (nums[pIndex] > nums[localMax])
                return;

            Swap(ref nums[pIndex], ref nums[localMax]);// 如果父节点被子节点调换
            MaxHeapify(nums, localMax, end);// 则需要继续判断换下后的父节点是否符合堆的特性。
        }

        // 将方法编译成内联，减少调用堆栈
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Swap(ref int x, ref int y)
        {// 虽然很多排序算法会用到这个，但还是采用复制，这样每个文件自己是完整的。
            int t;
            t = x;
            x = y;
            y = t;
        }
    }
}
