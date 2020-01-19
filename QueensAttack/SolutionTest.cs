using System;
using System.IO;
using Xunit;

namespace QueensAttack
{
    public class SolutionTest
    {
        [Fact]
        public void Example1()
        {
            var n = 8;
            var q = new [] {4, 4};
            var k = new int[0][];
            var expected = 27;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2_bottom_right()
        {
            var n = 8;
            var q = new [] {4, 4};
            var k = new int [][]{
                new int []{3, 5}
            };
            var expected = 24;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);

            k[0] = new int []{2, 6};
            expected = 25;
            actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2_bottom_center()
        {
            var n = 8;
            var q = new [] {4, 4};
            var k = new int [][]{
                new int []{3, 4}
            };
            var expected = 24;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);

            k[0] = new int []{2, 4};
            expected = 25;
            actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2_bottom_left()
        {
            var n = 8;
            var q = new [] {4, 4};
            var k = new int [][]{
                new int []{3, 3}
            };
            var expected = 24;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);

            k[0] = new int []{2, 2};
            expected = 25;
            actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2_Top_Right()
        {
            var n = 8;
            var q = new [] {4, 4};
            var k = new int [][]{
                new int []{5, 5}
            };
            var expected = 23;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);

            k[0] = new int []{6, 6};
            expected = 24;
            actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2_Top_Center()
        {
            var n = 8;
            var q = new [] {4, 4};
            var k = new int [][]{
                new int []{5, 4}
            };
            var expected = 23;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);

            k[0] = new int []{6, 4};
            expected = 24;
            actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2_Top_Left()
        {
            var n = 8;
            var q = new [] {4, 4};
            var k = new int [][]{
                new int []{5, 3}
            };
            var expected = 24;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);

            k[0] = new int []{6, 2};
            expected = 25;
            actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2_Right()
        {
            var n = 8;
            var q = new [] {4, 4};
            var k = new int [][]{
                new int []{4, 5}
            };
            var expected = 23;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);

            k[0] = new int []{4, 6};
            expected = 24;
            actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Example2_Left()
        {
            var n = 8;
            var q = new [] {4, 4};
            var k = new int [][]{
                new int []{4, 3}
            };
            var expected = 24;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);

            k[0] = new int []{4, 2};
            expected = 25;
            actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sample0()
        {
            var n = 4;
            var q = new [] {4, 4};
            var k = new int [0][];
            var expected = 9;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sample1()
        {
            var n = 5;
            var q = new [] {4, 3};
            var k = new int [][]{
                new int []{5, 5},
                new int []{4, 2},
                new int []{2, 3}
            };
            var expected = 10;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Sample2()
        {
            var n = 1;
            var q = new [] {4, 3};
            var k = new int [0][];
            var expected = 0;
            var actual = Solution.queensAttack(n, k.Length, q[0], q[1], k);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase6()
        {
            var scenario = BuildScenario("../../../TestCase6.txt");
            var expected = 40;
            var actual = Solution.queensAttack(scenario.n, scenario.k, scenario.r_q, scenario.c_q, scenario.obstacles);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCase12()
        {
            var scenario = BuildScenario("../../../TestCase12.txt");
            var expected = 1449;
            var actual = Solution.queensAttack(scenario.n, scenario.k, scenario.r_q, scenario.c_q, scenario.obstacles);
            Assert.Equal(expected, actual);
        }

        private Scenario BuildScenario(string path)
        {
            Assert.True(File.Exists(path));

            using(var reader = new StreamReader(path))
            {
                string[] nk = reader.ReadLine().Split(' ');
                int n = Convert.ToInt32(nk[0]);
                int k = Convert.ToInt32(nk[1]);

                string[] r_qC_q = reader.ReadLine().Split(' ');
                int r_q = Convert.ToInt32(r_qC_q[0]);
                int c_q = Convert.ToInt32(r_qC_q[1]);

                int[][] obstacles = new int[k][];
                for (int i = 0; i < k; i++)
                    obstacles[i] = Array.ConvertAll(reader.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
            
                var scenario = new Scenario
                {
                    n = n,
                    k = k,
                    r_q = r_q,
                    c_q = c_q,
                    obstacles = obstacles
                };
                return scenario;
            }
        }

        public class Scenario
        {
            public int n { get; set;}
            public int k { get; set;}
            public int r_q { get; set;}
            public int c_q { get; set;}
            public int[][] obstacles { get; set;}
        }
    }
}
