using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Ship
{
    public class Carrier : Ship
    {
        public override string Name { get; set; } = "Carrier";
        public override int Length { get; set; } = 5;
        public override List<Coordinate> Coordinate { get; set; }
    }
}
