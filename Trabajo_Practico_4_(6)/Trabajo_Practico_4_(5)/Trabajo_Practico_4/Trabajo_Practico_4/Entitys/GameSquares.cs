using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Practico_4.Entitys
{
    internal class GameSquares
    {
        public int[,] Squares { get; set; }

        public GameSquares()
        {
            Squares = new int[3, 3];
        }
    }
}
