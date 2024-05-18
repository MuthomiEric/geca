using Shared.Helpers;
using Shared.Interfaces;

namespace Shared.Commands.Action
{
    public class GrowCommand : ICommand
    {        
        public void Execute()
        {
            var _caterPillar = CaterPillarFactory.GetCaterPillar();
        }
    }
}
