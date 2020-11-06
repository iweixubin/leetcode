using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace Basic.Tests
{
    class TestData
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

        static Case[] GetCases()
        {
            //Random random = new Random();
            //random.Next()
            Case[] cases = new Case[] {
                new Case {
                Input = new int[] { 7, 4 },
                Expected = new int[] { 4, 7 }
                },
                new Case {
                Input = new int[] { 7, 4 },
                Expected = new int[] { 4, 7 }
                },
            };

            return cases;
        }

        public static Case[] Cases
        {
            get
            {
                return GetCases();
            }
        }
    }
}