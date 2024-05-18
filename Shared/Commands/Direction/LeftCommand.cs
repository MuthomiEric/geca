using Shared.Helpers;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Commands.Direction
{
    public class LeftCommand : ICommand
    {
        public LeftCommand(int steps)
        {
            Steps = steps;
        }
        public int Steps { get; set; }

        public void Execute()
        {
            var _caterPillar = CaterPillarFactory.GetCaterPillar();
        }
    }
}
