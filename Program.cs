
namespace laboration
{
    class Program
    {
        static void Main(string[] args)
        {
            // get all dependenceies
            var consoleIO = new ConsoleUI();
            var fileService = new FileServiceSystem();
            var feedbackCalculator = new CowsAndBullsCalculator();
            var leaderboard = new Leaderboard(fileService, consoleIO);

            // gamemanager w/ all of the dependenceies
            var gameManager = new GameManager(consoleIO, fileService, feedbackCalculator, leaderboard);

            //  game starting 
            gameManager.StartGame();
        }
    }
}