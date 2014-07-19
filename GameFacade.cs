using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public class GameFacade
    {
        private GameStrategy engine;

        public GameFacade(IPlayable gameInstance)
        {
            this.engine = new GameEngine(gameInstance);
        }

        public void Operation(string @command)
        {
            switch (@command)
            {
                case "start":
                    this.engine.Start();
                    break;
                case "restart":
                    this.engine.Restart();
                    break;
                case "top":
                    this.engine.Top();
                    break;
                case "exit":
                    this.engine.Exit();
                    break;
                default:
                    int number;
                    bool isIntNumber = int.TryParse(@command, out number);

                    if (isIntNumber)
                    {
                        this.engine.MoveNumber(number);
                    }
                    else
                    {
                        Console.WriteLine("Illegal command!");
                    }
                    break;
            }

        }
    }
}
