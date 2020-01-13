using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace TwoDArrayDS
{
    public class Solution
    {
        public static int hourglassSum(int[][] arr)
        {
            // Starting with y = 0, move through the array one member at a time from x = 0 to x = 4,
            // starting at y = 0. Then repeat for y = 1 through y = 4.
            // Store compare and store the maximum hour glass value.
            var maxSum = int.MinValue;
            for(var y = 0; y < arr.Length - 2; y++ )
            {
                for(var x = 0; x < arr.Length - 2; x++)
                {
                    var sum = arr[x][y]     + arr[x][y + 1]     + arr[x][y + 2] +
                                              arr[x + 1][y + 1] +
                              arr[x + 2][y] + arr[x + 2][y + 1] + arr[x + 2][y + 2];
                    maxSum = maxSum >= sum ? maxSum : sum;
                }
            }

            return maxSum;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int[][] arr = new int[6][];

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            int result = hourglassSum(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
