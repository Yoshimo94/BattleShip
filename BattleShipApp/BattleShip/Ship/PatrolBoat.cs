using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Ship
{
    internal class PatrolBoat : Ship
    {
        public override string Name { get; set; } = "PatrolBoat";
        public override int Length { get; set; } = 2;
        public override List<Position> Position { get; set; }

    }
}
