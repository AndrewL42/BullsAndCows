using System;

namespace BullsAndCows
{
    class Program
    {
        static string hiddenWord = "";
        static string userResponse = "";
        static string difficulty = "";
        static int numOfTries = 0;
        static int currentAttempt = 0;
        static int numOfBulls = 0;
        static int numOfCows = 0;
        static bool playingGame = true;

        static void Main(string[] args)
        {
            do
            {
                StartGame();
                PlayGame();
            } while (playingGame);
            Environment.Exit(0);
            
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
            if (!(WordCheck.validDifficulty(userResponse.ToLower())))
            {
                Console.WriteLine("\n\nSorry, that's not a valid option! Restarting program... \n\n");
                return;
            }
            hiddenWord = WordCheck.checkDifficultyAndGetWords(userResponse.ToLower()).ToString();
            Console.WriteLine("\nYou have chosen: " + userResponse + ". Selecting a word...\n");
            Console.WriteLine("The word has been chosen! It is: " + hiddenWord.Length + " characters long.\nYou have: " + numOfTries + " tries. Try your best and have fun!\n" );
            

        }

        public static void PlayGame()
        {
            while (currentAttempt < numOfTries)
            {
                Console.WriteLine("Guess an isogramic word!\n");
                Console.WriteLine(hiddenWord);
                userResponse = Console.ReadLine().ToLower();


                if (userResponse.Equals(hiddenWord))
                {
                    Console.WriteLine("Congratulations, you got the word right! It was: " + hiddenWord + ". Would you like to play again? Y/N");
                    userResponse = Console.ReadLine();
                    if (userResponse.Equals("y"))
                    {
                        playingGame = true;
                        Console.WriteLine("\nYou have decided to play again! Please wait a moment while we reset everything...");
                        System.Threading.Thread.Sleep(2000);
                        System.Console.Clear();
                        resetGame();
                    }
                    else if (userResponse.Equals("n"))
                    {
                        playingGame = false;
                        Console.WriteLine("Thanks for playing! Terminating program.");
                    }
                    else
                    {
                        playingGame = false;
                        Console.WriteLine("You did not choose a valid option! Ending game.");
                    }
                }

                WordCheck.checkGuess(userResponse);
                Console.WriteLine("The number of bulls you got are: " + numOfBulls + ".\nThe number of cows you got are: " + numOfCows + ".\nYou have used " + currentAttempt + " out of " + numOfTries + " attempts.");
            }

        }


        public static void resetGame()
        {
            hiddenWord = "";
            userResponse = "";
            difficulty = "";
            numOfTries = 0;
            StartGame();
        }

        public static void endGame()
        {
            Console.WriteLine("Sorry, you've used up all your attempts and have lost!\n" +
                "The secret word was" + hiddenWord + ". Better luck next time!\n" +
                "Would you like to try again? Y/N");
            userResponse = Console.ReadLine();
            if (userResponse.ToLower() == "y")
            {
                playingGame = true;
                Console.WriteLine("\nYou have decided to play again! Please wait a moment while we reset everything...");
                System.Threading.Thread.Sleep(2000);
                System.Console.Clear();
                resetGame();
            }
            else if (userResponse.ToLower() == "n")
            {
                playingGame = false;
                Console.WriteLine("You have decided not to play again. Thanks for playing!");
            }
            else
            {
                playingGame = false;
                Console.WriteLine("No valid option chosen. Ending game");
            }
        }

        public static string getHiddenWord()
        {
            return hiddenWord;
        }

        public static string getUserResponse()
        {
            return userResponse;
        }

        public static void setNumOfTires(int tries)
        {
            numOfTries = tries;
        }

        public static void increaseNumOfBulls()
        {
            numOfBulls++;
        }

        public static void increaseNumOfCows()
        {
            numOfCows++;
        }

        public static void resetCowsAndBulls()
        {
            numOfBulls = 0;
            numOfCows = 0;
        }

        public static void increaseCurrentAttempt()
        {
            currentAttempt++;
        }
    }
}
