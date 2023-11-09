using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trabajo_Practico_4.Entitys;

namespace Trabajo_Practico_4.Entitys
{
    internal class SudokuGen
    {
        public GameSquares[,] GamePanel { get; set; }
        public int Id { get; set; }
        public TimeOnly Time { get; set; }
        public bool Status { get; set; }
        public int[] Squares { get; set; }

        public SudokuGen(GameSquares[] gamepanel)
        {
            GamePanel = new GameSquares[3, 3]
            {
                { new GameSquares(), new GameSquares(), new GameSquares() },
                { new GameSquares(), new GameSquares(), new GameSquares() },
                { new GameSquares(), new GameSquares(), new GameSquares() }
            };
        }
    }
}
