using System;

namespace travel_time
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                int numberOfRightTurns = 0, travelTime = 0;
                int squareVisits = 0;
                // pull instrutions
                string instructionInput = args[0].ToUpper();
                int speed = 0;
                Bearings robotBearings;
                try
                {
                    // Assuming instructions are comma delimited, and no same consecutive instructions
                    // example: N4 E2 S2 W4  
                    string[] instructions = instructionInput.Split(',');
                    if (args.Length > 1)
                    {
                        speed = int.Parse(args[1].Substring(1, args[1].IndexOf('m') - 1));
                    }

                    // validate instructions entered
                    validateUserEntry(instructions);

                    // Calculate unique squares the robot visited
                    robotBearings = getSquaresToTravel(instructions, speed);
                    squareVisits = robotBearings.getUniqueSquares();

                    // Calculate time taken
                    travelTime = robotBearings.getTimeTaken();

                    // get number of right turns:
                    numberOfRightTurns = instructions.Length;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("Unique Squares Traversed: {0}", squareVisits);
                Console.WriteLine("Right Turns Made: {0}", numberOfRightTurns);
                if (args.Length > 1)
                {
                    Console.WriteLine("Time to Execute @ 1m/s: {0}s", travelTime);
                }
                else
                {
                    Console.WriteLine("Speed of robot not specified.");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please enter valid instructions.");
            }
        }

        public static char validateRightRurn(char bearing)
        {
            char next = new char();
            switch (bearing)
            {
                case 'N':
                    next = 'E';
                    break;
                case 'S':
                    next = 'W';
                    break;
                case 'E':
                    next = 'S';
                    break;
                case 'W':
                    next = 'N';
                    break;
                default:
                    throw new Exception("Invalid instruction found. Please retry.");
            }

            return next;
        }

        public static void validateUserEntry(string[] instructions)
        {
            // Check if the last instruction on the list is correct (N,E,S or W)
            validateRightRurn(instructions[instructions.Length - 1][0]);

            for (int i = 0; i < instructions.Length - 1; i++)
            {
                if (!instructions[i + 1][0].Equals(validateRightRurn(instructions[i][0])))
                {
                    throw new Exception("Robot can only turn right. Please review (" + instructions[i + 1] + ") and retry.");
                }
            }
        }

        public static Bearings getSquaresToTravel(string[] instructions, int speed)
        {
            int north = 0, east = 0, south = 0, west = 0;
            int squares = 0;
            foreach (var instruction in instructions)
            {
                squares = int.Parse(instruction.Substring(1, instruction.Length - 1));
                switch (instruction[0])
                {
                    case 'N':
                        north = squares;
                        break;
                    case 'E':
                        east = squares;
                        break;
                    case 'S':
                        south = squares;
                        break;
                    case 'W':
                        west = squares;
                        break;
                }
            }

            return new Bearings(north, east, south, west, speed);
        }
        public static int getNumberOfRightTurns(string[] instructions) => instructions.Length;
    }
}
