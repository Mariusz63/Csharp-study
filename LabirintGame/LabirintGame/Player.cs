using static System.Console;
namespace LabirintGame
{
    public class Player
    {
        //Player stats
        private static double playerX = 1.5;
        private static double playerY = 1.5;
        private static double playerA = 0;
        private double HP = 100;
        private static int keys = 0;

        public double getPlayerX() { return playerX; }
        public double getPlayerY() { return playerY; }
        public double getPlayerA() { return playerA; }
        public double getPlayerHP() { return HP; }

        public void setPlayerHP(double hp) { HP = hp; }
        public void setKeys(int _keys) { keys = _keys; }
        public int getKeys() { return keys; }


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

                            if (Map.map[(int)playerY * Map.mapWidth + (int)playerX] == ('#') || Map.map[(int)playerY * Map.mapWidth + (int)playerX] == '?')
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

                            if (Map.map[(int)playerY * Map.mapWidth + (int)playerX] == '#' || Map.map[(int)playerY * Map.mapWidth + (int)playerX] == '?')
                            {
                                playerX += Math.Cos(playerA) * 60 * elapsedTime;
                                playerY += Math.Sin(playerA) * 60 * elapsedTime;
                            }

                            break;
                        }
                    case ConsoleKey.Spacebar:
                        {

                            //  logic
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            GameMenu.PauseGame();
                            break;
                        }
                    case ConsoleKey.E:
                        {
                            // Check if the player is near a wall with '?'
                            int testX = (int)playerX;
                            int testY = (int)playerY;
                            if (Map.map[testY * Map.mapWidth + testX] == '?')
                            {
                                // Start another game
                                StartAnotherGame();
                            }
                            break;
                        }
                }
            }
        }

        // Check if the player is near the '?'
        private bool IsPlayerNearSign(int testX, int testY, double playerX, double playerY)
        {
            int signDetectionRadius = 2; // Adjust this radius as needed
            return Math.Abs(playerX - testX) <= signDetectionRadius && Math.Abs(playerY - testY) <= signDetectionRadius;
        }

        // Start another game
        private void StartAnotherGame()
        {
            // You can create a new instance of the game or implement a different gameplay here.
            // For example, you can create a new maze or any other game scenario.
        }

    }
}
