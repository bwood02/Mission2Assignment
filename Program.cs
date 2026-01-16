using Mission2Assignment;

internal class Program
{
    private static void Main(string[] args)
    {
        int rolls = 0;

        System.Console.WriteLine("\nWelcome to the dice throwing simulator!\n");
        System.Console.WriteLine("How many dice rolls would you like to simulate?\n");

        while (true) // test 
        {
            string input = System.Console.ReadLine();
            try
            {
                rolls = int.Parse(input); // attempt to change input to an integer
                if (rolls > 0) break; // if it's an int > 0, update 'rolls' & move on
            }
            catch
            {
                // if the parse gives errors or rolls isn't positive, re-prompt
            }

            System.Console.WriteLine("\nPlease enter a positive whole number:\n");
        }

        // create a RollDice instance and pass the user's count into TossDice
        RollDice roller = new RollDice();
        roller.TossDice(rolls); // save the results from the method to the 'roller' instance

        System.Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        System.Console.WriteLine("Each \"*\" Represents 1% of the total number of rolls.");
        System.Console.WriteLine("Total number of rolls = " + rolls + "\n");

        // histogram printing using FrequencyCounts for sums 2-12
        for (int sum = 2; sum <= 12; sum++)
        {
            int count = roller.FrequencyCounts[sum - 2]; // for each sum, count the # of instances based on the index (sum - 2)
            int stars = (int)System.Math.Round(count * 100.0 / rolls); // calculate # of stars by 1% of total rolls 
            string bar = stars > 0 ? new string('*', stars) : string.Empty; 
                // if stars > 0, then make a string with exactly 'stars' number of asterisks (*), otherwise make an empty string
            System.Console.WriteLine($"{sum}: {bar}");
        }

        System.Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        System.Console.WriteLine("Press any key to exit...");
        System.Console.ReadKey();
    }
}