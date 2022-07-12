using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class GameBoard
    {
        public List<Coordinate> Coordinates { get; set; }
        public void CreateGameBoard()
        {
            for (int x = 1; x < 11; x++)
            {
                for (int y = 1; y < 11; y++)
                {
                    var coord = new Coordinate(x, y);
                    Coordinates.Add(coord);
                }
            }
        }
    }
}
