using System;
using Xunit;

namespace EqualizeTheArray
{
    public class SolutionTests
    {
        [Fact]
        public void TestExample1()
        {
            var array = new [] { 1, 2, 2, 3 };
            var actual = Solution.equalizeArrayLinq(array);
            Assert.Equal(2, actual);

            actual = Solution.equalizeArray(array);
            Assert.Equal(2, actual);
        }

        [Fact]
        public void TestExample2()
        {
            var array = new [] { 3, 3, 2, 1, 3 };
            var actual = Solution.equalizeArrayLinq(array);
            Assert.Equal(2, actual);

            actual = Solution.equalizeArray(array);
            Assert.Equal(2, actual);
        }

        [Fact]
        public void TestBigExample3()
        {
            var array = new [] { 2, 4, 6, 3, 60, 4, 6 , 8, 1, 4, 9, 55, 2, 5, 6, 7, 8, 55, 2, 4, 6, 7 };
            /*
            2 - 3
            4 - 4
            6 - 4
            3 - 1
            60 - 1
            8 - 2
            1 - 1
            9 - 1
            55 - 2
            5 - 1
            7 - 2
            */
            var expected = array.Length - 4;
            var actual = Solution.equalizeArrayLinq(array);
            Assert.Equal(expected, actual);

            actual = Solution.equalizeArray(array);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test4()
        {
            var array = new [] { 2, 2, 2, 2, 2 };
            var actual = Solution.equalizeArrayLinq(array);
            Assert.Equal(0, actual);
            
            actual = Solution.equalizeArray(array);
            Assert.Equal(0, actual);
        }
    }
}
