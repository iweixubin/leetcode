using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;

namespace SortingAlgorithm.Test
{
    public static class Expiration
    {
        public const int Second = 1000;

        public const int Timeout = Second * 3;
    }

    public static class TestData
    {
        public class Case
        {
            /// <summary>
            /// 输入值
            /// </summary>
            public int[] Input { get; set; }

            /// <summary>
            /// 期待值
            /// </summary>
            public int[] Expected { get; set; }
        }

        static Case[] SomeCases()
        {
            Case[] cases = new Case[] {
                new Case {
                    Input = new int[] { 7 },
                    Expected = new int[] { 7 }
                },
                    new Case {
                    Input = new int[] { 3, 7 },
                    Expected = new int[] { 3, 7 }
                },
                    new Case {
                    Input = new int[] { 7, 3 },
                    Expected = new int[] { 3, 7 }
                },
                    new Case {
                    Input = new int[] { 7, 7, 7 },
                    Expected = new int[] { 7, 7, 7 }
                },
                new Case {
                    Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                    Expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
                },
                new Case {
                    Input = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                    Expected = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }
                },
                new Case {
                    Input = new int[] { 4, 1, 3, 9, 7 },
                    Expected = new int[] { 1, 3, 4, 7, 9 }
                },
                new Case {
                    Input = new int[] { 4, 1, 3, 3, 9, 7 },
                    Expected = new int[] { 1, 3, 3, 4, 7, 9 }
                },
                new Case{
                    Input=new int[] {13, 14, 94, 33, 82, 25, 59, 94, 65, 23, 45, 27, 73, 25, 39, 10},
                    Expected=new int[] {10, 13, 14, 23, 25, 25, 27, 33, 39, 45, 59, 65, 73, 82, 94, 94}
                },
                new Case{
                    Input=new int[] {55, 94, 87, 1, 4, 32, 11, 77, 39, 42, 64, 53, 70, 12, 9},
                    Expected=new int[] {1, 4, 9, 11, 12, 32, 39, 42, 53, 55, 64, 70, 77, 87, 94}
                }
            };

            return cases;
        }

        public static Case[] Cases
        {
            get
            {
                // 防止多次运行，改变了 Input 和 Expected
                var cases = SomeCases();
                Case[] clones = new Case[cases.Length];
                for (int i = 0; i < cases.Length; i++)
                {
                    clones[i] = new Case
                    {
                        Input = cases[i].Input.ToArray(),
                        Expected = cases[i].Expected.ToArray(),
                    };
                }
                return clones;
            }
        }
    }
}