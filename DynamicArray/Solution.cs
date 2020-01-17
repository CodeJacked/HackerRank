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

namespace DynamicArray
{
    class Result
    {

        /*
         * Complete the 'dynamicArray' function below.
         *
         * The function is expected to return an INTEGER_ARRAY.
         * The function accepts following parameters:
         *  1. INTEGER n
         *  2. 2D_INTEGER_ARRAY queries
         */

        public static List<int> dynamicArray(int n, List<List<int>> queries)
        {
            var seqList = InitializeSequences(n);
            var answers = new List<int>();
            var lastAnswer = 0;

            foreach(var query in queries)
            {
                var queryType = query[0];
                var x = query[1];
                var y = query[2];
                var i = (x ^ lastAnswer) % n;
                var s = seqList[i];
                switch(queryType)
                {
                    case 1:
                        s.Add(y);
                        break;
                    case 2:
                        var elementIndex = y % s.Count;
                        lastAnswer = s[elementIndex];
                        answers.Add(lastAnswer);
                        break;
                    default:
                        throw new ArgumentException($"{queryType} is not a supported query");
                }
            }

            return answers;
        }

        private static List<List<int>> InitializeSequences(int n)
        {
            var seqList = new List<List<int>>();
            for(var i = 0; i < n; i++)
                seqList.Add(new List<int>());
            return seqList;
        }

    }

    class Solution
    {
        public static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int q = Convert.ToInt32(firstMultipleInput[1]);

            List<string> lines = new List<string>();

            for (int i = 0; i < q; i++)
                lines.Add(Console.ReadLine());

            var queries = InputConverter.ConvertToQueries(lines);

            List<int> result = Result.dynamicArray(n, queries);

            textWriter.WriteLine(String.Join("\n", result));

            textWriter.Flush();
            textWriter.Close();
        }
    }

    class InputConverter
    {
        public static List<List<int>> ConvertToQueries(IEnumerable<string> lines)
        {
            var queries = lines.Select(l => l.Trim().Split(' ').Select(x => int.Parse(x)).ToList()).ToList();
            return queries;
        }
    }
}