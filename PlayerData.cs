using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration
{
    public class PlayerData
    {
        public string Name { get; }
        public int GamesPlayed { get; private set; }
        public double AverageGuesses => (double)_totalGuesses / GamesPlayed;

        private int _totalGuesses;

        public PlayerData(string name, int guesses)
        {
            Name = name;
            GamesPlayed = 1;
            _totalGuesses = guesses;
        }

        public void Update(int guesses)
        {
            _totalGuesses += guesses;
            GamesPlayed++;
        }
    }
}
