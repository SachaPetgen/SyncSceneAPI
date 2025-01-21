namespace SyncScene.Domain.Exceptions;

public class InvalidPasswordException : BaseCustomException
{
    public InvalidPasswordException() : base(ExceptionMessages.InvalidPasswordException, 401)
    {
    }
}