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

            if (word.Equals(Difficulties.Easy.ToString()))
            {
                Array values = Enum.GetValues(typeof(EasyWords));
                EasyWords randomWord = (EasyWords)values.GetValue(RNG.Next(values.Length));
                return randomWord;
            }
            else if (word.Equals(Difficulties.Normal.ToString()))
            {
                //return Difficulties.Normal.ToString();
                return null;
            }
            else if (word.Equals(Difficulties.Hard.ToString()))
            {
                //return Difficulties.Hard.ToString();
                return null;
            }
            else
            {
                return null;
            }
        }

        public static void checkGuess()
        {

        }

        public static bool validDifficulty(string input)
        {
            String word = input;
            if (!(word.Equals(Difficulties.Easy.ToString()) || word.Equals(Difficulties.Normal.ToString()) || word.Equals(Difficulties.Hard.ToString())))
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
