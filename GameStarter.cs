
namespace laboration
{
    public class GameStarter
    {
        static void Main(string[] args)
        {
            var consoleIO = new ConsoleIO();
            var resultsUpdateAndSave = new ResultsUpdateAndSave();
            var cowsAndBullsCalculator = new CowsAndBullsCalculator();
            var leaderboard = new Leaderboard(resultsUpdateAndSave, consoleIO);
            var goalGenerator = new GoalGenerator();
            var validPlayerGuess = new ValidPlayerGuess();

            var gameManager = new GameManager(consoleIO, resultsUpdateAndSave, cowsAndBullsCalculator, leaderboard, goalGenerator, validPlayerGuess);

            gameManager.StartGame();
        }
    }
}