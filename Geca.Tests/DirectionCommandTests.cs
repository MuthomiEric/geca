using Shared.Exceptions;
using Shared.Models;

namespace Geca.Tests
{
    public class DirectionCommandTests
    {
        [Fact]
        public void Test_that_going_outside_the_area_resets_the_worm_position()
        {
            var mapObj = new Map(30, 30);

            var map = mapObj.InitializeMap();

            var caterpillar = new CaterPillar(map);

            Assert.Throws<IndexOutOfRangeException>(() => caterpillar.MoveUp(30));
        }
    }
}
