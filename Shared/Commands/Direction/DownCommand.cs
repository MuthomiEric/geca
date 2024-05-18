using Shared.Helpers;
using Shared.Interfaces;
using Shared.Models;

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
            try
            {
                var caterPillar = CaterPillarFactory.GetCaterPillar();

                Map.Print(caterPillar.MoveDown(Steps));
            }
            catch (Exception)
            {
                CaterPillarFactory.GetCaterPillar(true);
            }
        }
    }
}
