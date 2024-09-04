using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboration
{
    public class GoalGenerator
    {
        public string GenerateGoal()
        {
            var random = new Random();
            var goal = new HashSet<int>();

            while (goal.Count < 4)
            {
                goal.Add(random.Next(10));
            }

            return string.Join("", goal);
        }
    }
}
