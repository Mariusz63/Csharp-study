using MazeGenerator;
using static System.Console;

namespace LabirintGame
{
    public class GameMenu
    {
        // Initialize MazeGenerator and other variables
        private static readonly Maze MazeGenerator = new Maze();

        // Constants for screen dimensions and game settings
        private const int ScreenWidth = 120;
        private const int ScreenHeight = 60;

        public int getScreenWidth() { return ScreenWidth; }
        public int getScreenHeight() { return ScreenHeight; }


        private const double Depth = 16;
        private const double Fov = Math.PI / 3.5;
        private static bool isGameRunning = false; // Track the game state
        //public static void setIsGameRunning(bool  _isGameRunning) { isGameRunning = _isGameRunning; }

        public GameMenu() { }

        // Start the main menu and the game loop
        public void Start(Player player)
        {
            RunMainMenu(player);
        }

        // Handle game exit
        public static void ExitGame()
        {
            WriteLine("Are you sure you want to leave the game? ");
            WriteLine("\nPress eny key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        // Display information about the game
        private void DisplayAboutInfo(Player player)
        {
            Clear();
            WriteLine("Welcome to the Game!");
            WriteLine("Press any key to return to the menu");
            ReadKey(true);
            RunMainMenu(player);
        }

        // Main menu and its options
        private void RunMainMenu(Player player)
        {
            string prompt = @"  
    ██╗      █████╗ ██████╗ ██╗██████╗ ██╗███╗   ██╗████████╗     ██████╗  █████╗ ███╗   ███╗███████╗
    ██║     ██╔══██╗██╔══██╗██║██╔══██╗██║████╗  ██║╚══██╔══╝    ██╔════╝ ██╔══██╗████╗ ████║██╔════╝
    ██║     ███████║██████╔╝██║██████╔╝██║██╔██╗ ██║   ██║       ██║  ███╗███████║██╔████╔██║█████╗  
    ██║     ██╔══██║██╔══██╗██║██╔══██╗██║██║╚██╗██║   ██║       ██║   ██║██╔══██║██║╚██╔╝██║██╔══╝  
    ███████╗██║  ██║██████╔╝██║██║  ██║██║██║ ╚████║   ██║       ╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗
    ╚══════╝╚═╝  ╚═╝╚═════╝ ╚═╝╚═╝  ╚═╝╚═╝╚═╝  ╚═══╝   ╚═╝        ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝
                                                                                                  
            (Use the arrow keys to cycle through options and press enter to select an option.)";
            string[] options = { "Play", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    StartGame(player);
                    break;
                case 1:
                    DisplayAboutInfo(player);
                    break;
                case 2:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }

        // Pause the game and display pause menu
        public static void PauseGame()
        {
            isGameRunning = true;

            // Clear the screen...
            // Display the RESUME screen...

            string resumePrompt = @"
 ____  _____    _    ____  _   _ __  __ _____ 
|  _ \| ____|  / \  / ___|| | | |  \/  | ____|
| |_) |  _|   / _ \ \___ \| | | | |\/| |  _|  
|  _ <| |___ / ___ \ ___) | |_| | |  | | |___ 
|_| \_\_____/_/   \_\____/ \___/|_|  |_|_____|
Game Paused. Select an option:";
            string[] resumeOptions = { "Resume", "Exit" };
            Menu resumeMenu = new Menu(resumePrompt, resumeOptions);
            int selectedIndex = resumeMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    // Continue the game...
                    break;
                case 1:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }
        // Game over menu
        public static void GameOver(Player player)
        {
            isGameRunning = false;

            string resumePrompt = @"
 ██████╗  █████╗ ███╗   ███╗███████╗     ██████╗ ██╗   ██╗███████╗██████╗ 
██╔════╝ ██╔══██╗████╗ ████║██╔════╝    ██╔═══██╗██║   ██║██╔════╝██╔══██╗
██║  ███╗███████║██╔████╔██║█████╗      ██║   ██║██║   ██║█████╗  ██████╔╝
██║   ██║██╔══██║██║╚██╔╝██║██╔══╝      ██║   ██║╚██╗ ██╔╝██╔══╝  ██╔══██╗
╚██████╔╝██║  ██║██║ ╚═╝ ██║███████╗    ╚██████╔╝ ╚████╔╝ ███████╗██║  ██║
 ╚═════╝ ╚═╝  ╚═╝╚═╝     ╚═╝╚══════╝     ╚═════╝   ╚═══╝  ╚══════╝╚═╝  ╚═╝

Game over. Select an option:";
            string[] resumeOptions = { "New game", "Exit" };
            Menu resumeMenu = new Menu(resumePrompt, resumeOptions);
            int selectedIndex = resumeMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    StartGame(player);
                    break;
                case 1:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }

        // Start the game
        public static void StartGame(Player player)
        {
            // Initialize the game map, screen, opponents, and game loop
            Map.InitMap(MazeGenerator);

            var screen = new char[ScreenWidth * ScreenHeight];

            DateTime dateTimeFrom = DateTime.Now;

            isGameRunning = true; // Start the game

            // Load a Answers to game
            PasswordLoader loader = new PasswordLoader("passwords.txt");
            List<string> passwords = loader.LoadPasswords();

            // Choosing one answer
            Answer answer = new Answer(passwords);
            string currentPassword = answer.CurrentPassword;

            while (isGameRunning)
            {
                // Game loop logic (movement, rendering, etc.) goes here...

                var dateTimeTo = DateTime.Now;
                double elapsedTime = (dateTimeTo - dateTimeFrom).TotalSeconds;
                dateTimeFrom = dateTimeTo;

                //Update player 
                player.CheckControls(elapsedTime);

                if (player.getPlayerHP() <= 0)
                {
                    GameMenu.GameOver(player);
                }

                // Raycasting and rendering the game world
                for (int x = 0; x < ScreenWidth; x++)
                {
                    double rayAngle = (player.getPlayerA() - Fov / 2) + x * Fov / ScreenWidth;

                    double rayX = Math.Cos(rayAngle);
                    double rayY = Math.Sin(rayAngle);

                    double distanceToWall = 0;
                    bool hitWall = false;
                    bool isBound = false;

                    while (!hitWall && distanceToWall < Depth)
                    {

                        distanceToWall += 0.1;

                        int testX = (int)(player.getPlayerX() + rayX * distanceToWall);
                        int testY = (int)(player.getPlayerY() + rayY * distanceToWall);

                        if (testX < 0 || testX >= Depth + player.getPlayerX() || testY < 0 || testY >= Depth + player.getPlayerY())
                        {
                            hitWall = true;
                            distanceToWall = Depth;
                        }
                        else
                        {
                            char testCell = Map.map[testY * Map.mapWidth + testX];

                            if (testCell == '#' || testCell == '?')
                            {
                                hitWall = true;

                                distanceToWall = distanceToWall * Math.Cos(rayAngle - player.getPlayerA());

                                var boundsVectorsList = new List<(double X, double Y)>();

                                for (int tx = 0; tx < 2; tx++)
                                {
                                    for (int ty = 0; ty < 2; ty++)
                                    {
                                        double vx = testX + tx - player.getPlayerX();
                                        double vy = testY + ty - player.getPlayerY();

                                        double vectorModule = Math.Sqrt(vx * vx + vy * vy);
                                        double cosAngle = (rayX * vx / vectorModule) + (rayY * vy / vectorModule);
                                        boundsVectorsList.Add((vectorModule, cosAngle));
                                    }
                                }

                                boundsVectorsList = boundsVectorsList.OrderBy(v => v.X).ToList();

                                double boundAngle = 0.03 / distanceToWall;

                                if (Math.Acos(boundsVectorsList[0].Y) < boundAngle ||
                                    Math.Acos(boundsVectorsList[1].Y) < boundAngle)
                                    isBound = true;
                            }
                        }
                    }

                    int ceiling = (int)(ScreenHeight / 2.0 - ScreenHeight * Fov / distanceToWall);
                    int floor = ScreenHeight - ceiling;

                    ceiling += ScreenHeight - ScreenHeight;

                    char wallShade;

                    if (isBound)
                        wallShade = '|';
                    else if (distanceToWall <= Depth / 4.0)
                        wallShade = '\u2588';
                    else if (distanceToWall < Depth / 3.0)
                        wallShade = '\u2593';
                    else if (distanceToWall < Depth / 2.0)
                        wallShade = '\u2592';
                    else if (distanceToWall < Depth)
                        wallShade = '\u2591';
                    else
                        wallShade = ' ';

                    for (int y = 0; y < ScreenHeight; y++)
                    {
                        if (y < ceiling)
                            screen[y * ScreenWidth + x] = ' ';
                        else if (y > ceiling && y <= floor)
                            screen[y * ScreenWidth + x] = wallShade;
                        else
                        {
                            char floorShade;
                            double b = 1.0 - (y - ScreenHeight / 2.0) / (ScreenHeight / 2.0);

                            if (b < 0.25)
                                floorShade = '#';
                            else if (b < 0.5)
                                floorShade = 'x';
                            else if (b < 0.75)
                                floorShade = '-';
                            else if (b < 0.9)
                                floorShade = '.';
                            else
                                floorShade = ' ';

                            screen[y * ScreenWidth + x] = floorShade;
                        }
                    }
                }

                // Stats display
                char[] stats = $"X: {Math.Round(player.getPlayerX(), 2)}; Y: {Math.Round(player.getPlayerY(), 2)}; A: {Math.Round(player.getPlayerA() % 6, 2)}; FPS: {(int)(1 / elapsedTime)}".ToCharArray();
                stats.CopyTo(screen, 0);

                // Map display
                Map.GetMap(screen, ScreenWidth);// map in corner
                // Player position display
                screen[(int)(player.getPlayerY() + 1) * ScreenWidth + (int)player.getPlayerX()] = 'P';

                // Update the screen
                Console.SetCursorPosition(0, 0);
                Console.Write(screen, 0, ScreenWidth * ScreenHeight);
            }
        }
    }
}

/*  
 * stworzyc samouczek
 * dodac ekwipunek literek
 * ma sie 3 proby odgadniecia hasla
 * stworzyc 3 mini gry
 * po wygraniu mini gierki gracz otrzymuje lososa literke
 */