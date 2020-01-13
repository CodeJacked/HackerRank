using System;
using System.Linq;
using Xunit;

namespace TwoDArrayDS
{
    public class SolutionsTest
    {
        [Fact]
        public void Example1()
        {
            var array = new []{
                new [] {-9, -9, -9,  1, 1, 1}, 
                new [] { 0, -9,  0,  4, 3, 2},
                new [] {-9, -9, -9,  1, 2, 3},
                new [] { 0,  0,  8,  6, 6, 0},
                new [] { 0,  0,  0, -2, 0, 0},
                new [] { 0,  0,  1,  2, 4, 0}
            };

            var expectedHourGlassSum = new []{
                new [] {-63, -34, -9, 12}, 
                new [] {-10,   0, 28, 23}, 
                new [] {-27, -11, -2, 10}, 
                new [] {  9,  17, 25, 18}
            };

            var highestValueHourGlass = new [] {
                new [] {0, 4, 3},
                new []    {1},
                new [] {8, 6, 6}
            };

            var highestValueHourGlassSum = highestValueHourGlass.SelectMany(x => x).Sum();

            var actualSum = Solution.hourglassSum(array);
            Assert.Equal(highestValueHourGlassSum, actualSum);
        }

        [Fact]
        public void Example2()
        {
            var array = new []{
                new [] {1, 1, 1, 0, 0, 0}, 
                new [] {0, 1, 0, 0, 0, 0},
                new [] {1, 1, 1, 0, 0, 0},
                new [] {0, 0, 2, 4, 4, 0},
                new [] {0, 0, 0, 2, 0, 0},
                new [] {0, 0, 1, 2, 4, 0}
            };

            var highestValueHourGlass = new [] {
                new [] {2, 4, 4},
                new []    {2},
                new [] {1, 2, 4}
            };

            var highestValueHourGlassSum = highestValueHourGlass.SelectMany(x => x).Sum();

            var actualSum = Solution.hourglassSum(array);
            Assert.Equal(highestValueHourGlassSum, actualSum);
        }

        [Fact]
        public void Example3()
        {
            var array = new []{
                new [] {1, 1, 1, 0, 0, 0}, 
                new [] {0, 1, 0, 0, 0, 0},
                new [] {1, 1, 1, 0, 0, 0},
                new [] {0, 9, 2, -4, -4, 0},
                new [] {0, 0, 0, -2, 0, 0},
                new [] {0, 0, -1, -2, -4, 0}
            };

            var highestValueHourGlassSum = 13;

            var actualSum = Solution.hourglassSum(array);
            Assert.Equal(highestValueHourGlassSum, actualSum);
        }

        [Fact]
        public void Example4()
        {
            var array = new []{
                new [] {-9, -9, -9, 1, 1, 1}, 
                new [] {0, -9, 0, 4, 3, 2},
                new [] {-9, -9, -9, 1, 2, 3},
                new [] {0, 0, 8, 6, 6, 0},
                new [] {0, 0, 0,-2, 0, 0},
                new [] {0, 0, 1, 2, 4, 0}
            };

            var highestValueHourGlassSum = 28;

            var actualSum = Solution.hourglassSum(array);
            Assert.Equal(highestValueHourGlassSum, actualSum);
        }

        [Fact]
        public void ExampleTopLeft()
        {
            var array = new []{
                new [] {1, 1, 1, 0, 0, 0}, 
                new [] {0, 1, 0, 0, 0, 0},
                new [] {1, 1, 1, 0, 0, 0},
                new [] {0, 0, 0, 0, 0, 0},
                new [] {0, 0, 0, 0, 0, 0},
                new [] {0, 0, 0, 0, 0, 0}
            };

            var highestValueHourGlass = new [] {
                new [] {1, 1, 1},
                new []    {1},
                new [] {1, 1, 1}
            };

            var highestValueHourGlassSum = highestValueHourGlass.SelectMany(x => x).Sum();

            var actualSum = Solution.hourglassSum(array);
            Assert.Equal(highestValueHourGlassSum, actualSum);
        }

        [Fact]
        public void ExampleTopRight()
        {
            var array = new []{
                new [] {0, 0, 0, 1, 1, 1}, 
                new [] {0, 0, 0, 0, 1, 0},
                new [] {0, 0, 0, 1, 1, 1},
                new [] {0, 0, 0, 0, 0, 0},
                new [] {0, 0, 0, 0, 0, 0},
                new [] {0, 0, 0, 0, 0, 0}
            };

            var highestValueHourGlass = new [] {
                new [] {1, 1, 1},
                new []    {1},
                new [] {1, 1, 1}
            };

            var highestValueHourGlassSum = highestValueHourGlass.SelectMany(x => x).Sum();

            var actualSum = Solution.hourglassSum(array);
            Assert.Equal(highestValueHourGlassSum, actualSum);
        }

        [Fact]
        public void ExampleBottomLeft()
        {
            var array = new []{
                new [] {0, 0, 0, 0, 0, 0}, 
                new [] {0, 0, 0, 0, 0, 0},
                new [] {0, 0, 0, 0, 0, 0},
                new [] {1, 1, 1, 0, 0, 0},
                new [] {0, 1, 0, 0, 0, 0},
                new [] {1, 1, 1, 0, 0, 0}
            };

            var highestValueHourGlass = new [] {
                new [] {1, 1, 1},
                new []    {1},
                new [] {1, 1, 1}
            };

            var highestValueHourGlassSum = highestValueHourGlass.SelectMany(x => x).Sum();

            var actualSum = Solution.hourglassSum(array);
            Assert.Equal(highestValueHourGlassSum, actualSum);
        }

        [Fact]
        public void ExampleBottomRight()
        {
            var array = new []{
                new [] {0, 0, 0, 0, 0, 0}, 
                new [] {0, 0, 0, 0, 0, 0},
                new [] {0, 0, 0, 0, 0, 0},
                new [] {0, 0, 0, 1, 1, 1},
                new [] {0, 0, 0, 0, 1, 0},
                new [] {0, 0, 0, 1, 1, 1}
            };

            var highestValueHourGlass = new [] {
                new [] {1, 1, 1},
                new []    {1},
                new [] {1, 1, 1}
            };

            var highestValueHourGlassSum = highestValueHourGlass.SelectMany(x => x).Sum();

            var actualSum = Solution.hourglassSum(array);
            Assert.Equal(highestValueHourGlassSum, actualSum);
        }

        [Fact]
        public void ExampleNegatives()
        {
            var array = new []{
                new [] {-1, -1, 0, -9, -2, -2}, 
                new [] {-2, -1, -6, -8, -2, -5},
                new [] {-1, -1, -1, -2, -3, -4},
                new [] {-1, -9, -2, -4, -4, -5},
                new [] {-7, -3, -3, -2, -9, -9},
                new [] {-1, -3, -1, -2, -4, -5}
            };

            var highestValueHourGlass = new [] {
                new [] {1, 1, 1},
                new []    {1},
                new [] {1, 1, 1}
            };

            var highestValueHourGlassSum = -6;

            var actualSum = Solution.hourglassSum(array);
            Assert.Equal(highestValueHourGlassSum, actualSum);
        }
    }
}