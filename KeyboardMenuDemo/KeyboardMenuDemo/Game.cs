using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace KeyboardMenuDemo
{
    internal class Game
    {
        public void Start()
        {
            Title = "Paint Drying - The Game! ";
            RunMainMenu();   
        }

        private void RunMainMenu()
        {
            string prompt = @"  Welcome to the Paint Drying Simulator. Waht would you like to do? 
            (Use the arrow keys to cycle through options and press enter to select an option.)";
            string[] options = { "Play","About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch(selectedIndex)
            {
                case 0:
                    RunFirstChoice();
                    break;
                case 1:
                    DisplayAboutInfo();
                    break;
                case 2:
                    ExitGame();
                    break;
                default:
                    break;
            }
        }

        private void ExitGame()
        {
            WriteLine("\nPress eny key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }

        private void DisplayAboutInfo()
        {
            Clear();
            WriteLine("Welcome to the Game!");
            WriteLine("Press any key to return to the menu");
            ReadKey(true);
            RunMainMenu();
        }

        private void RunFirstChoice()
        {
            string prompt = "What color paint what would you like to watch dry?";
            string[] options = { "Red", "Green", "Blue", "Yellow" };
            Menu colorMenu = new Menu(prompt, options);
            int selectedIndex = colorMenu.Run();

            BackgroundColor = ConsoleColor.White;

            switch (selectedIndex)
            {
                case 0:
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nHere is some riveting red paint drying for you...");
                    break;
                case 1:
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\nHere is some riveting green paint drying for you...");
                    break;
                case 2:
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("\nHere is some riveting blue paint drying for you...");
                    break;
                case 3:
                    ForegroundColor = ConsoleColor.Yellow;
                    WriteLine("\nHere is some riveting yellow paint drying for you...");
                    break;
                default:
                    break;
            }

            WriteLine("That's all for this game demo.");
            ExitGame();
        }
    }
}
