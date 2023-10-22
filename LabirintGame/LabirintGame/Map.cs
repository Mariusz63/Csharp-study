using MazeGenerator;
using System.Text;

namespace LabirintGame
{
    public class Map
    {
        public const int MazeHeight = 8;
        public const int MazeWidth = 8;

        public const char MapWall = '#';
        public const char MapEmpty = '.';
        public const char BlockChar = '?';

        public static string map = "";
        public static int mapHeight = MazeHeight * 3 + 1;
        public static int mapWidth = MazeWidth * 3 + 1;


        public static void InitMap(Maze maze)
        {
            StringBuilder MapBuilder = new StringBuilder();

            char[,] map = maze.GenerateCharMap(MazeWidth, MazeHeight, MapWall, MapEmpty, BlockChar);

            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    MapBuilder.Append(map[x, y]);
                }
            }

            Map.map = MapBuilder.ToString();
        }

        public static char[] GetMap(char[] screen, int ScreenWidth)
        {
            //Map
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    screen[(y + 1) * ScreenWidth + x] = map[y * mapWidth + x];
                }
            }
            return screen;
        }

    }
}
