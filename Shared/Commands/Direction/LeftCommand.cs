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
            try
            {
                var caterPillar = CaterPillarFactory.GetCaterPillar();

                Map.Print(caterPillar.MoveLeft(Steps));
            }
            catch (Exception)
            {
                CaterPillarFactory.GetCaterPillar(true);
            }
        }
    }
}
