using System;

namespace laboration
{
    public class Leaderboard
    {
        private readonly FileServiceSystem _fileServiceSystem;
        private readonly ConsoleUI _console;

        public Leaderboard(FileServiceSystem fileServiceSystem, ConsoleUI console)
        {
            _fileServiceSystem = fileServiceSystem;
            _console = console;
        }

        public void Display()
        {
            var results = _fileServiceSystem.LoadResults();
            results.Sort((p1, p2) => p1.AverageGuesses.CompareTo(p2.AverageGuesses));

            _console.WriteOutput("Player   Games   Average");
            foreach (var player in results)
            {
                _console.WriteOutput($"{player.Name,-9}{player.GamesPlayed,5}{player.AverageGuesses,9:F2}");
            }
        }
    }
}