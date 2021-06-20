using System;

namespace travel_time
{
    class Program
    {
        private static int SquareVisits, North, South, East, West = 0;
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                // Expecting one parameter
                string input = args[0].ToUpper();
                try
                {
                    // Assuming instructions are comma delimited, and no same consecutive instructions
                    // example: N4 E2 S2 W4  
                    string[] instructions = input.Split(',');
                    validateUserEntry(instructions);

                    // store the first instruction                    
                    calculateSquareTravel();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("The robot travelled: {0}", SquareVisits);
                Console.WriteLine("Took {0} right turns.", )
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please enter valid instructions.");
            }
        }

        private static void validateUserEntry(string[] instructions)
        {
            for (int i = 0; i < instructions.Length - 1; ++i)
            {
                if (!instructions[i + 1][0].Equals(getNextInstruction(instructions[i]))) {
                    throw new Exception("Robot can only turn right. Please review and retry.");
                }
            }

            // Store direction and distance of the last instruction
            getNextInstruction(instructions[instructions.Length - 1]);
        }

        public static char getNextInstruction(string instruction)
        {
            char next = new char();
            char direction = instruction[0];
            int distance = int.Parse(instruction.Substring(1, instruction.Length - 1));
            
            // Determine which instruction should be next
            switch (direction)
            {
                case 'N':
                    North = distance;
                    next = 'E';
                    break;
                case 'S':
                    South = distance;
                    next = 'W';
                    break;
                case 'E':
                    East = distance;
                    next = 'S';
                    break;
                case 'W':
                    West = distance;
                    next = 'N';
                    break;
                default:
                    throw new Exception("Invalid instruction found. Please retry.");
            }

            return next;
        }

        public static void calculateSquareTravel()
        {
            SquareVisits = North + South + East + West;

            // Calculate if robot made full revolution
            int horizontalTravel = North == 0 || South == 0 ? 0 : Math.Abs(North - South);
            int verticalTravel = East == 0 || West == 0 ? 0 : Math.Abs(East - West);

            if (horizontalTravel == verticalTravel && (horizontalTravel > 1 || verticalTravel > 1)) {
                SquareVisits -= 1;
            }
        }
    }
}
