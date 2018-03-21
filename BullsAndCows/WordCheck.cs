using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
                Array values = Enum.GetValues(typeof(EasyWords));
                EasyWords randomWord = (EasyWords)values.GetValue(RNG.Next(values.Length));
                Program.setNumOfTires(5);
                return randomWord;
            }
            else if (word.Equals(Difficulties.Normal.ToString().ToLower()))
            {
                Array values = Enum.GetValues(typeof(NormalWords));
                NormalWords randomWord = (NormalWords)values.GetValue(RNG.Next(values.Length));
                Program.setNumOfTires(8);
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

        public static String validString(string input)
        {
            String word = input;
            String error = "none";
            bool hasInt = containsInt(word);
            bool hasDuplicate = containsDuplicates(word);

            if (hasDuplicate || hasInt)
            {
                error = Errors.NotAnIsogram.ToString();
                return error;
            }
            else if (input.Length > Program.getHiddenWord().Length)
            {
                error = Errors.WordLengthTooLong.ToString();;
                return error;
            }
            else if (input.Length < Program.getHiddenWord().Length)
            {
                error = Errors.WordLengthTooShort.ToString();
                return error;
            }
            error = Errors.None.ToString();
            return error;
        }

        public static bool containsInt(string input)
        {
            String word = input;
            bool hasInt = word.Any(c => char.IsDigit(c));
            return hasInt;
        }

        public static bool containsDuplicates(string input)
        {
            String word = input;
            char[] wordAlphabetical = word.ToCharArray();
            bool hasDuplicate = false;


            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (wordAlphabetical[i].Equals(wordAlphabetical[j]))
                    {
                        hasDuplicate = true;
                        break;
                    }
                }
            }


            return hasDuplicate;
        }
    }
}
