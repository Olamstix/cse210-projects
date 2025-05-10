using System;

class Program
{
    static void Main(string[] args)
    {
        bool playAgain = true;

        while (playAgain)
        {
            // Generate a random magic number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("Welcome to the 'Guess My Number' game!");

            // Loop until the user guesses correctly
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string input = Console.ReadLine();

                // Validate user input
                if (!int.TryParse(input, out guess) || guess < 1 || guess > 100)
                {
                    Console.WriteLine("Please enter a valid number between 1 and 100.");
                    continue;
                }

                guessCount++; // Increment guess counter

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it! It took you {guessCount} attempts.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();

            playAgain = (response == "yes");
        }

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}
