using System;
using Xunit;

namespace SparseArrays
{
    public class SolutionTests
    {
        [Fact]
        public void Example1()
        {
            var strings = new []
            {
                "aba",
                "baba",
                "aba",
                "xzxb"
            };

            var queries = new [] 
            {
                "aba",
                "xzxb",
                "ab"
            };

            var expected = new [] {2, 1, 0};

            var actual = Solution.matchingStrings(strings, queries);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2()
        {
            var strings = new []
            {
                "def",
                "de",
                "fgh"
            };

            var queries = new [] 
            {
                "de",
                "lmn",
                "fgh"
            };

            var expected = new [] {1, 0, 1};

            var actual = Solution.matchingStrings(strings, queries);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example3()
        {
            var strings = new []
            {
                "abcde",
                "sdaklfj",
                "asdjf",
                "na",
                "basdn",
                "sdaklfj",
                "asdjf",
                "na",
                "asdjf",
                "na",
                "basdn",
                "sdaklfj",
                "asdjf"
            };

            var queries = new [] 
            {
                "abcde",
                "sdaklfj",
                "asdjf",
                "na",
                "basdn"
            };

            var expected = new [] {1, 3, 4, 3, 2};

            var actual = Solution.matchingStrings(strings, queries);
            Assert.Equal(expected, actual);
        }
    }
}
