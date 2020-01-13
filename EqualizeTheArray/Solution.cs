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

namespace EqualizeTheArray
{
    class Solution
    {

        // Complete the equalizeArray function below.
        public static int equalizeArray(int[] arr)
        {
            // look for the number with the most occurrances,
            // and remove the rest.
            var occurrances = new Dictionary<int, int>();
            var maxOccurrances = 0;
            foreach (var x in arr)
            {
                var count = 0;
                if (occurrances.TryGetValue(x, out count))
                {
                    count++;
                    occurrances[x] = count;
                }
                else
                {
                    count = 1;
                    occurrances.Add(x, count);
                }

                maxOccurrances = count > maxOccurrances ? count : maxOccurrances;
            }

            return arr.Length - maxOccurrances;
        }

        public static int equalizeArrayLinq(int[] arr)
        {
            // look for the number with the most occurrances,
            // and remove the rest.
            var occurrances = arr.GroupBy(x => x);
            var maxOccurrances = occurrances.Max(x => x.Count());
            return arr.Length - maxOccurrances;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int result = equalizeArray(arr);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}