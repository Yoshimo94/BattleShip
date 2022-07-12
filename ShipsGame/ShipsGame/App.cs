using ShipsGame.Enums;

namespace ShipsGame;

public class App
{
    public Dictionary<int, string> coordMapping = new Dictionary<int, string>
    {
        { 1, "A" },
        { 2, "B" },
        { 3, "C" },
        { 4, "D" },
        { 5, "E" },
        { 6, "F" },
        { 7, "G" },
        { 8, "H" },
        { 9, "I" },
        { 10, "J" },
    };

    private Player _firstPlayer;
    private Player _secondPlayer;
    
    public void StartGame()
    {
        _firstPlayer = new Player("Player_1");
        _secondPlayer = new Player("Player_2");
        var roundNumber = 1;

        while (true)
        {
            var gameResult = CheckGameResult(out var winner);

            switch (gameResult)
            {
                case GameResult.Tie:
                    Console.WriteLine("Tie!");
                    return;
                case GameResult.GameOver:
                    Console.WriteLine($"{winner?.Name} is the winner!");
                    return;
                case GameResult.Playing:
                    break;
            }
            
            
        }
    }

    public GameResult CheckGameResult(out Player? winner)
    {
        winner = null;
        var firstPlayerResult = _firstPlayer.Battleground.Ships.All(s => s.IsDestroyed);
        var secondPlayerResult = _secondPlayer.Battleground.Ships.All(s => s.IsDestroyed);

        switch (firstPlayerResult)
        {
            case true when secondPlayerResult:
                return GameResult.Tie;
            case true:
                winner = _secondPlayer;
            
                return GameResult.GameOver;
            case false when secondPlayerResult:
                winner = _firstPlayer;

                return GameResult.GameOver;
        }
        
        return GameResult.Playing;
    }
}