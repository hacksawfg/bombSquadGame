using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleGameClasses
{

    public class Hangman
    {

        public int Instructions(string letters)
        {
            Console.WriteLine("BOMB SQUAD!");
            Console.WriteLine("Guess the password correctly to defuse the bomb, one letter at a time!\n");
            Console.Write("Select difficulty (a) easy - 10 guesses, (b) normal - 7 guesses, (c) hard - 5 guesses: ");
            char difficultySelection = Console.ReadKey().KeyChar;
            int allowedWrongGuesses;
            switch (difficultySelection)
            {
                case 'a':
                    allowedWrongGuesses = 10;
                    break;
                case 'b':
                    allowedWrongGuesses = 7;
                    break;
                case 'c':
                    allowedWrongGuesses = 5;
                    break;
                default:
                    Console.WriteLine("Invalid key selection, game will start at normal difficulty.");
                    allowedWrongGuesses = 7;
                    break;
            }
            Console.Clear();
            Console.WriteLine($"\nBe careful, {allowedWrongGuesses} wrong guesses and you explode!\n");
            Console.WriteLine($"Remaining Letters: {letters}");
            return allowedWrongGuesses;
        }

        public string GetWord(string wordlistLocation)
        {
            // import the wordlist and split by carriage return
            string wordList = System.IO.File.ReadAllText(wordlistLocation);
            string[] wordArray = wordList.Split('\n');

            // obtain number for random number generator
            int lineCount = wordArray.Count();

            // generate the number and pick the word from the array
            Random rnd = new Random();
            int pickedIndex = rnd.Next(0, lineCount);
            string pickedWord = wordArray[pickedIndex];
            // Console.WriteLine("working");
            return pickedWord;
        }


        public string DisplayLetters(char guess, char[] letterList)
        {
            // Run through the word to return visual indicator of length
            for (int i = 0; i < letterList.Length; i++)
            {
                if (letterList[i] == guess)
                {
                    letterList[i] = '-';
                }

            }
            string remainingLetters = new string(letterList);
            return remainingLetters;  // sends the array back with updated information

        }

        public void HangmanGame(int allowedWrongGuesses, int pickedWordLength, char[] guessingArray, char[] pickedArray, char[] letterList)
        {
            while (allowedWrongGuesses > 0 && Enumerable.SequenceEqual(guessingArray, pickedArray) == false)
            {
                
                // Build the bomb
                string fuse = new string('-', allowedWrongGuesses);
                Console.WriteLine("  __");
                Console.WriteLine(" /  \\");
                Console.WriteLine("|    |" + fuse + "X");
                Console.WriteLine(" \\__/\n");

                // Get the guesses
                Console.Write(guessingArray);
                Console.Write('\n');
                Console.Write("Enter your guess: ");
                char guess = Console.ReadKey().KeyChar;
                Console.Clear();
                Console.WriteLine('\n');

                // Show the remaining letters
                Console.WriteLine($"Remaining Letters:\n{DisplayLetters(guess, letterList)}\n");


                // Check to see if the word is contained in the picked word array
                bool correctGuess = Array.Exists(pickedArray, element => element == guess);

                if (correctGuess)
                {
                    Console.WriteLine($"You have survived another round. Only {allowedWrongGuesses} wrong guesses left.");
                    for (int i = 0; i < pickedWordLength; i++)
                    {
                        if (guess == pickedArray[i])
                        {
                            guessingArray[i] = guess;
                        }
                    }
                
                    // set the game winning condition
                    if (Enumerable.SequenceEqual(guessingArray, pickedArray))
                    {
                        Console.WriteLine("You have defused the bomb! You didn't die!");
                    }
                }
                else
                {
                    allowedWrongGuesses--;
                    if (allowedWrongGuesses == 0)
                    {
                        string correctWord = new string(pickedArray);
                        Console.WriteLine("#####    ####    ####   #     #");
                        Console.WriteLine("#    #  #    #  #    #  ##   ##");
                        Console.WriteLine("#    #  #    #  #    #  # # # #");
                        Console.WriteLine("#####   #    #  #    #  # # # #");
                        Console.WriteLine("#    #  #    #  #    #  #  #  #");
                        Console.WriteLine("#    #  #    #  #    #  #  #  #");
                        Console.WriteLine("#####    ####    ####   #     #\n");
                        Console.WriteLine($"YOU BLEW UP!!! The word was {correctWord}");
                    }
                    else
                    {
                        Console.WriteLine($"Careful, only {allowedWrongGuesses} incorrect guesses left!");
                    }

                }

            }
        }
    }
}