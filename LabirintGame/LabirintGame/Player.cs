using static System.Console;
namespace LabirintGame
{
    public class Player
    {
        private static double playerX = 1.5;
        private static double playerY = 1.5;
        private static double playerA = 0;

        public double getPlayerX() { return playerX; }
        public double getPlayerY() { return playerY; }
        public double getPlayerA() { return playerA; }

        public Player() { }
        public Player(double _playerX, double _playerY, double _playerA)
        {
            playerA = _playerA;
            playerX = _playerX;
            playerY = _playerY;
        }

        public void CheckControls(double elapsedTime)
        {
            if (KeyAvailable)
            {
                ConsoleKey consoleKey = ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.A:
                        playerA -= elapsedTime * 20;
                        break;
                    case ConsoleKey.D:
                        playerA += elapsedTime * 20;
                        break;
                    case ConsoleKey.W:
                        {
                            playerX += Math.Cos(playerA) * 60 * elapsedTime;
                            playerY += Math.Sin(playerA) * 60 * elapsedTime;

                            if (Map.map[(int)playerY * Map.mapWidth + (int)playerX] == '#')
                            {
                                playerX -= Math.Cos(playerA) * 60 * elapsedTime;
                                playerY -= Math.Sin(playerA) * 60 * elapsedTime;
                            }

                            break;
                        }

                    case ConsoleKey.S:
                        {
                            playerX -= Math.Cos(playerA) * 60 * elapsedTime;
                            playerY -= Math.Sin(playerA) * 60 * elapsedTime;

                            if (Map.map[(int)playerY * Map.mapWidth + (int)playerX] == '#')
                            {
                                playerX += Math.Cos(playerA) * 60 * elapsedTime;
                                playerY += Math.Sin(playerA) * 60 * elapsedTime;
                            }

                            break;
                        }

                    case ConsoleKey.Escape:
                        {
                            GameMenu.PauseGame();
                            break;
                        }
                }
            }
        }
    }
}
