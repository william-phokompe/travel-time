using System;
using Xunit;

namespace TravelTime.Tests
{
    public class TravelTime_Test
    {
        private string[] instructions = new string[4]{ "N4", "E2", "S2", "W4" };
        [Fact]
        public void NumebrOfRightTurns()
        {
            int result = Program.getNumberOfRightTurns(instructions);

            Assert.Equal(3, result);
        }

        [Fact]
        public void SquaresToTravel()
        {
            string[] input = new string[7]{ "N4", "E2", "S2", "W4", "N3", "E4", "S6" };
            Bearings bearings = Program.getSquaresToTravel(input, 2); // Speed = 2

            int squareVisits = bearings.getUniqueSquares();

            Assert.Equal(17, squareVisits);
        }

        [Fact]
        public void InputValidation_InvalidInstruction()
        {
            string[] input = new string[7]{ "N4", "E2", "S2", "W4", "C3", "E4", "S6" };

            var ex = Assert.Throws<Exception>(() => Program.validateUserEntry(input));
            Assert.Equal("Invalid instruction found. Please retry.", ex.Message);
        }

        [Fact]
        public void InputValidation_RightTurn() {
            string[] input = new string[7]{ "N4", "E2", "S2", "W4", "S3", "E4", "S6" };

            var ex = Assert.Throws<Exception>(() => Program.validateUserEntry(input));
            Assert.Equal("Robot can only turn right. Please review and retry.", ex.Message);
        }

        [Fact]
        public void TimeTakenToTravel()
        {
            // North = 4, East = 3, South = 2, West = 4, Speed = 1
            Bearings bearings = new Bearings(4, 2, 2, 4, 1);

            int time = bearings.getTimeTaken();

            Assert.Equal(11, time);
        }
    }
}
