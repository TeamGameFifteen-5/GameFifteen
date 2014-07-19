using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    internal class GameCommand : Command
    {
        private readonly GameFacade gameFacade;
        private string @command;

        public GameCommand(GameFacade gameFacade, string @command)
        {
            this.gameFacade = gameFacade;
            this.@command = @command;
        }

        public string Operator
        {
            set { this.@command = value; }
        }

        public override void Execute()
        {
            this.gameFacade.Operation(this.@command);
        }
    }
}
