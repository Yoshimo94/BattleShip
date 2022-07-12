using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Ship
{
    public class Destroyer : Ship
    {
        public override string Name { get; set; } = "Destroyer";
        public override int Length { get; set; } = 3;
        public override List<Coordinate> Coordinate { get; set; }
    }
}
