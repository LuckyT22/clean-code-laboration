
using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;

namespace laboration
{
    public class GameManager
    {
        private readonly ConsoleIO _console;
        private readonly ResultsUpdateAndSave _resultsUpdateAndSave;
        private readonly CowsAndBullsCalculator _cowsAndBullsCalculator;
        private readonly Leaderboard _leaderboard;
        private readonly GoalGenerator _goalGenerator;
        private readonly ValidPlayerGuess _validPlayerGuess;

        public GameManager(ConsoleIO console, ResultsUpdateAndSave resultsUpdateAndSave, CowsAndBullsCalculator cowsAndBullsCalculator, Leaderboard leaderboard, GoalGenerator goalGenerator, ValidPlayerGuess validPlayerGuess)
        {
            _console = console;
            _resultsUpdateAndSave = resultsUpdateAndSave;
            _cowsAndBullsCalculator = cowsAndBullsCalculator;
            _leaderboard = leaderboard;
            _goalGenerator = goalGenerator;
            _validPlayerGuess = validPlayerGuess;
        }

        public void StartGame()
        {
            var playerName = _console.ReadInput("Enter your user name:");
            bool isPlaying = true;

            while (isPlaying)
            {
                PlayRound(playerName);
                isPlaying = ShouldContinuePlaying();
            }
        }

        public void PlayRound(string playerName)
        {
            var goal = _goalGenerator.GenerateGoal();
            _console.WriteOutput("New game:\n");
            _console.WriteOutput("For practice, number is: " + goal + "\n"); // Can be commented out for real games

            var attempts = 0;
            string cowsAndBullsGoal;

            do
            {
                var guess = _validPlayerGuess.GetValidPlayerGuess();
                attempts++;
                cowsAndBullsGoal = _cowsAndBullsCalculator.Calculate(goal, guess);
                _console.WriteOutput(cowsAndBullsGoal + "\n");
            } while (!IsCorrectGuess(cowsAndBullsGoal));

            _resultsUpdateAndSave.SaveResult(playerName, attempts);
            _leaderboard.Display();
            _console.WriteOutput($"Correct, it took {attempts} guesses.");
        }

        public bool IsCorrectGuess(string feedback)
        {
            return feedback == "BBBB,";
        }

        public bool ShouldContinuePlaying()
        {
            var answer = _console.ReadInput("Continue? (y/n)");
            return !string.IsNullOrEmpty(answer) && answer.ToLower().StartsWith("y");
        }
    }
}