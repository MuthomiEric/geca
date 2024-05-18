using Shared.Helpers;
using Shared.Interfaces;

namespace Shared.Commands.Direction
{
    public class DownCommand : ICommand
    {
        public DownCommand(int steps)
        {
            Steps = steps;
        }
        public int Steps { get; set; }

        public void Execute()
        {
            var caterPillar = CaterPillarFactory.GetCaterPillar();

            caterPillar.MoveDown(Steps);
        }
    }
}
