using System;

namespace laboration
{
    public class Leaderboard
    {
        public readonly ResultsUpdateAndSave _resultsUpdateAndSave;
        public readonly ConsoleIO _console;

        public Leaderboard(ResultsUpdateAndSave resultsUpdateAndSave, ConsoleIO console)
        {
            _resultsUpdateAndSave = resultsUpdateAndSave;
            _console = console;
        }

        public void Display()
        {
            var results = _resultsUpdateAndSave.LoadResults();
            results.Sort((p1, p2) => p1.AverageGuesses.CompareTo(p2.AverageGuesses));

            _console.WriteOutput("Player   Games   Average");
            foreach (var player in results)
            {
                _console.WriteOutput($"{player.Name,-9}{player.GamesPlayed,5}{player.AverageGuesses,9:F2}");
            }
        }
    }
}