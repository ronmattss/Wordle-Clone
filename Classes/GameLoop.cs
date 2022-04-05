// this is the main game loop
// where it will first accept a string of word
// then waits for a string of letters
using System;
using System.Collections.Generic;

namespace WordleClone
{
    public class GameLoop
    {
        Word correctWord;
        Rules rules = new Rules()
        {
            attempts = 6
        };

        public GameLoop(string wordString)
        {
            correctWord = new Word(wordString); // dependency
        }

        public void Start()
        {
            Console.WriteLine("Welcome to Wordle Clone where you guess song titles!");
            Console.WriteLine("Guess the title of the song and you win!");
            System.Console.WriteLine("Rules:");
            System.Console.WriteLine("You have 6 attempts to guess the title of the song");
            System.Console.WriteLine("/ means that the letter is in the word and it is in correct position");
            System.Console.WriteLine("- means that the letter is in the word but it is in the wrong position");
            System.Console.WriteLine("_ means that the letter is not in the word");

            System.Console.WriteLine(correctWord.GetWordString());

        }


        public void Play()
        {
            var flag = true;
            var attempts = rules.attempts;
            System.Console.WriteLine("Begin guessing!");

            while (attempts > 0 || !flag)
            {
                var guess = ReadInput();
                flag = IsCorrect(guess);
                System.Console.WriteLine(flag);
                guess = WordCorrectness(guess);
                System.Console.WriteLine(guess);

                attempts = (flag != true) ? attempts-1 : 0;


            }


            if (flag)
            {
                System.Console.WriteLine("You win!");
            }
            else
            {
                System.Console.WriteLine("You lose!");
            }
            System.Console.WriteLine("Word is: " + correctWord.GetWordString());



        }

        bool IsCorrect(string guess)
        {
            return correctWord.GetWordString() == guess;
        }

        public string ReadInput()
        {
            var length = correctWord.WordLength;
            var inputArray = new List<String>(length);
            while (length > 0)
            {
                var key = Console.ReadKey().KeyChar.ToString();

                inputArray.Add(key);

                length--;
            }
            System.Console.WriteLine("??0" + BuildWord(inputArray));
            // convert inputArray to string


            return BuildWord(inputArray);
        }

        String BuildWord(List<String> inputArray)
        {
            String word = "";
            foreach (var letter in inputArray)
            {
                word += letter;
            }
            return word;
        }

        // instead of returning the String, return a string which shows how close the guess is to the word


        String WordCorrectness(String guess)
        {
            Console.WriteLine(correctWord.GetWordString());
            List<String> guessedWord = new List<String>();
            String result = correctWord.GetWordString();


            foreach (var letter in correctWord.GetWordString())
            {
                guessedWord.Add("*");
            }


            Console.WriteLine(">>>>>" + correctWord.GetWordString());

            for (int i = 0; i < guess.Length; i++)
            {
                for (int j = 0; j < correctWord.GetWordString().Length; j++)
                {
                    Console.WriteLine(guess[i] + " == " + correctWord.GetWordString()[j]);
                    if (guess[j] == correctWord.GetWordString()[j])
                    {
                        guessedWord[j] = "/";

                    }
                    else
                    {
                        if (guessedWord[i] == "/" || guessedWord[i] == "-")
                        {
                            continue;
                        }

                        if (guess[i] == correctWord.GetWordString()[j])
                        {
                            guessedWord[i] = "-";
                        }
                        else
                        {
                            guessedWord[i] = "*";
                        }
                    }
                }


            }

            return BuildWord(guessedWord);
        }



    }
}