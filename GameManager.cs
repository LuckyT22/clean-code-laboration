
namespace laboration
{
    public class GameManager
    {
        private readonly ConsoleUI _console;
        private readonly FileServiceSystem _fileServiceSystem;
        private readonly CowsAndBullsCalculator _cowsAndBullsCalculator;
        private readonly Leaderboard _leaderboard;

        public GameManager(ConsoleUI console, FileServiceSystem fileServiceSystem, CowsAndBullsCalculator cowsAndBullsCalculator, Leaderboard leaderboard)
        {
            _console = console;
            _fileServiceSystem = fileServiceSystem;
            _cowsAndBullsCalculator = cowsAndBullsCalculator;
            _leaderboard = leaderboard;
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

        private void PlayRound(string playerName)
        {
            var goal = GenerateGoal();
            _console.WriteOutput("New game:\n");
            _console.WriteOutput("For practice, number is: " + goal + "\n");

            var attempts = 0;
            string cowsAndBullsGoal;

            do
            {
                var guess = GetValidPlayerGuess();
                attempts++;
                cowsAndBullsGoal = _cowsAndBullsCalculator.Calculate(goal, guess);
                _console.WriteOutput(cowsAndBullsGoal + "\n");
            } while (!IsCorrectGuess(cowsAndBullsGoal));

            _fileServiceSystem.SaveResult(playerName, attempts);
            _leaderboard.Display();
            _console.WriteOutput($"Correct, it took {attempts} guesses.");
        }

        private string GenerateGoal()
        {
            var random = new Random();
            var goal = new HashSet<int>();

            while (goal.Count < 4)
            {
                goal.Add(random.Next(10));
            }

            return string.Join("", goal);
        }

        private string GetValidPlayerGuess()
        {
            string guess;
            do
            {
                guess = _console.ReadInput("Enter your 4-digit guess: ");
                if (guess.Length != 4 || !int.TryParse(guess, out _))
                {
                    _console.WriteOutput("Invalid input. Please enter exactly 4 digits.");
                }
            } while (guess.Length != 4 || !int.TryParse(guess, out _));

            return guess;
        }
        private bool IsCorrectGuess(string feedback)
        {
            return feedback == "BBBB,";
        }

        private bool ShouldContinuePlaying()
        {
            var answer = _console.ReadInput("Continue? (y/n)");
            return !string.IsNullOrEmpty(answer) && answer.ToLower().StartsWith("y");
        }
    }
}