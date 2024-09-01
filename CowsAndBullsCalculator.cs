
namespace laboration
{
    public class CowsAndBullsCalculator
    {
        public string Calculate(string goal, string guess)
        {
            var bulls = 0;
            var cows = 0;

            for (int i = 0; i < goal.Length; i++)
            {
                if (goal[i] == guess[i])
                {
                    bulls++;
                }
                else if (goal.Contains(guess[i]))
                {
                    cows++;
                }
            }

            return $"{new string('B', bulls)},{new string('C', cows)}";
        }
    }
}