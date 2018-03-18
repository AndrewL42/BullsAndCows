using System;

namespace BullsAndCows
{
    class Program
    {
        static string hiddenWord = "";
        static string userResponse = "";
        static string difficulty = "";

        static void Main(string[] args)
        {
            StartGame();

            


        }

        public static void StartGame()
        {
            Console.WriteLine("Welcome to Bulls and Cows, a fun word game.\n\n");
            Console.WriteLine("          }   {         ___ ");
            Console.WriteLine("          (o o)        (o o) ");
            Console.WriteLine("   /-------\\ /          \\ /-------\\ ");
            Console.WriteLine("  / | BULL |O            O| COW  | \\ ");
            Console.WriteLine(" *  |-,--- |              |------|  * ");
            Console.WriteLine("    ^      ^              ^      ^ \n\n");

            Console.WriteLine("What difficulty would you like? Easy, Normal, or Hard?");
            userResponse = Console.ReadLine();
            if (!(WordCheck.validDifficulty(userResponse)))
            {
                Console.WriteLine("\n\nSorry, that's not a valid option! Restarting program... \n\n");
                StartGame();
            }
            difficulty = WordCheck.checkDifficultyAndGetWords(Console.ReadLine()).ToString();
            Console.WriteLine("You have chosen: " + difficulty + ". Selecting a word...");
            
            

        }

        /*public static string pickWord()
        {
            if (difficulty.Equals(Difficulties.Easy))
            {

            }
        }*/

        public static string getHiddenWord()
        {
            return hiddenWord;
        }

        public static string getUserResponse()
        {
            return userResponse;
        }
    }
}
