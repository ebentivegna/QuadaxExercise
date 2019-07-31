using System;
using System.Collections.Generic;

namespace QuadaxExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Welcome to Mastermind! ***");
            Random random = new Random();
            List<string> answer = new List<string>();

            // Generate the answer
            for (int i = 0; i < 4; i++)
            {
                string nextDigit = random.Next(0, 6).ToString();
                answer.Add(nextDigit);
            }

            // Loop ten times for ten guesses
            for (int i = 0; i < 10; i++) 
            {
                int plusSigns = 0;
                int minusSigns = 0;
                bool validGuess = false;
                string guess = "";
                List<string> checkDifferentDigits = new List<string>(answer);

                // Keep asking for input if they enter something not of length 4 (doesn't catch
                // non-numeric values).
                while (!validGuess)
                {
                    Console.WriteLine("Please enter a valid guess of four digits");
                    guess = Console.ReadLine();
                    if (guess.Length == 4)
                    {
                        validGuess = true;
                    }

                }
                List<string> guessedDigits = new List<string>();

                // Find all correct digits first
                for (int j = 0; j < 4; j++)
                {
                    if (answer[j] == guess[j].ToString())
                    {
                        plusSigns++;
                        // Remove this digit so we don't check it later when searching for
                        // right digit wrong position
                        checkDifferentDigits.Remove(answer[j]);
                    }
                    else
                    {
                        // Save this digit for later so we can check if its just in the wrong position
                        guessedDigits.Add(guess[j].ToString());
                    }

                }
                if (plusSigns == 4)
                {
                    Console.WriteLine("Congratulations! You win!");
                    break;
                }
                else
                {
                    Console.WriteLine("Oops, so close!");

                    // Compare guessed digits to digits not exactly matched to see if there is overlap
                    foreach (string digit in checkDifferentDigits)
                    {
                        if (guessedDigits.Contains(digit))
                        {
                            minusSigns++;
                            guessedDigits.Remove(digit); // Remove it so we don't check it again
                        }
                    }

                    Console.Write("Correct digits:");
                    for (int k = 0; k < plusSigns; k++)
                    {
                        Console.Write("+");
                    }

                    Console.WriteLine();
                    Console.Write("Correct numbers but incorrect position:");

                    for (int k = 0; k < minusSigns; k++)
                    {
                        Console.Write("-");
                    }

                    Console.WriteLine();

                    if (i == 9)
                    {
                        Console.WriteLine("Uh oh, you didn't guess the number. Please play again!");
                        Console.ReadKey();
                    }
                }
            }


        }
    }
}
