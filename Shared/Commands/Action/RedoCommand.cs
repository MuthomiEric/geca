﻿using Shared.Helpers;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Commands.Action
{
    public class RedoCommand : ICommand
    {
        public void Execute()
        {
            var _caterPillar = CaterPillarFactory.GetCaterPillar();
        }
    }
}
