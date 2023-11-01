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
                WriteLine("Twoje zadanie to odgadnięcie hasła za pomocą dostępnych liter.");
                WriteLine($"Masz {attempts} prób, aby odgadnąć hasło.");
                WriteLine("Nacisnij przycisk ENTER aby wujsc z programu");


                WriteLine("\nDostępne litery: " + string.Join(" ", availableLetters));

                WriteLine("Podaj całe hasło: ");
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
                    WriteLine("Poprawna litera!");
                }
                else if (keyInfo.Key == ConsoleKey.Escape)
                {
                    WriteLine("Nacisnij ENTER");
                    return;
                }
                else
                {
                    WriteLine("Błędna litera lub hasło.");
                    reduceAttempts();
                }

                
               

                if (attempts <= 0)
                { isWin = 0; }

            }

        }

        public void addLetter()
        {
            countLetters++;
        }

        public void reduceAttempts()
        {
            attempts--;
            if (attempts <= 0)
            { isWin = 0; }
        }
    }
}
