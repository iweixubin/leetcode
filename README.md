## 好好学习，天天向上~

LeetCode 题解 C# 版本~

### 推荐书籍

 * 《图解算法》

### 推荐文章

 * [用动画的形式呈现解 LeetCode 题目的思路](https://github.com/MisterBooo/LeetCodeAnimation)

 * [LeetCode 题解](https://github.com/azl397985856/leetcode)

### 知识点

#### 排序
 
 * 选择排序(Selection Sort) —— 简单直观的排序算法，O(n^2)
 * 快速排序(Quick Sort) —— 分而治之

   https://github.com/hustcc/JS-Sorting-Algorithm

#### 递归

如何将问题分成 **基线条件(Base Case)** 和 **递归条件(Recursive Case)**~
 * **递归条件(Recursive Case)** —— 指的是函数继续调用自己
 * **基线条件(Base Case)** —— 指的是函数不再调用自己，从而避免无限循环~

 * 广度优先搜索(Breadth First Search)
 * 动态规划(Dynamic Programming)，一种思维，需要深入研究。
 * 记忆化搜索(Memory Search)

### 分而治之(divide & conquer D&C)

分而治之的步骤：
 1. 找出基线条件，这个条件必须尽可能简单
 2. 不断将问题分解(或者说缩小规模)，直到符合基线条件

分而治之的好基友：归纳证明
详情看《图解算法》

### 项目结构

 * Basic 不是 LeetCode 的题目，是一些数据结构或排序算法的实现
   * Basic.Tests 是对应测试用例
 * LeetCode 题目是也
   * 类文件名字前面的数字是题目编码
   * LeetCode.Tests 是对应测试用例
 * TopInterviewQuestions 是 LeetCode 官方推出的经典面试题目
   * 类文件名字前面的数字是我自己添加的，目的是为了按题目的顺序

### 完成的 LeetCode 题目

 * 题目(英文版)：https://leetcode.com/problems/xx-yy-zz
 * 题目(中文版)：https://leetcode-cn.com/problems/xx-yy-zz

   自行替换 `xx-yy-zz` 成下面表格 `Name` 列  
   如：https://leetcode-cn.com/problems/number-of-islands  
   如：https://leetcode-cn.com/problems/perfect-squares

| ID  | Name              | 中文名     | 难度 | 是否通过 LeetCode 的测试用例 |
| --- | ----------------- | ---------- | ---- | ---------------------------- |
| 200 | Number of Islands | 岛屿数量   | 中等 | ✔                            |
| 249 | Perfect Squares   | 完全平方数 | 中等 | ✔                            |
| 752 | Open the Lock     | 打开转盘锁 | 中等 | ✔                            |
