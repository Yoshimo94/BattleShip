using ShipsGame.Enums;
using ShipsGame.Exceptions;

namespace ShipsGame;

public class App
{
    private Player _firstPlayer;
    private Player _secondPlayer;
    private Random _random = new();
    
    public void StartGame()
    {
        var startDate = DateTime.Now;
        _firstPlayer = new Player("Player_1");
        _secondPlayer = new Player("Player_2");
        var roundNumber = 1;

        while (true)
        {
            var gameResult = CheckGameResult(out var winner);

            switch (gameResult)
            {
                case GameResult.Tie:
                    Console.WriteLine($"Game ended in {roundNumber} round/s with a result: {GameResult.Tie}");
                    CalculateGameTime(startDate);
                    return;
                case GameResult.GameOver:
                    Console.WriteLine($"Game ended in {roundNumber} round/s with a result: {winner?.Name} is the winner!");
                    CalculateGameTime(startDate);
                    return;
                case GameResult.Playing:
                    break;
                default:
                    throw new IncorrectGameResultException($"{nameof(StartGame)} - Incorrect GameResult!");
            }

            SimulateRound();
            roundNumber++;
        }
    }

    private void CalculateGameTime(DateTime startDate)
    {
        var endDate = DateTime.Now;
        var timeDiff = endDate.Subtract(startDate).TotalSeconds;
        Console.WriteLine($"Simulation took {timeDiff} seconds");
    }

    private void SimulateRound()
    {
        var randomIndex = _random.Next(_firstPlayer.Battleground.MapCoords.Count);
        var randomHitPoint = _firstPlayer.Battleground.MapCoords[randomIndex];

        var fpHitPoint = _firstPlayer.Battleground.MapCoords.SingleOrDefault(c => c.X == randomHitPoint.X && c.Y == randomHitPoint.Y);
        var spHitPoint = _secondPlayer.Battleground.MapCoords.SingleOrDefault(c => c.X == randomHitPoint.X && c.Y == randomHitPoint.Y);

        //TODO Custom Ex? - can also try/catch this method and rerun simulation when EX occurs
        if (fpHitPoint == null || spHitPoint == null)
            throw new ArgumentNullException(nameof(randomHitPoint), "Incorrect hit point selected!");
        
        fpHitPoint.IsMarked = true;
        spHitPoint.IsMarked = true;

        CheckShipsStatuses();
    }

    private void CheckShipsStatuses()
    {
        var fpDestroyedShips = _firstPlayer.Battleground.Ships.Where(s => !s.IsDestroyed && s.ShipPoints.All(p => p.IsMarked)).ToList();
        var spDestroyedShips = _secondPlayer.Battleground.Ships.Where(s => !s.IsDestroyed && s.ShipPoints.All(p => p.IsMarked)).ToList();
        fpDestroyedShips.ForEach(s => s.IsDestroyed = true);
        spDestroyedShips.ForEach(s => s.IsDestroyed = true);
    }

    private GameResult CheckGameResult(out Player? winner)
    {
        winner = null;
        var firstPlayerDestroyed = _firstPlayer.Battleground.Ships.All(s => s.IsDestroyed);
        var secondPlayerDestroyed = _secondPlayer.Battleground.Ships.All(s => s.IsDestroyed);

        switch (firstPlayerDestroyed)
        {
            case true when secondPlayerDestroyed:
                return GameResult.Tie;
            case true:
                winner = _secondPlayer;
            
                return GameResult.GameOver;
            case false when secondPlayerDestroyed:
                winner = _firstPlayer;

                return GameResult.GameOver;
            default:
                return GameResult.Playing;
        }
    }
}