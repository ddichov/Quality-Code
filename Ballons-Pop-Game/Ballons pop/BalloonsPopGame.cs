using System;
using System.Linq;

namespace BalloonsPop
{
    class BalloonsPopGame
    {
        static TopScoresChart topResults;
        static GameManager gameManager;

        static void Main(string[] args)
        {
            topResults = new TopScoresChart(5);
            gameManager = new GameManager();

            ConsoleRenderer.DrаwPlayground(gameManager.PlayGround);
            string userInput = null;
            while (userInput != "EXIT")
            {
                userInput = ConsoleInterface.RequestInput();

                switch (userInput)
                {
                    case "RESTART":
                        gameManager = RestartGame();
                        ConsoleRenderer.DrаwPlayground(gameManager.PlayGround);
                        break;

                    case "TOP":
                        ConsoleRenderer.DrawTopScoresChart(topResults);
                        break;

                    default:
                        PlayMove(userInput);
                        break;
                }
            }

            Console.WriteLine("Good Bye! ");
        }

        private static void PlayMove(string userInput)
        {
            if (ConsoleInterface.IsValidInput(userInput))
            {
                int userRow = int.Parse(userInput[0].ToString());
                int userColumn = int.Parse(userInput[2].ToString());

                if (!gameManager.PlayGround.IsOnPlayground(userRow, userColumn))
                {
                    Console.WriteLine("Invalid playground coordinates! Please try again");
                    return;
                }

                if (gameManager.PlayGround.IsPositionEmpty(userRow, userColumn))
                {
                    Console.WriteLine("Cannot pop missing ballon!");
                    return;
                }
               
                gameManager.PopAtPosition(userRow, userColumn);
                gameManager.PlayGround.ReorderPlayground();

                if (gameManager.PlayGround.IsPlaygroundEmpty())
                {
                    gameManager = EndGame();
                }

                ConsoleRenderer.DrаwPlayground(gameManager.PlayGround);
            }
            else
            {
                Console.WriteLine("Wrong input! Try Again! ");
            }
        }

        private static GameManager EndGame()
        {
            Console.WriteLine("Gratz ! You completed it in {0} moves.", gameManager.UserMoves);
            if (topResults.CheckIfHighScoreIsAchieved(gameManager.UserMoves))
            {
                TopScoresChartEntry newTopScore = ConsoleInterface.RequestInputForScoreBoard(gameManager.UserMoves);
                topResults.AddScore(newTopScore);
            }
            else
            {
                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
            }

            return new GameManager();
        }

        private static GameManager RestartGame()
        {
            return (new GameManager());
        }
    }
}
