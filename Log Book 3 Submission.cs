using System;

namespace log_book_3_c
{
    internal class Program
    {
        static int GenerateRandomNumber() // Creating a method to create a randomly generated number.
        {
            Random random = new Random();
            return random.Next(1, 11);
        }

        static void Space() // more efficent way of spacing.
        {
            Console.WriteLine();
        }

        static void Introduction() // creating a method for the introduction.
        {
            Console.WriteLine("Welcome to my game called, 'NumberGuess'.");
            Console.WriteLine("You have 3 lives to guess the correct number.");
            Console.WriteLine("the correct number is between 1 - 10.");
            Console.WriteLine("If you do not correctly guess the number, you lose a life.");
            Console.WriteLine("When you run out of lives, the game ends and you lose.");
            Console.WriteLine("But if you guess the correct number you win.");
            Space();
        }

        static void Attempts()
        {
            int maxAttempts = 3;
            int randomlyGeneratedNumber = GenerateRandomNumber(); // generates the random number and assigns value to 'randomlyGeneratedNumber'.

            for (int attempts = 0; attempts < maxAttempts; attempts++)
            {
                Console.WriteLine($"This is Attempt {attempts + 1}/{maxAttempts} "); // "This is Attempt 1/3, This is Attempt 2/3".
                int userGuess = GetValidUserGuess();

                if (userGuess == randomlyGeneratedNumber)
                {
                    Console.WriteLine("Congratulations! You have correctly guessed the number");
                    return; // exits the code early.
                }
                else
                {
                    Console.WriteLine("You have guessed incorrectly, resulting in a loss of a life.");
                    Space();
                }
            }

            Console.WriteLine("Sorry, but you have run out of lives, the correct number was " + randomlyGeneratedNumber + ", better luck next time :)"); // After loop ends, displays game over message. 

        }

        static int GetValidUserGuess() // creating method to make sure user guess is valid.
        {
            int userGuess;
            while (!int.TryParse(Console.ReadLine(), out userGuess) || userGuess < 1 || userGuess > 10) // not an integer, less than 1, more than 10.
            {
                Console.WriteLine("Invalid input. Enter your guess below (between 1 and 10): ");
            }

            return userGuess;
        }

        static bool PlayAgain() // creating a play again method.
        {
            Console.WriteLine("Would you like to play again? (yes/no)");
            string response = Console.ReadLine().ToLower();

            while (response != "yes" && response != "no")
            {
                Console.WriteLine("Error. Please enter 'yes' or 'no'.");
                response = Console.ReadLine().ToLower();
            }

            return response == "yes";
        }

        static void Main(string[] args)
        {
            do
            {
                Introduction();
                Attempts();
            } while (PlayAgain()); // executes the following methods if play again value is true.

        }


    }
}
