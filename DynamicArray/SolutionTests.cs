using System;
using Xunit;

namespace DynamicArray
{
    public class SolutionTests
    {
        [Fact]
        public void Example1()
        {
            var n = 2;
            var input = new [] {
                "1 0 5",
                "1 1 7",
                "1 0 3",
                "2 1 0",
                "2 1 1"
            };
            var expected = new [] {7, 3};

            var queries = InputConverter.ConvertToQueries(input);

            var result = Result.dynamicArray(n, queries);
            Assert.Equal(expected, result);
        }
    }
}
