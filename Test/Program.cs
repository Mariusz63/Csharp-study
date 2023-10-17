using System;
using System.Collections.Generic;
using System.Linq;

class MapGenerator
{
    private const char Wall = '#';
    private const char Floor = '.';
    private const char Path = ' ';

    private int mapWidth;
    private int mapHeight;
    private char[,] map;

    public MapGenerator(int width, int height)
    {
        mapWidth = width;
        mapHeight = height;
        map = new char[mapWidth, mapHeight];
    }

    public void GenerateMap()
    {
        InitializeMap();
        GenerateRooms();
        ConnectRooms();
    }

    private void InitializeMap()
    {
        for (int x = 0; x < mapWidth; x++)
        {
            for (int y = 0; y < mapHeight; y++)
            {
                map[x, y] = Wall;
            }
        }
    }

    private void GenerateRooms()
    {
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            int roomWidth = random.Next(5, 15);
            int roomHeight = random.Next(5, 15);
            int roomX = random.Next(1, mapWidth - roomWidth - 1);
            int roomY = random.Next(1, mapHeight - roomHeight - 1);

            for (int x = roomX; x < roomX + roomWidth; x++)
            {
                for (int y = roomY; y < roomY + roomHeight; y++)
                {
                    map[x, y] = Floor;
                }
            }
        }
    }

    private void ConnectRooms()
    {
        Random random = new Random();
        for (int i = 1; i < 5; i++)
        {
            int startX = random.Next(1, mapWidth - 1);
            int startY = random.Next(1, mapHeight - 1);

            int endX = random.Next(1, mapWidth - 1);
            int endY = random.Next(1, mapHeight - 1);

            if (map[startX, startY] == Floor && map[endX, endY] == Floor)
            {
                List<Node> path = FindPath((startX, startY), (endX, endY));
                if (path != null)
                {
                    foreach (var node in path)
                    {
                        map[node.Position.X, node.Position.Y] = Path;
                    }
                }
            }
        }
    }

    private List<Node> FindPath((int X, int Y) start, (int X, int Y) end)
    {
        List<Node> openList = new List<Node>();
        List<Node> closedList = new List<Node>();
        Node startNode = new Node(start, null, 0, CalculateH(start, end));
        openList.Add(startNode);

        while (openList.Count > 0)
        {
            Node currentNode = openList.OrderBy(node => node.F).First();

            if (currentNode.Position == end)
            {
                return ReconstructPath(currentNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (var neighborPosition in GetNeighbors(currentNode.Position))
            {
                if (map[neighborPosition.X, neighborPosition.Y] == Wall || closedList.Any(node => node.Position == neighborPosition))
                {
                    continue;
                }

                double tentativeG = currentNode.G + CalculateG(currentNode.Position, neighborPosition);
                var neighbor = openList.FirstOrDefault(node => node.Position == neighborPosition);

                if (neighbor == null || tentativeG < neighbor.G)
                {
                    if (neighbor == null)
                    {
                        neighbor = new Node(neighborPosition, currentNode, 0, CalculateH(neighborPosition, end));
                        openList.Add(neighbor);
                    }

                    neighbor.Parent = currentNode;
                    neighbor.G = tentativeG;
                }
            }
        }

        return null;
    }

    private double CalculateH((int X, int Y) start, (int X, int Y) end)
    {
        return Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2));
    }

    private double CalculateG((int X, int Y) start, (int X, int Y) neighbor)
    {
        return Math.Sqrt(Math.Pow(neighbor.X - start.X, 2) + Math.Pow(neighbor.Y - start.Y, 2));
    }

    private List<Node> ReconstructPath(Node node)
    {
        List<Node> path = new List<Node> { node };
        while (node.Parent != null)
        {
            path.Add(node.Parent);
            node = node.Parent;
        }
        path.Reverse();
        return path;
    }

    private List<(int X, int Y)> GetNeighbors((int X, int Y) position)
    {
        int x = position.X;
        int y = position.Y;

        List<(int X, int Y)> neighbors = new List<(int X, int Y)>
        {
            (x + 1, y),
            (x - 1, y),
            (x, y + 1),
            (x, y - 1),
            (x + 1, y + 1),
            (x - 1, y - 1),
            (x + 1, y - 1),
            (x - 1, y + 1)
        };

        return neighbors;
    }

    public void PrintMap()
    {
        for (int y = 0; y < mapHeight; y++)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                Console.Write(map[x, y]);
            }
            Console.WriteLine();
        }
    }

    public static void Main(string[] args)
    {
        int mapWidth = 50;
        int mapHeight = 30;

        MapGenerator mapGenerator = new MapGenerator(mapWidth, mapHeight);
        mapGenerator.GenerateMap();
        mapGenerator.PrintMap();
    }
}

class Node
{
    public (int X, int Y) Position { get; }
    public Node Parent { get; set; }
    public double G { get; set; }
    public double H { get; set; }
    public double F => G + H;

    public Node((int X, int Y) position, Node parent, double g, double h)
    {
        Position = position;
        Parent = parent;
        G = g;
        H = h;
    }
}
