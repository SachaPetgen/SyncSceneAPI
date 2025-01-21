namespace SyncScene.Domain.Exceptions;

public class InvalidIdentifierException : BaseCustomException
{
    public InvalidIdentifierException() : base(ExceptionMessages.InvalidIdentifierException, 401)
    {
    }
}