using System;
using static System.Console;
namespace GuessNumber
{
    public class GuessNum
    {
        public bool Main()
        {
                Clear();
                Random random = new Random();
                int targetNumber = random.Next(1, 101);
                int attempts = 0;
                int maxAttempts = 6;

                WriteLine("Welcome to the 1 to 100 number guessing game!");
                WriteLine($"You only have {maxAttempts} tries to guess the number.");

                while (attempts < maxAttempts)
                {
                    Write("Give me a number: ");
                    if (int.TryParse(ReadLine(), out int guess))
                    {
                        attempts++;

                        if (guess < targetNumber)
                        {
                            WriteLine("The number drawn is larger.");
                        }
                        else if (guess > targetNumber)
                        {
                            WriteLine("The number drawn is smaller.");
                        }
                        else if(guess == targetNumber)
                        {
                            WriteLine($"Way to go! The number drawn is {targetNumber}. You guessed it in {attempts} attempts.");
                            WriteLine("Congratulations!");
                            return true;
                        }
                    }
                    else
                    {
                        WriteLine("This is not a valid number. Try again.");
                    }


                }

                WriteLine("Unfortunately, you've run out of tries. The number drawn is " + targetNumber);
                WriteLine("You lost!");
                return false;
        }
    }
}
