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

namespace ArraysLeftRotation
{
    class Solution
    {
        public static Action<string> Logger = null;
        // Complete the rotLeft function below.
        public static int[] rotLeft(int[] a, int d)
        {
            // Constraints
            // 1 <= n < 10^5
            // The array has a minimum of 1 and a maximum of 10^5 = 100,000 members.
            // 1 <= d <= n
            // The minimum and maximum sizes of each member is 1 and 10^6 = 1,000,000, respectively.
            // 1 <= a[i] <= 10^6
            // The minimum and maximum rotations (d) is 1 and the number of members in the array, repectively.

            // brute force...
            // 1. Pull out one member at a time and shift the rest left. 
            // 2. Add the member to the end of the array.
            // 3. Repeat for d - 1 more rotations.
            // Would take d * n-1 shifts = O(dn + d), with O(1) space.

            // Optimized with one array
            // 1. Allocate whose size is the smaller of d or n - d.
            // 2. Load the smaller set of members into the temp array.
            // 3. Shift the larger set by the offset.
            // 4. Load the smaller set at the end of the array.
            // Same performance as the two array method but with either 0(n - d) or O(d) space.

            // Or just create a new array of the same size and rotate the original array
            // into the new array... =/

            if(a.Length <= 1 || a.Length == d) return a;

            var n = a.Length;
            int[] rotated = new int[n];

            Array.Copy(a, 0, rotated, n - d, d);
            Array.Copy(a, d, rotated, 0, n - d);

            return rotated;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nd = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nd[0]);

            int d = Convert.ToInt32(nd[1]);

            int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
            ;
            int[] result = rotLeft(a, d);

            textWriter.WriteLine(string.Join(" ", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }
}
