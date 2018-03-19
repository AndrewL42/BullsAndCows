using System;
using System.Collections.Generic;
using System.Text;

namespace BullsAndCows
{
    class WordCheck
    {
        public static Enum checkDifficultyAndGetWords(string userWord)
        {
            String word = userWord;
            Random RNG = new Random();

            if (word.Equals(Difficulties.Easy.ToString().ToLower()))
            {
                Console.WriteLine(Difficulties.Easy.ToString().ToLower());
                Array values = Enum.GetValues(typeof(EasyWords));
                EasyWords randomWord = (EasyWords)values.GetValue(RNG.Next(values.Length));
                Program.setNumOfTires(5);
                return randomWord;
            }
            else if (word.Equals(Difficulties.Normal.ToString().ToLower()))
            {
                Array values = Enum.GetValues(typeof(NormalWords));
                NormalWords randomWord = (NormalWords)values.GetValue(RNG.Next(values.Length));
                Program.setNumOfTires(5);
                return randomWord;
            }
            else if (word.Equals(Difficulties.Hard.ToString().ToLower()))
            {
                Array values = Enum.GetValues(typeof(HardWords));
                HardWords randomWord = (HardWords)values.GetValue(RNG.Next(values.Length));
                Program.setNumOfTires(13);
                return randomWord;
            }
            else
            {
                return null;
            }
        }

        public static void checkGuess(string input)
        {
            Program.resetCowsAndBulls();
            for (int hiddenWordPos = 0; hiddenWordPos < Program.getHiddenWord().Length; hiddenWordPos++)
            {
                for (int userGuessPos = 0; userGuessPos < Program.getHiddenWord().Length; userGuessPos++)
                {
                    if (input[userGuessPos] == Program.getHiddenWord()[hiddenWordPos])
                    {
                        if (hiddenWordPos == userGuessPos)
                        {
                            Program.increaseNumOfBulls();
                        }
                        else
                        {
                            Program.increaseNumOfCows();
                        }
                    }
                }
            }
            Program.increaseCurrentAttempt();

        }

        public static bool validDifficulty(string input)
        {
            String word = input;
            if (!(word.Equals(Difficulties.Easy.ToString().ToLower()) || word.Equals(Difficulties.Normal.ToString().ToLower()) || word.Equals(Difficulties.Hard.ToString().ToLower())))
            {
                return false;
            }   
            else
            {
                return true;
            }
        }
    }
}
