namespace SyncScene.Domain.Exceptions;

public class UnableToCreateException : BaseCustomException
{
    public UnableToCreateException() : base(ExceptionMessages.UnableToCreateException, 500)
    {
    }
}