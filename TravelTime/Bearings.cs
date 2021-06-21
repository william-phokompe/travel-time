using System;

namespace TravelTime
{
    public class Bearings
    {
        public int North { get; set; }

        public int East { get; set; }
        public int South { get; set; }
        public int West { get; set; }

        public int Speed { get; set; }

        public Bearings(int north, int east, int south, int west, int speed)
        {
            North = north;
            East = east;
            South = south;
            West = west;
            Speed = speed;
        }

        public int getUniqueSquares()
        {
            int horizontalTravel = 0;
            int verticalTravel = 0;
            int uniqueSquares = 0;

            horizontalTravel = North == 0 || South == 0 ? 0 : Math.Abs(North - South);
            verticalTravel = East == 0 || West == 0 ? 0 : Math.Abs(East - West);
            uniqueSquares = North + East + West + South;

            if (horizontalTravel == verticalTravel && (horizontalTravel > 1 || verticalTravel > 1))
            {
                uniqueSquares -= 1;
            }

            return uniqueSquares;
        }

        public int getTimeTaken() => Speed * getUniqueSquares();
    }
}