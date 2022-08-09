# LeetCode 题解 C# 版本

## 二分查找

学**数据结构**与**算法**最好的入门例子是`二分查找`！！！  
让你体验了**数据结构**与**算法**配合，在40亿的数据中，只要十几次就能找到想要的数据。  
《图解算法》的第一个章就是讲`二分查找`的，推荐阅读！！！  

## 推荐书籍

 * 《图解算法》

## 推荐文章

 * [用动画的形式呈现解 LeetCode 题目的思路](https://github.com/MisterBooo/LeetCodeAnimation)
 * [LeetCode 题解](https://github.com/azl397985856/leetcode)

## 知识点

### 排序算法
 
十大经典排序算法(https://www.runoob.com/w3cnote/ten-sorting-algorithm.html)：
 * 冒泡排序
 * 选择排序
 * 插入排序
 * 希尔排序
 * 归并排序
 * 快速排序
 * 堆排序
 * 计数排序
 * 桶排序
 * 基数排序

名词解释：
| 名词      | 解释                                                |
| --------- | --------------------------------------------------- |
| In-place  | 占用常数内存，不占用额外内存                        |
| Out-place | 占用额外内存                                        |
| 稳定性    | 排序后 2 个相等键值的顺序和排序之前它们的顺序相同。 |

关于稳定性，WIKI 上有一张一看就明白的图：  
https://zh.wikipedia.org/zh-cn/%E6%8E%92%E5%BA%8F%E7%AE%97%E6%B3%95

### 递归

如何将问题分成 **基线条件(Base Case)** 和 **递归条件(Recursive Case)**~
 * **递归条件(Recursive Case)** —— 指的是函数继续调用自己
 * **基线条件(Base Case)** —— 指的是函数不再调用自己，从而避免无限循环~

 * 广度优先搜索(Breadth First Search)
 * 深度优先搜索(Depth First Search)
 * 动态规划(Dynamic Programming)，一种思维，需要深入研究。
 * 记忆化搜索(Memory Search)

### 分而治之(divide & conquer D&C)

分而治之的步骤：
 1. 找出基线条件，这个条件必须尽可能简单
 2. 不断将问题分解(或者说缩小规模)，直到符合基线条件

快速排序（quick-sort）就是这思想的一个经典应用！
分而治之的好基友：归纳证明
详情看《图解算法》

## 项目结构

 * SortingAlgorithm 不是 LeetCode 的题目，是一些数据结构或排序算法的实现
   * SortingAlgorithm.Test 是对应测试用例
 * LeetCode 题目是也
   * 类文件名字前面的数字是题目编码
   * LeetCode.Test 是对应测试用例
 * TopInterviewQuestions 是 LeetCode 官方推出的经典面试题目
   * 类文件名字前面的数字是我自己添加的，目的是为了按题目的顺序

## 完成的 LeetCode 题目

 * 题目(英文版)：https://leetcode.com/problems/xx-yy-zz
 * 题目(中文版)：https://leetcode.cn/problems/xx-yy-zz

   自行替换 `xx-yy-zz` 成下面表格 `Name` 列  
   如：https://leetcode.cn/problems/number-of-islands  
   如：https://leetcode.cn/problems/perfect-squares

| ID  | Name                                                                | 中文名     | 难度 | 通过 LeetCode 测试 | 思路         |
| --- | ------------------------------------------------------------------- | ---------- | ---- | ------------------ | ------------ |
| 200 | [number-of-islands](https://leetcode.cn/problems/number-of-islands) | 岛屿数量   | 中等 | ✔                  | 广度优先搜索 |
| 249 | [perfect-squares](https://leetcode.cn/problems/perfect-squares)     | 完全平方数 | 中等 | ✔                  |              |
| 752 | [open-the-lock](https://leetcode.cn/problems/open-the-lock)         | 打开转盘锁 | 中等 | ✔                  |              |