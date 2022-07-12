using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Ship
{
    public abstract class Ship : IShip
    {
        public abstract string Name { get; set; }
        public abstract int Length { get; set; }
        public abstract List<Coordinate> Coordinate { get; set; }

        public abstract void CreateShip();

    }
}
