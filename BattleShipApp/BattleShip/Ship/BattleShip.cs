using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Ship
{
    public class BattleShip : Ship
    {
        public override string Name { get; set; } = "BattleShip";
        public override int Length { get; set; } = 4;
        public override List<Coordinate> Coordinate { get; set; }

    }
}
