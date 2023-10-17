namespace LabirintGame
{
    public class Menu
    {
        public Menu() { }

        public void MenuStart()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey consoleKey = Console.ReadKey(true).Key;

                switch (consoleKey)
                {
                    case ConsoleKey.A:
                        break;
                }
            }
        }

    }
}
