using ShipsGame.Enums;

namespace ShipsGame
{
    public class Ship
    {
        public ShipType ShipType { get; }
        public List<Coord> ShipPoints { get; }
        public bool IsDestroyed { get; }

        public Ship(ShipType shipType, List<Coord> shipPoints)
        {
            ShipType = shipType;
            ShipPoints = shipPoints;
            IsDestroyed = false;
        }
    }
}
