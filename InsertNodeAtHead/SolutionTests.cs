using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace InsertNodeAtHead
{
    public class SolutionTests
    {
        private readonly ITestOutputHelper output;

        public SolutionTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Example1()
        {
            var input = new[] {
                "5",
                "383",
                "484",
                "392",
                "975",
                "321"
            };
            var expected = input.Skip(1).Reverse().ToArray();
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
                        Solution.PrintSinglyLinkedList(llist.head, "\n", streamWriter);
                        memoryStream.Position = 0;
                        var text = streamReader.ReadToEnd();
                        output.WriteLine("Received");
                        output.WriteLine(text);
                        var lines = text.Trim().Split("\n").Select(x => x.Trim());
                        return lines;
                    }
                }
            }
        }
    }
}
