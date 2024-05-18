﻿using Shared.Helpers;
using Shared.Interfaces;
using Shared.Models;

namespace Shared.Commands.Direction
{
    public class UpCommand : ICommand
    {
        public int Steps { get; set; }
        public UpCommand(int steps)
        {
            Steps = steps;
        }
        public void Execute()
        {
            var caterPillar = CaterPillarFactory.GetCaterPillar();

            Map.Print(caterPillar.MoveUp(Steps));
        }
    }
}
