using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Ship
{
    public class PatrolBoat : Ship
    {
        public override string Name { get; set; } = "PatrolBoat";
        public override int Length { get; set; } = 2;
        public override List<Coordinate> Coordinate { get; set; }

        public override void CreateShip()
        {
            Random rand = new Random();
            int x = rand.Next(1, 9);
            int y = rand.Next(1, 10);

            for (int i = 0; i < Length; i++)
            {
                Coordinate.Add(new Coordinate(x+i, y));
            }
        }

    }
}
