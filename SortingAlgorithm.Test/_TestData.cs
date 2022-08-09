using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Linq;

namespace SortingAlgorithm.Test
{
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
            };

            return cases;
        }

        public static Case[] Cases
        {
            get
            {
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