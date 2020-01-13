using System;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace ArrayLeftRotation
{
    public class SolutionTests
    {
        private readonly ITestOutputHelper _output;
        public SolutionTests(ITestOutputHelper output)
        {
            _output = output;
            Solution.Logger = output.WriteLine;
        }

        [Fact]
        public void BigExampleShiftLeft()
        {
            _output.WriteLine(nameof(BigExampleShiftLeft));
            var array = new [] {1, 2, 4, 6, 7, 3, 4, 2000, 29, 100, 5000, 100000, 5, 3, 9,
                                5, 6, 7, 8, 2, 3, 6, 9, 22, 204, 23467, 99765, 0, 5, 6, 7};
            var d = (array.Length / 2) - 1;
            _output.WriteLine($"d = {d}; n = {array.Length}");
            var expected = array.Skip(d).Concat(array.Take(d)).ToArray();
            var actual = Solution.rotLeft(array, d);
            Assert.Equal(expected, actual);
            _output.WriteLine($"{nameof(BigExampleShiftLeft)} end");
        }

        [Fact]
        public void BigExampleShiftRight()
        {
            _output.WriteLine(nameof(BigExampleShiftRight));
            var array = new [] {1, 2, 4, 6, 7, 3, 4, 2000, 29, 100, 5000, 100000, 5, 3, 9,
                                5, 6, 7, 8, 2, 3, 6, 9, 22, 204, 23467, 99765, 0, 5, 6, 7};
            var d = (array.Length / 2) + 1;
            _output.WriteLine($"d = {d}; n = {array.Length}");
            var expected = array.Skip(d).Concat(array.Take(d)).ToArray();
            var actual = Solution.rotLeft(array, d);
            Assert.Equal(expected, actual);
            _output.WriteLine($"{nameof(BigExampleShiftRight)} end");
        }

        [Fact]
        public void Example1()
        {
            var array = new [] {1, 2, 3, 4, 5};
            var d = 4;
            var expected = array.Skip(d).Concat(array.Take(d)).ToArray();
            var actual = Solution.rotLeft(array, d);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2()
        {
            var array = new [] {1, 2, 3, 4, 5};
            var d = 2;
            var expected = array.Skip(d).Concat(array.Take(d)).ToArray();
            var actual = Solution.rotLeft(array, d);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example3()
        {
            var array = new [] {1};
            var d = 1;
            var expected = array.Skip(d).Concat(array.Take(d)).ToArray();
            var actual = Solution.rotLeft(array, d);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example4()
        {
            var array = new [] {1, 2, 3, 4, 5};
            var d = 5;
            var expected = array.Skip(d).Concat(array.Take(d)).ToArray();
            var actual = Solution.rotLeft(array, d);
            Assert.Equal(expected, actual);
        }
    }
}
