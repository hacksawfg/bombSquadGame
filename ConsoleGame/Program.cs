using System;
using System.Linq;
using ConsoleGameClasses;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            string letters = "abcdefghijklmnopqrstuvwxyz";
            int allowedWrongGuesses = 7;
            string wordListLocation = "ADDLOCATION\\assets\\words.txt";

            Console.Clear();
            Hangman game = new Hangman();
            char playAgain = 'y';
            bool playGame = true;

            while (playGame)

            {
                game.Instructions(allowedWrongGuesses, letters);

                string pickedWord = game.GetWord(wordListLocation);

                char[] pickedArray = pickedWord.ToCharArray();
                int pickedWordLength = pickedWord.Length;

                char[] guessingArray = new char[pickedWordLength];

                for (int i = 0; i < pickedWordLength; i++)
                {
                    guessingArray[i] = '-';
                }
                char[] letterList = letters.ToCharArray();

                game.HangmanGame(allowedWrongGuesses, pickedWordLength, guessingArray, pickedArray, letterList);

                Console.WriteLine("Would you like to play again?  Press \"y\" to continue, any other key to exit.");
                playAgain = Console.ReadKey().KeyChar;
                if (playAgain == 'y')
                {
                    Console.Clear();
                    playGame = true;
                }
                else 
                {
                    playGame = false;
                }
               
            }
        }
    }
}
// ✓✓✓ Need to: Instructions
// ✓✓✓ Need to: Create a random number generator to pick the word 
// ✓✓✓ Need to: Display underlines corresponding to character count, after word is picked
// Need to: Make sure guesses are converted to lower case
// ✓✓✓ Need to: Display the letter that is picked in the underlines
// ✓✓✓ Need to: Develop logic to see if letter is in the word
// ✓✓✓ Need to: Let player know how many guesses are left 
//                                                              (Optional): Put a graphic of hangman's body
// ✓✓✓ Need to: Develop logic to see if game is won or lost (if guesses = 0, if word is solved)
// ✓✓✓ Need to: Display messages to player based on winning or losing
// Need to: (Optional) Have a list of available letters left to pick (Have an error message if already guessed?)
// Need to: (Optional) Give player an option to restart with a new word/ "Play again"

/*

Written by:

Findley Griffiths
Elijah Beach
Alan Murugan

*/