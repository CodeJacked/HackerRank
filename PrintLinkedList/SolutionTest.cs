using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace PrintLinkedList
{
    public class SolutionTest
    {
        private readonly ITestOutputHelper output;

        public SolutionTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            var input = new[] {
                "2",
                "16",
                "13"
            };
            var expected = input.Skip(1).ToArray();
            var actual = Execute(input).ToArray();
            Assert.Equal(expected, actual);
        }

        private IEnumerable<string> Execute(IEnumerable<string> input)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream, System.Text.Encoding.UTF8, 500, leaveOpen: true))
                {
                    streamWriter.AutoFlush = true;
                    Console.SetOut(streamWriter);
                    Console.SetError(streamWriter);

                    using (var streamReader = new StreamReader(memoryStream, System.Text.Encoding.UTF8, true, 500, leaveOpen: true))
                    {
                        var llist = Solution.ConvertToLinkedList(input.Skip(1));
                        Solution.printLinkedList(llist.head);
                        memoryStream.Position = 0;
                        var text = streamReader.ReadToEnd();
                        output.WriteLine("Received");
                        output.WriteLine(text);
                        var lines = text.Trim().Split("\r\n").Select(x => x.Trim());
                        return lines;
                    }
                }
            }
        }
    }
}
