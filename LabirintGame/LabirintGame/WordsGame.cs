using static System.ConsoleKey;
using static System.Console;
namespace LabirintGame
{
    public class WordsGame: GameMenu
    {
        private string startPassword;
        private int attempts;
        private int isWin = 1; 
        // 0 = lose
        // 1 = in game
        // 2 = win

        private int countLetters=0;

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
                
                char[] passwordToGuess = startPassword.ToCharArray();
                List<char> keys = new List<char>(passwordToGuess); // Inicjalizacja kluczy

                // Przetasuj litery w kluczach, aby były losowo rozmieszczone
                Random random = new Random();
                int n = countLetters;
                while (n > 0)
                {
                    n--;
                    int k = random.Next(n + 1);
                    char temp = keys[k];
                    keys[k] = keys[n];
                    keys[n] = temp;
                }
                

                while (attempts>0)
                {
                Clear();
                WriteLine("Twoje zadanie to odgadnięcie hasła za pomocą dostępnych liter.");
                WriteLine($"Masz {attempts} prób, aby odgadnąć hasło.");

                WriteLine("\nDostępne litery: " + string.Join(" ", keys));
                    WriteLine("\nPodaj całe hasło: ");
                    string guess = ReadLine().ToUpper();

                    if (guess == startPassword.ToUpper())
                    {
                        isWin = 2;
                        break;
                    }
                    else if (guess.Length == 1 && keys.Contains(guess[0]))
                    {
                        keys.Remove(guess[0]);
                        WriteLine("Poprawna litera!");
                    }
                    else
                    {
                        WriteLine("Błędna litera lub hasło.");
                        reduceAttempts();
                    }

                    if (KeyAvailable) // Check if a key is available to be read
                    {
                        ConsoleKeyInfo keyInfo = ReadKey(true);
                        if (keyInfo.Key == ConsoleKey.Escape)
                        {
                            // Handle the ESCAPE key to exit the mini-game and return to the main game
                            break;
                        }
                    }

                }
           
        }

        public void addLetter()
        {
            countLetters++;
        }

        public void reduceAttempts()
        {
            attempts--;
            if (attempts < 0) 
                { isWin = 0; }
        }
    }
}
