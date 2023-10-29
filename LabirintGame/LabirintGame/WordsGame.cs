namespace LabirintGame
{
    public class WordsGame
    {
        private string startPassword;
        private int maxAttempts; // Maksymalna liczba prób równa liczbie kluczy
        private int attempts = 5;
        private bool isWin = false;

        public WordsGame(int maxAttempts, string startPassword)
        {
            this.maxAttempts = maxAttempts;
            this.startPassword = startPassword;
        }

        public void setAttempts(int x)
        {
            attempts = attempts + x;
        }

        public bool IsWin(bool isWin)
        {
            return isWin;
        }

        public void Game()
        {
            char[] passwordToGuess = startPassword.ToCharArray();
            List<char> keys = new List<char>(passwordToGuess); // Inicjalizacja kluczy

            // Przetasuj litery w kluczach, aby były losowo rozmieszczone
            Random random = new Random();
            int n = keys.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                char temp = keys[k];
                keys[k] = keys[n];
                keys[n] = temp;
            }
            Console.WriteLine("Twoje zadanie to odgadnięcie hasła za pomocą dostępnych liter.");
            Console.WriteLine($"Masz {maxAttempts} prób, aby odgadnąć hasło.");

            while (0 < attempts)
            {
                Console.WriteLine("\nDostępne litery: " + string.Join(" ", keys));
                Console.Write("Hasło: ");
                foreach (char letter in passwordToGuess)
                {
                    if (keys.Contains(letter))
                    {
                        Console.Write(letter);
                    }
                    else
                    {
                        Console.Write("_");
                    }
                }

                Console.WriteLine("\nPodaj literę lub całe hasło: ");
                string guess = Console.ReadLine().ToUpper();

                if (guess == startPassword.ToUpper())
                {
                    isWin = true;
                    break;
                }
                else if (guess.Length == 1 && keys.Contains(guess[0]))
                {
                    keys.Remove(guess[0]);
                    Console.WriteLine("Poprawna litera!");
                }
                else
                {
                    Console.WriteLine("Błędna litera lub hasło.");
                }

            }
        }
    }
}
