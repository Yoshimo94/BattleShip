namespace ShipsGame.Exceptions;

public class IncorrectGameResultException : Exception
{
    public IncorrectGameResultException(string message) : base(message)
    {
    }
}