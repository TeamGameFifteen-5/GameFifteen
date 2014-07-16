using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen
{
    public interface IPlayable
    {
        int[,] BoardNumbers { get; }
        void CreateGameField();
        int Counter { get; set; }
        int CurrentBoardRow { get; set; }
        int CurrentBoardCol { get; set; }
        int this[int a, int b] { get; set; }
    }
}
