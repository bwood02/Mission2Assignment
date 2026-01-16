using System;
using System.Collections.Generic;
using System.Text;
// using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mission2Assignment
{
    internal class RollDice
    {
        // number of rolls stored for optional fallback
        public int rolls;
        public int[] FrequencyCounts { get; private set; }

        public RollDice()
        {
            // set rolls as 0 rolls until changed
            rolls = 0;
            FrequencyCounts = new int[11]; // 11 integers for sums 2 through 12
        }

        public int[] TossDice(int numberOfRolls)
        {
            // if it's called with a non-positive value, use the instance value
            if (numberOfRolls <= 0) numberOfRolls = rolls;

            // if still not positive, nothing to do — return an empty array
            if (numberOfRolls <= 0) return Array.Empty<int>();

            // remember the requested rolls on the instance for potential later use
            rolls = numberOfRolls;

            var outcomes = new int[numberOfRolls];
            FrequencyCounts = new int[11]; // reset frequency counts

            var rng = new Random(); // create a new Random object 
            for (int i = 0; i < numberOfRolls; i++)
            {
                int sum = rng.Next(1, 7) + rng.Next(1, 7); // each Next(1, 7) yields 1-6
                outcomes[i] = sum;
                FrequencyCounts[sum - 2]++; // the sum is 2-12, needs to map to indexes 0-10
            }

            return outcomes;
        }
    }
}
