using System;
using System.Collections.Generic;
using System.IO;

namespace cSharp
{
    public class Day3
    {
        public static void Solve()
        {
            string data = System.IO.File.ReadAllText("/Users/raamChauhan/Projects/adventOfCode2019/inputs/day3_input1.txt");
            string firstInput = data.Split('\n')[0];
            var secondInput = data.Split('\n')[1];

            //string firstInput = "R8,U5,L5,D3";
            //string secondInput = "U7,R6,D4,L4";

            var origin = new Coordinates(0, 0);
            List<Coordinates> firstWire = new List<Coordinates> { origin };
            List<Coordinates> secondWire = new List<Coordinates> { origin };

            foreach (var pathStep in firstInput.Split(','))
            {
                AddStep(firstWire, pathStep);
            }

            foreach (var pathStep in secondInput.Split(','))
            {
                AddStep(secondWire, pathStep);
            }


            List<Coordinates> intersections = new List<Coordinates>();
            foreach (var coord in secondWire)
            {
                if (firstWire.Contains(coord) && !coord.Equals(origin))
                {
                    Console.WriteLine($"Intersection at ({coord.x}, {coord.y})");
                    intersections.Add(coord);
                }
            }

            List<int> manhattanDistances = new List<int>();
            foreach (var coord in intersections)
            {
                manhattanDistances.Add(GetManhattanDistance(coord));
            }

            manhattanDistances.Sort();
            var shortestDistance = manhattanDistances[0];
            Console.WriteLine($"Part 1: {shortestDistance}");

            List<int> totalSteps = new List<int>();
            foreach (var coord in intersections)
            {
                var firstWireSteps = firstWire.IndexOf(coord);
                var secondWireSteps = secondWire.IndexOf(coord);

                totalSteps.Add(firstWireSteps + secondWireSteps);
            }
            totalSteps.Sort();
            var leastSteps = totalSteps[0];
            Console.WriteLine($"Part 2: {leastSteps}");
        }

        private static void AddStep(List<Coordinates> wirePath, string pathStep)
        {
            char direction = pathStep[0];
            int distance = Int32.Parse(pathStep.Substring(1));

            switch (direction)
            {
                case 'R':
                    for (int i = 0; i < distance; i++)
                    {
                        var currentPosition = wirePath[wirePath.Count - 1];
                        wirePath.Add(new Coordinates(currentPosition.x + 1, currentPosition.y));
                    }

                    break;
                case 'L':
                    for (int i = 0; i < distance; i++)
                    {
                        var currentPosition = wirePath[wirePath.Count - 1];
                        wirePath.Add(new Coordinates(currentPosition.x - 1, currentPosition.y));
                    }
                    break;
                case 'U':
                    for (int i = 0; i < distance; i++)
                    {
                        var currentPosition = wirePath[wirePath.Count - 1];
                        wirePath.Add(new Coordinates(currentPosition.x, currentPosition.y + 1));
                    }
                    break;
                case 'D':
                    for (int i = 0; i < distance; i++)
                    {
                        var currentPosition = wirePath[wirePath.Count - 1];
                        wirePath.Add(new Coordinates(currentPosition.x, currentPosition.y - 1));
                    }
                    break;
            }
        }

        private static int GetManhattanDistance(Coordinates coord)
        {
            return Math.Abs(coord.x) + Math.Abs(coord.y);
        }


    }

    public class Coordinates : IEquatable<Coordinates>
    {
        public int x;
        public int y;

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Coordinates other)
        {
            return this.x == other.x
                && this.y == other.y;
        }

        public void Print()
        {
            Console.WriteLine($"({this.x}, {this.y})");
        }
    }
}


