using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration
{
    public class ValidPlayerGuess
    {
        public string GetValidPlayerGuess()
        {
            string guess;
            do
            {
                Console.WriteLine("Enter your 4-digit guess: ");
                guess = Console.ReadLine();
                if (guess.Length != 4 || !int.TryParse(guess, out _))
                {
                    Console.WriteLine("Invalid input. Please enter exactly 4 digits.");
                }
            }
            while (guess.Length != 4 || !int.TryParse(guess, out _));

            return guess;
        }
    }
}
