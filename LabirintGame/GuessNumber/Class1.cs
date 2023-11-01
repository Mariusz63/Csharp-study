using System;

namespace GuessNumber
{
    public class GuessNum
    {
        public bool Main()
        {
            Random random = new Random();
            int targetNumber = random.Next(1, 101);
            int attempts = 0;
            int maxAttempts = 3;

            Console.WriteLine("Witaj w grze zgadywania liczby od 1 do 100!");
            Console.WriteLine($"Masz tylko {maxAttempts} próby, aby odgadnąć liczbę.");

            while (attempts < maxAttempts)
            {
                Console.Write("Podaj liczbę: ");
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    attempts++;

                    if (guess < targetNumber)
                    {
                        Console.WriteLine("Wylosowana liczba jest większa.");
                    }
                    else if (guess > targetNumber)
                    {
                        Console.WriteLine("Wylosowana liczba jest mniejsza.");
                    }
                    else
                    {
                        Console.WriteLine($"Brawo! Wylosowana liczba to {targetNumber}. Zgadłeś ją w {attempts} próbach.");
                        Console.WriteLine("Gratulacje!");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("To nie jest prawidłowa liczba. Spróbuj ponownie.");
                }
            }

            Console.WriteLine("Niestety, skończyły Ci się próby. Wylosowana liczba to " + targetNumber);
            Console.WriteLine("Przegrałeś!");
            return false;
        }
    }
}
