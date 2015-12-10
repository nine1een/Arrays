using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace Lab10
{
    class GuessAWord
    {
        static void Main(string[] args)
        {
            int foundLetters = 0;
            bool solved = false, found = false;
            char entry;

            //create array
            string[] word = { "apple", "grape", "banana", "berry", "tomato", "cranberry", "orange", "blueberry" };

            //random
            Random random = new Random();
            int x = random.Next(0, 8);

            //create word array and hidden array
            char[] randomWord = word[x].ToCharArray();
            char[] hidden = word[x].ToCharArray();

            //turn hidden into asterisks
            for (int d = 0; d < hidden.Length; ++d)
                hidden[d] = '*';

            WriteLine("Guess-A-Word");
            WriteLine("-----------------\n");
            WriteLine(hidden);

            while (solved == false)
            {
                Write("Guess a letter: ");
                char.TryParse(ReadLine(), out entry);

                //test each letter
                for (int l = 0; l < hidden.Length; ++l)
                {
                    //if letter in word is the same as entry and has not already been found
                    if (entry == randomWord[l] && hidden[l] != entry)
                    {
                        hidden[l] = entry;
                        found = true;
                        ++foundLetters;
                    }
                }

                if (found == false)
                    WriteLine(" :the letter {0} is not in the word.\n", entry);
                else
                {
                    WriteLine(" :the letter {0} is in the word.\n", entry);
                    found = false;
                }

                WriteLine(hidden);

                if (foundLetters == randomWord.Length)
                    solved = true;
            }

            WriteLine("You solved the word!\n");
        }
    }
}
