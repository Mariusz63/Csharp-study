using static System.Console;
namespace LabirintGame
{
    public class WordsGame : GameMenu
    {
        private string startPassword;
        private int attempts;
        private int isWin = 1;
        // 0 = lose
        // 1 = in game
        // 2 = win

        private int countLetters = 0;

        public WordsGame(int maxAttempts, string startPassword)
        {
            this.attempts = maxAttempts;
            this.startPassword = startPassword;
        }

        public void setAttempts(int x)
        {
            attempts = attempts + x;
        }

        public int IsWin()
        {
            return isWin;
        }

        public string getStartPassword()
        {
            return startPassword;
        }


        public void Game()
        {

            List<char> availableLetters = startPassword.Take(countLetters).ToList();
            // Przetasuj litery w kluczach, aby były losowo rozmieszczone
            Random random = new Random();
            int n = countLetters;
            while (n > 0)
            {
                n--;
                int k = random.Next(n + 1);
                char temp = availableLetters[k];
                availableLetters[k] = availableLetters[n];
                availableLetters[n] = temp;
            }


            while (attempts > 0)
            {
                Clear();
                WriteLine("Your task is to guess the password using the available letters.");
                WriteLine($"You have {attempts} attempts to guess the password.");
                WriteLine("Press ESC and ENTER to exit the game");


                WriteLine("\nAvailable letters: " + string.Join(" ", availableLetters));

                WriteLine("Enter the entire password: ");
                string guess = ReadLine().ToUpper();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                if (guess == startPassword.ToUpper())
                {
                    isWin = 2;
                    break;
                }
                else if (guess.Length == 1 && availableLetters.Contains(guess[0]))
                {
                    availableLetters.Remove(guess[0]);
                    WriteLine("Correct letter!");
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    WriteLine("Press ENTER");
                    return;
                }
                else
                {
                    WriteLine("Incorrect letter or password.");
                    reduceAttempts();
                }
                           
                if (attempts <= 0)
                { isWin = 0; }

            }

        }

        public void addLetter()
        {
            ++countLetters;
        }

        public void reduceAttempts()
        {
            attempts--;
            if (attempts <= 0)
            { isWin = 0; }
        }
    }
}
