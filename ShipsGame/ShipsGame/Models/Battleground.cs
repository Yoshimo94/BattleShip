using ShipsGame.Enums;

namespace ShipsGame;

public class Battleground
{
    private readonly Random _random = new();
    public List<Ship> Ships { get; }
    public List<Coord> MapCoords { get; }

    public Battleground()
    {
        Ships = new List<Ship>();
        MapCoords = new List<Coord>();
        GenerateBattlegroundDetails();
    }

    private void GenerateBattlegroundDetails()
    {
        GenerateMapCoords();
        GenerateShip(ShipType.Carrier);
        GenerateShip(ShipType.Battleship);
        GenerateShip(ShipType.Destroyer);
        GenerateShip(ShipType.Destroyer);
        GenerateShip(ShipType.PatrolBoat);
    }

    private void GenerateShip(ShipType shipType)
    {
        var availableCoords = MapCoords.Where(c => c.IsAvailable).ToList();
        var isVertical = _random.NextDouble() > 0.5;
        var startPoint = GetShipStartPoint(availableCoords, shipType, isVertical, out var positiveShipDirection);
        List<Coord> shipCoords;
        
        if (isVertical)
        {
            var shipValues = GetShipValues(startPoint, isVertical, (int)shipType, positiveShipDirection);
            shipCoords = availableCoords.Where(c => c.X == startPoint.X && shipValues.Contains(c.Y)).ToList();
            
        }
        else
        {
            var shipValues = GetShipValues(startPoint, isVertical, (int)shipType, positiveShipDirection);
            shipCoords = availableCoords.Where(c => c.Y == startPoint.Y && shipValues.Contains(c.X)).ToList();

        }
        
        var ship = new Ship(shipType, shipCoords);
        Ships.Add(ship);
            
        DisableMapCoords(shipCoords, availableCoords);
    }

    private void DisableMapCoords(List<Coord> shipCoords, List<Coord> availableCoords)
    {
        var coordsToDisable = new List<Coord>();
            
        foreach (var shipCoord in shipCoords)
        {
            var xValues = Enumerable.Range(shipCoord.X - 1, 3).ToList();
            var yValues = Enumerable.Range(shipCoord.Y - 1, 3).ToList();
            var coords = availableCoords.Where(c =>
                xValues.Contains(c.X) && yValues.Contains(c.Y) &&
                !coordsToDisable.Any(d => d.X == c.X && d.Y == c.Y)).ToList();

            coords.ForEach(c => c.IsAvailable = false);
                
            coordsToDisable.AddRange(coords);
        }
    }

    private Coord GetShipStartPoint(List<Coord> availableCoords, ShipType shipType, bool isVertical, out bool positiveShipDirection)
    {
        var randomIndex = _random.Next(availableCoords.Count);
        var startPoint = availableCoords[randomIndex];

        if (!CanGenerateShip(availableCoords, startPoint, shipType, isVertical, out positiveShipDirection))
        {
            return GetShipStartPoint(availableCoords, shipType, isVertical, out positiveShipDirection);
        }

        return startPoint;
    }

    private bool CanGenerateShip(List<Coord> availableCoords, Coord startPoint, ShipType shipType, bool isVertical, out bool positiveShipDirection)
    {
        var shipLenght = (int)shipType;
        var shipValues = new List<int>();
        positiveShipDirection = true;

        if (isVertical)
        {
            var availableCoordsValues = availableCoords.Where(c => c.X == startPoint.X).Select(c => c.Y).ToList();

            if (startPoint.Y + shipLenght > 11)
            {
                positiveShipDirection = false;
            }

            shipValues = GetShipValues(startPoint, isVertical, shipLenght, positiveShipDirection);
            
            return shipValues.All(y => availableCoordsValues.Contains(y));
        }
        else
        {
            var availableCoordsValues = availableCoords.Where(c => c.Y == startPoint.Y).Select(c => c.X).ToList();
            
            if (startPoint.X + shipLenght > 11)
            {
                positiveShipDirection = false;
            }
            
            shipValues = GetShipValues(startPoint, isVertical, shipLenght, positiveShipDirection);

            return shipValues.All(x => availableCoordsValues.Contains(x));
        }
    }

    private List<int> GetShipValues(Coord startPoint, bool isVertical, int shipLenght, bool positiveShipDirection)
    {
        var shipValues = new List<int>();
        
        if (isVertical)
        {
            if (positiveShipDirection)
            {
                shipValues = Enumerable.Range(startPoint.Y, shipLenght).ToList();
            }
            else
            {
                var posAdjustment = shipLenght - 1;
                shipValues = Enumerable.Range(startPoint.Y - posAdjustment, shipLenght).ToList();
            }
        }
        else
        {
            if (positiveShipDirection)
            {
                shipValues = Enumerable.Range(startPoint.X, shipLenght).ToList();
            }
            else
            {
                var posAdjustment = shipLenght - 1;
                shipValues = Enumerable.Range(startPoint.X - posAdjustment, shipLenght).ToList();
            }
        }

        return shipValues;
    }

    private void GenerateMapCoords()
    {
        for (int x = 1; x < 11; x++)
        {
            for (int y = 1; y < 11; y++)
            {
                var coord = new Coord(x, y);
                MapCoords.Add(coord);
            }
        }
    }
}