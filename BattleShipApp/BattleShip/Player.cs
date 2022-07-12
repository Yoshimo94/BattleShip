using BattleShip.Ship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Player
    {
        public string Name { get; set; }
        public GameBoard _board { get; set; }
        public List<IShip> _ships { get; set; }

    }
}
