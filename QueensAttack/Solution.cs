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

namespace QueensAttack
{
    class Solution
    {

        // Complete the queensAttack function below.

        public static int queensAttack(int n, int k, int r_q, int c_q, int[][] obstacles)
        {
            obstacles = DetermineClosest(r_q, c_q, obstacles);
            var count = 0;
            for (var squares = 1; squares < n; squares++)
            {
                var r = r_q + squares;
                if (r <= n)
                    count += ProcessColumns(n, squares, r, r_q, c_q, obstacles);

                count += ProcessColumns(n, squares, r_q, r_q, c_q, obstacles);

                r = r_q - squares;
                if (r >= 1)
                    count += ProcessColumns(n, squares, r, r_q, c_q, obstacles);
            }

            return count;
        }

        private static int[][] DetermineClosest(int r_q, int c_q, int[][] obstacles)
        {
            int[] topLeft = null;
            var topLeftDistance = int.MaxValue;
            int[] topCenter = null;
            var topCenterDistance = int.MaxValue;
            int[] topRight = null;
            var topRightDistance = int.MaxValue;
            int[] centerLeft = null;
            var centerLeftDistance = int.MaxValue;
            int[] centerRight = null;
            var centerRightDistance = int.MaxValue;
            int[] bottomLeft = null;
            var bottomLeftDistance = int.MaxValue;
            int[] bottomCenter = null;
            var bottomCenterDistance = int.MaxValue;
            int[] bottomRight = null;
            var bottomRightDistance = int.MaxValue;

            for(var i = 0; i < obstacles.Length; i++)
            {
                var distanceFromQueen = (int) (Math.Abs((decimal) r_q - obstacles[i][0]) + 
                    Math.Abs((decimal) c_q - obstacles[i][1]));
                var sameRowAsQueen = r_q == obstacles[i][0];
                var sameColumnAsQueen = c_q == obstacles[i][1];

                if(sameRowAsQueen)
                {
                    if(obstacles[i][1] > c_q)
                    {
                        if(centerRight == null || distanceFromQueen < centerRightDistance)
                        {
                            centerRightDistance = distanceFromQueen;
                            centerRight = obstacles[i];
                        }

                        continue;
                    }

                    if(centerLeft == null || distanceFromQueen < centerLeftDistance)
                    {
                        centerLeftDistance = distanceFromQueen;
                        centerLeft = obstacles[i];
                    }

                    continue;
                }

                if(sameColumnAsQueen)
                {
                    if(obstacles[i][0] > r_q)
                    {
                        if(topCenter == null || distanceFromQueen < topCenterDistance)
                        {
                            topCenterDistance = distanceFromQueen;
                            topCenter = obstacles[i];
                        }

                        continue;
                    }

                    if(bottomCenter == null || distanceFromQueen < bottomCenterDistance)
                    {
                        bottomCenterDistance = distanceFromQueen;
                        bottomCenter = obstacles[i];
                    }

                    continue;
                }

                decimal rise = r_q - obstacles[i][0];
                decimal run = c_q - obstacles[i][1];
                decimal slope = run == 0 ? 0 : rise / run;

                if(slope == 1)
                {
                    if(obstacles[i][0] < r_q)
                    {
                        if(bottomLeft == null || distanceFromQueen < bottomLeftDistance)
                        {
                            bottomLeftDistance = distanceFromQueen;
                            bottomLeft = obstacles[i];
                        }

                        continue;
                    }

                    if(topRight == null || distanceFromQueen < topRightDistance)
                    {
                        topRightDistance = distanceFromQueen;
                        topRight = obstacles[i];
                    }
                    continue;
                }

                if(slope == -1)
                {
                    if(obstacles[i][0] < r_q)
                    {
                        if(bottomRight == null || distanceFromQueen < bottomRightDistance)
                        {
                            bottomRightDistance = distanceFromQueen;
                            bottomRight = obstacles[i];
                        }

                        continue;
                    }

                    if(topLeft == null || distanceFromQueen < topLeftDistance)
                    {
                        topLeftDistance = distanceFromQueen;
                        topLeft = obstacles[i];
                    }
                    continue;
                }
            }

            return new int [8][] 
            {
                topLeft,
                topCenter,
                topRight,
                centerLeft,
                centerRight,
                bottomLeft,
                bottomCenter,
                bottomRight
            }.Where(x => x != null).ToArray();
        }

