using System;
using Xunit;

namespace TravelTime.Tests
{
    public class TravelTime_NumberOfRightTurns
    {
        [Fact]
        public void NumebrOfRightTurns()
        {
            string[] instructions = new string[4]{ "N4", "E2", "S2", "W4" };

            bool result = Program.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }
    }
}
