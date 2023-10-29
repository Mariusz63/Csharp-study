using System;
using System.Collections.Generic;

namespace MiniLabirintGame
{
    public class Class
    {
        static int mazeSize = 10;
        static char[,] maze;
        static Random random = new Random();

        public Class() { }


        public bool Game()
        {
            InitializeMaze();
            GenerateMaze(new Position(1, 1));
            EnsureExitSafety();
            DisplayMaze();

            Console.WriteLine("Welcome to the Random Maze Game!");
            Console.WriteLine("Find your way from 'S' to 'E'. Use WASD keys to move.");

            int playerX = 1;
            int playerY = 1;
            int exitX = mazeSize - 2;
            int exitY = mazeSize - 2;

            while (true)
            {
                DisplayMaze(playerX, playerY);
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                char key = keyInfo.KeyChar;

                int newPlayerX = playerX;
                int newPlayerY = playerY;

                switch (key)
                {
                    case 'w':
                        newPlayerY--;
                        break;
                    case 's':
                        newPlayerY++;
                        break;
                    case 'a':
                        newPlayerX--;
                        break;
                    case 'd':
                        newPlayerX++;
                        break;
                    case 'q':
                        return false; // You lose
                }

                if (newPlayerX == exitX && newPlayerY == exitY)
                {
                    return true; // You win
                }

                if (newPlayerX >= 1 && newPlayerX < mazeSize - 1 &&
                    newPlayerY >= 1 && newPlayerY < mazeSize - 1 &&
                    maze[newPlayerY, newPlayerX] != '#')
                {
                    playerX = newPlayerX;
                    playerY = newPlayerY;
                }
            }
        }

        static void InitializeMaze()
        {
            maze = new char[mazeSize, mazeSize];

            for (int y = 0; y < mazeSize; y++)
            {
                for (int x = 0; x < mazeSize; x++)
                {
                    maze[y, x] = '#'; // Set all cells as walls
                }
            }

            maze[1, 1] = 'S'; // Start
            maze[mazeSize - 2, mazeSize - 2] = 'E'; // Exit
        }

        static void GenerateMaze(Position start)
        {
            Stack<Position> stack = new Stack<Position>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                Position current = stack.Peek();
                maze[current.Y, current.X] = ' ';

                List<Position> neighbors = GetUnvisitedNeighbors(current);

                if (neighbors.Count > 0)
                {
                    Position next = neighbors[random.Next(neighbors.Count)];
                    RemoveWall(current, next);
                    stack.Push(next);
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        static List<Position> GetUnvisitedNeighbors(Position current)
        {
            List<Position> neighbors = new List<Position>();

            Position[] possibleNeighbors = new Position[]
            {
                new Position(current.X, current.Y - 2),
                new Position(current.X, current.Y + 2),
                new Position(current.X - 2, current.Y),
                new Position(current.X + 2, current.Y),
            };

            foreach (Position neighbor in possibleNeighbors)
            {
                if (IsValidPosition(neighbor) && maze[neighbor.Y, neighbor.X] == '#')
                {
                    neighbors.Add(neighbor);
                }
            }

            return neighbors;
        }

        static bool IsValidPosition(Position position)
        {
            return position.X > 0 && position.X < mazeSize - 1 &&
                   position.Y > 0 && position.Y < mazeSize - 1;
        }

        static void RemoveWall(Position current, Position next)
        {
            int x = (current.X + next.X) / 2;
            int y = (current.Y + next.Y) / 2;
            maze[y, x] = ' ';
        }

        static void DisplayMaze(int playerX = -1, int playerY = -1)
        {
            Console.Clear();
            for (int y = 0; y < mazeSize; y++)
            {
                for (int x = 0; x < mazeSize; x++)
                {
                    if (x == playerX && y == playerY)
                        Console.Write('P');
                    else
                        Console.Write(maze[y, x]);
                }
                Console.WriteLine();
            }
        }

        static void EnsureExitSafety()
        {
            for (int i = mazeSize - 1; i >= mazeSize - 3; i--)
            {
                maze[i, mazeSize - 2] = ' ';
            }
        }
    }

    class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
