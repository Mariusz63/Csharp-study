using static System.Console;

namespace LabirintGame
{
    public class Player
    {
        //Player stats
        private static double playerX = 1.5;
        private static double playerY = 1.5;
        private static double playerA = 0;

        private WordsGame game;


        public double getPlayerX() { return playerX; }
        public double getPlayerY() { return playerY; }
        public double getPlayerA() { return playerA; }


        public int isWinWordsGame()
        {
            return game.IsWin();
        }

        public Player() { }
        public Player(double _playerX, double _playerY, double _playerA, WordsGame game)
        {
            playerA = _playerA;
            playerX = _playerX;
            playerY = _playerY;
            this.game = game;
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
                            if (Map.map[testY * Map.mapWidth + testX]+1 <= '?')
                            {
                                // Start another game
                                StartAnotherGame();
                            }
                            break;
                        }
                    case ConsoleKey.R:
                        {
                            game.Game();
                            break;
                        }
                }
            }
        }


        // Start another game
        private void StartAnotherGame()
        {

            Random rand = new Random();
            bool answer = true;
            if (answer == SelectGame.Switch(rand.Next(0, 3)))
            {
                game.addLetter(1);
            }
            else
            {
                game.reduceAttempts();
            }
        }

    }
}