        private static int ProcessColumns(int n, int squares, int r, int r_q, int c_q, int[][] obstacles)
        {
            var count = 0;
            var c = c_q + squares;
            if (c <= n && !IsEnemyAt(r, c, r_q, c_q, obstacles))
                count++;

            if (r != r_q && !IsEnemyAt(r, c_q, r_q, c_q, obstacles))
                count++;

            c = c_q - squares;
            if (c >= 1 && !IsEnemyAt(r, c, r_q, c_q, obstacles))
                count++;

            return count++;
        }

        private static bool IsEnemyAt(int r, int c, int r_q, int c_q, int[][] obstacles)
        {
            int distanceFromQueen = (int) (Math.Abs((decimal) r_q - r) + Math.Abs((decimal) c_q - c));
            int enemyDistanceFromQueen;
            decimal rise = r_q - r;
            decimal run = c_q - c;
            decimal slope = run == 0 ? 0 : rise / run;

            for (var i = 0; i < obstacles.Length; i++)
            {
                // do we have a direct hit?
                if (obstacles[i][0] == r && obstacles[i][1] == c) 
                    return true;

                var enemyIsSameRowAsQueen = r_q == obstacles[i][0];
                var enemyIsSameColumnAsQueen = c_q == obstacles[i][1];
                enemyDistanceFromQueen = (int) (Math.Abs((decimal) r_q - obstacles[i][0]) + 
                    Math.Abs((decimal) c_q - obstacles[i][1]));

                // Is the point is the same row as the queen?
                if(r == r_q)
                {
                    if (enemyIsSameRowAsQueen) 
                    {
                        if((c < c_q && obstacles[i][1] < c_q) ||
                            (c > c_q && obstacles[i][1] > c_q))
                        {
                            // is our point closer to the queen than the enemy?
                            if(distanceFromQueen > enemyDistanceFromQueen) 
                                return true;
                        }
                    }

                    continue;
                }

                // Is the point is the same column as the queen?
                if(c == c_q)
                {
                    if (enemyIsSameColumnAsQueen) 
                    {
                        if((r < r_q && obstacles[i][0] < r_q) ||
                            (r > r_q && obstacles[i][0] > r_q))
                        {
                            // is our point closer to the queen than the enemy?
                            if(distanceFromQueen > enemyDistanceFromQueen) 
                                return true;
                        }
                    }

                    continue;
                }

                if(enemyIsSameRowAsQueen || enemyIsSameColumnAsQueen) continue;

                // Is the point diagonal from the queen?

                decimal enemyRise = r_q - obstacles[i][0];
                decimal enemyRun = c_q - obstacles[i][1];
                decimal enemySlope = enemyRun == 0 ? 0 : enemyRise / enemyRun;
                if(slope != enemySlope) continue;

                if((r > r_q && obstacles[i][0] > r_q)||
                   (r < r_q && obstacles[i][0] < r_q))
                {
                    if(distanceFromQueen > enemyDistanceFromQueen) 
                        return true;
                }
            }

            return false;
        }

        static void Main(string[] args)
        {
            TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

            string[] nk = Console.ReadLine().Split(' ');

            int n = Convert.ToInt32(nk[0]);

            int k = Convert.ToInt32(nk[1]);

            string[] r_qC_q = Console.ReadLine().Split(' ');

            int r_q = Convert.ToInt32(r_qC_q[0]);

            int c_q = Convert.ToInt32(r_qC_q[1]);

            int[][] obstacles = new int[k][];

            for (int i = 0; i < k; i++)
            {
                obstacles[i] = Array.ConvertAll(Console.ReadLine().Split(' '), obstaclesTemp => Convert.ToInt32(obstaclesTemp));
            }

            int result = queensAttack(n, k, r_q, c_q, obstacles);

            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}